using AutoMapper;
using PasswordManager.Application.Contracts.Persistence;
using PasswordManager.Application.Contracts.Persistence.IRepositories;
using System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using PasswordManager.Application.Contracts.Identity;
using AutoMapper.QueryableExtensions;
using PasswordManager.Application.Models.ViewModels;
using PasswordManager.Application.Contracts.Infrastructure;

namespace PasswordManager.Application.Features.ServiceCredential.Queries.GetById
{
    public class GetServiceCredentialByIdQueryHandler : IRequestHandler<GetServiceCredentialByIdQuery, GetServiceCredentialByIdResponse>
    {
        private readonly IServiceCredentialRepository _ServiceCredentialRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetServiceCredentialByIdQuery> _validator;
        private readonly IAuthenticationService _authenticationService;
        private readonly IEncryptionService _encryptionService;
        public GetServiceCredentialByIdQueryHandler(IMapper mapper, IServiceCredentialRepository ServiceCredentialRepository, IValidator<GetServiceCredentialByIdQuery> validator, IAuthenticationService authenticationService, IEncryptionService encryptionService)
        {
            _mapper = mapper;
            _ServiceCredentialRepository = ServiceCredentialRepository;
            _validator = validator;
            _authenticationService = authenticationService;
            _encryptionService = encryptionService;
        }

        public async Task<GetServiceCredentialByIdResponse> Handle(GetServiceCredentialByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new GetServiceCredentialByIdResponse();
            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {
                #region Build Query
                var ServiceCredentialesQuery = _ServiceCredentialRepository.Get();
                ServiceCredentialesQuery = ServiceCredentialesQuery.Where(x => x.Id == request.Id);
                ServiceCredentialesQuery = ServiceCredentialesQuery.Where(x => x.IsDeleted == false);
                #endregion

                var ServiceCredential =  await ServiceCredentialesQuery.ProjectTo<GetServiceCredentialByIdRespnseViewModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();
                
                if(ServiceCredential != null)
                {
                    if(ServiceCredential.UserId != request.CurrentUserId)
                    {
                        response.Success = false;
                        response.Code = Common.Enums.StatusCode.Unauthorized;
                        response.Message = $"Unauthorized to access credential with id  =  {request.Id} ";
                    }
                    else
                    {
                        ServiceCredential.AccountPassword = _encryptionService.DecryptString(ServiceCredential.AccountPassword);
                        response.Data = ServiceCredential;
                    }
                   
                }
                else
                {
                    response.Success = false;
                    response.Code = Common.Enums.StatusCode.NotFound;
                    response.Message = $" credential with id  =  {request.Id} not exist ";
                }
              
            }
            return response;
        }
    }
}
