using AutoMapper;
using PasswordManager.Application.Contracts.Persistence;
using PasswordManager.Application.Contracts.Persistence.IRepositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PasswordManager.Application.AutoMapper;
using FluentValidation;
using PasswordManager.Application.Features.ServiceCredential.Commands.Update;
using PasswordManager.Application.Contracts.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PasswordManager.Application.Common.Enums;

namespace PasswordManager.Application.Features.ServiceCredential.Commands.UpdateServiceCredential
{
    public class UpdateServiceCredentialCommandHandler : IRequestHandler<UpdateServiceCredentialCommand, UpdateServiceCredentialCommandResponse>
    {
        private readonly IServiceCredentialRepository _ServiceCredentialRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IValidator<UpdateServiceCredentialCommand> _validator;
        private readonly IEncryptionService _encryptionService;
        public UpdateServiceCredentialCommandHandler(IMapper mapper, IServiceCredentialRepository ServiceCredentialRepository, IUnitOfWorkAsync unitOfWorkAsync, IValidator<UpdateServiceCredentialCommand> validator, IEncryptionService encryptionService)
        {
            _mapper = mapper;
            _ServiceCredentialRepository = ServiceCredentialRepository;
            _unitOfWorkAsync = unitOfWorkAsync;
            _validator = validator;
            _encryptionService = encryptionService;
        }

        public async Task<UpdateServiceCredentialCommandResponse> Handle(UpdateServiceCredentialCommand request, CancellationToken cancellationToken)
        {
            var updateServiceCredentialResponse = new UpdateServiceCredentialCommandResponse();

            var validationResult = await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                updateServiceCredentialResponse.Success = false;
                updateServiceCredentialResponse.Code = Common.Enums.StatusCode.ValidationError;
                updateServiceCredentialResponse.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else 
            {
                var existServiceCredential = await _ServiceCredentialRepository.Get().FirstOrDefaultAsync(s => s.Id == request.Id);

               if(existServiceCredential != null)
                {
                    //check if user hase access to this ServiceCredential
                    if (existServiceCredential.UserId == request.CurrentUserId)
                    {
                        //update credential from request
                        existServiceCredential.ServiceURL = request.ServiceURL;
                        existServiceCredential.ServiceName = request.ServiceName;
                        existServiceCredential.AccountUsername = request.AccountUsername;
                        existServiceCredential.AccountPassword = _encryptionService.EncryptString(request.AccountPassword);

                        existServiceCredential = _ServiceCredentialRepository.Update(existServiceCredential);
                        await _unitOfWorkAsync.CommitAsync();

                        existServiceCredential.AccountPassword = _encryptionService.DecryptString(existServiceCredential.AccountPassword);
                        updateServiceCredentialResponse.Data = existServiceCredential.ToUpdateResponseViewModel(_mapper);
                    }
                    else
                    {
                        //Not authorized
                        updateServiceCredentialResponse.Success = false;
                        updateServiceCredentialResponse.Code = StatusCode.Unauthorized;
                        updateServiceCredentialResponse.Message = $"Unauthorized to access credential with id  =  {request.Id} ";
                    }
                }
                else
                {
                    //Not exist
                    updateServiceCredentialResponse.Success = false;
                    updateServiceCredentialResponse.Code = StatusCode.NotFound;
                    updateServiceCredentialResponse.Message = $" credential with id  =  {request.Id} not exist ";
                }
               
            }
            return updateServiceCredentialResponse;
        }

    }
}
