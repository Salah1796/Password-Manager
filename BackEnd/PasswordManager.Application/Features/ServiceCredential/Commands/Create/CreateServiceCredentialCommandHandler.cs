using AutoMapper;
using PasswordManager.Application.Contracts.Persistence;
using PasswordManager.Application.Contracts.Persistence.IRepositories;
using PasswordManager.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PasswordManager.Application.AutoMapper;
using FluentValidation;
using PasswordManager.Application.Features.ServiceCredential.Commands.Create;
using PasswordManager.Application.Contracts.Infrastructure;
using PasswordManager.Application.Contracts.Identity;

namespace PasswordManager.Application.Features.ServiceCredentialAccount.Commands.Create
{
    public class CreateServiceCredentialCommandHandler : IRequestHandler<CreateServiceCredentialCommand, CreateServiceCredentialCommandResponse>
    {
        private readonly IServiceCredentialRepository _ServiceCredentialRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IValidator<CreateServiceCredentialCommand> _validator;
        private readonly IEncryptionService _encryptionService;
        private readonly IAuthenticationService _authenticationService;

        public CreateServiceCredentialCommandHandler(IMapper mapper, IServiceCredentialRepository ServiceCredentialRepository, IUnitOfWorkAsync unitOfWorkAsync, IValidator<CreateServiceCredentialCommand> validator, IEncryptionService encryptionService, IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _ServiceCredentialRepository = ServiceCredentialRepository;
            _unitOfWorkAsync = unitOfWorkAsync;
            _validator = validator;
            _encryptionService = encryptionService;
            _authenticationService = authenticationService;
        }

        public async Task<CreateServiceCredentialCommandResponse> Handle(CreateServiceCredentialCommand request, CancellationToken cancellationToken)
        {
            var createCategoryCommandResponse = new CreateServiceCredentialCommandResponse();

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                createCategoryCommandResponse.Success = false;
                createCategoryCommandResponse.Code = Common.Enums.StatusCode.ValidationError;
                createCategoryCommandResponse.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else 
            {
                var ServiceCredential = request.ToModel(_mapper);
                ServiceCredential.AccountPassword = _encryptionService.EncryptString(request.AccountPassword);
                ServiceCredential = await _ServiceCredentialRepository.AddAsync(ServiceCredential);
                await  _unitOfWorkAsync.CommitAsync();

                ServiceCredential.AccountPassword = _encryptionService.DecryptString(ServiceCredential.AccountPassword);
                createCategoryCommandResponse.Data = ServiceCredential.ToCreateResponseViewModel(_mapper);
            }
            return createCategoryCommandResponse;
        }
    }
}
