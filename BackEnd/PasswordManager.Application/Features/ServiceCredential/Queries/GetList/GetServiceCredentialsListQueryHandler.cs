using AutoMapper;
using PasswordManager.Application.Contracts.Persistence;
using PasswordManager.Application.Contracts.Persistence.IRepositories;
using PasswordManager.Application.Validation.ServiceCredential;
using PasswordManager.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using PasswordManager.Application.Models.ViewModels;
using FluentValidation;
using PasswordManager.Application.Contracts.Identity;
using PasswordManager.Application.Contracts.Infrastructure;

namespace PasswordManager.Application.Features.ServiceCredential.Queries.GetList
{
    public class GetServiceCredentialsListQueryHandler : IRequestHandler<GetServiceCredentialsListQuery, GetServiceCredentialsListResponse>
    {
        private readonly IServiceCredentialRepository _ServiceCredentialRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetServiceCredentialsListQuery> _validator;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEncryptionService _encryptionService;


        public GetServiceCredentialsListQueryHandler(IMapper mapper, IServiceCredentialRepository ServiceCredentialRepository, IValidator<GetServiceCredentialsListQuery> validator, IAuthenticationService authenticationService, IEncryptionService encryptionService)
        {
            _mapper = mapper;
            _ServiceCredentialRepository = ServiceCredentialRepository;
            _validator = validator;
            _authenticationService = authenticationService;
            _encryptionService = encryptionService;
        }

        public async Task<GetServiceCredentialsListResponse> Handle(GetServiceCredentialsListQuery request, CancellationToken cancellationToken)
        {
            var response = new GetServiceCredentialsListResponse();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                var ServiceCredentialesQuery = _ServiceCredentialRepository.Get();

                #region Build Query
                ServiceCredentialesQuery = ServiceCredentialesQuery.Where(x => x.IsDeleted == false);
                ServiceCredentialesQuery = ServiceCredentialesQuery.Where(x => x.UserId == request.CurrentUserId);
                if (!string.IsNullOrEmpty(request.ServiceName))
                {
                    ServiceCredentialesQuery = ServiceCredentialesQuery.Where(x => x.ServiceName.Contains(request.ServiceName));
                }
                #endregion

                #region Pagination & Sorting
                request.Pagination = await this._ServiceCredentialRepository.SetPaginationCount(ServiceCredentialesQuery, request.Pagination);
                ServiceCredentialesQuery = _ServiceCredentialRepository.SetPagination(ServiceCredentialesQuery, request.Pagination);
                ServiceCredentialesQuery = this._ServiceCredentialRepository.SetSortOrder(ServiceCredentialesQuery, request.Sorting);
                #endregion


                var ServiceCredentialesListQuery = ServiceCredentialesQuery
                    .ProjectTo<GetServiceCredentialsListRespnseViewModel>(_mapper.ConfigurationProvider);

                var ServiceCredentialesList = await ServiceCredentialesListQuery.ToListAsync();

                ServiceCredentialesList.ForEach(x => x.AccountPassword = _encryptionService.DecryptString(x.AccountPassword));

                response.Data = ServiceCredentialesList;
                response.Pagination = request.Pagination;
            }
            return response;
        }
    }
}
