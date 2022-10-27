using AutoMapper;
using PasswordManager.Application.Contracts.Persistence;
using PasswordManager.Application.Contracts.Persistence.IRepositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PasswordManager.Application.AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using PasswordManager.Application.Common.Enums;

namespace PasswordManager.Application.Features.ServiceCredential.Commands.Delete
{
    public class DeleteServiceCredentialCommandHandler : IRequestHandler<DeleteServiceCredentialCommand, DeleteServiceCredentialCommandResponse>
    {
        private readonly IServiceCredentialRepository _ServiceCredentialRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;
        private readonly IValidator<DeleteServiceCredentialCommand> _validator;

        public DeleteServiceCredentialCommandHandler(IMapper mapper, IServiceCredentialRepository ServiceCredentialRepository, IUnitOfWorkAsync unitOfWorkAsync, IValidator<DeleteServiceCredentialCommand> validator)
        {
            _mapper = mapper;
            _ServiceCredentialRepository = ServiceCredentialRepository;
            _unitOfWorkAsync = unitOfWorkAsync;
            _validator = validator;
        }

        public async Task<DeleteServiceCredentialCommandResponse> Handle(DeleteServiceCredentialCommand request, CancellationToken cancellationToken)
        {
            var deleteServiceCredentialCommandResponse = new DeleteServiceCredentialCommandResponse();

            var validationResult =  await _validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                deleteServiceCredentialCommandResponse.Success = false;
                deleteServiceCredentialCommandResponse.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            }
            else 
            {
                var existServiceCredentia = await _ServiceCredentialRepository.Get().FirstOrDefaultAsync(s => s.Id == request.Id);
                if (existServiceCredentia != null)
                {
                    //check if user hase access to this ServiceCredential
                    if (existServiceCredentia.UserId == request.CurrentUserId)
                    {
                        //update existServiceCredentia IsDeleted
                        existServiceCredentia.IsDeleted = true;
                        existServiceCredentia = _ServiceCredentialRepository.Update(existServiceCredentia);
                        await _unitOfWorkAsync.CommitAsync();

                        deleteServiceCredentialCommandResponse.Data = true;
                    }
                    else
                    {
                        //Not authorized
                        deleteServiceCredentialCommandResponse.Success = false;
                        deleteServiceCredentialCommandResponse.Code = StatusCode.Unauthorized;
                        deleteServiceCredentialCommandResponse.Message = $"Unauthorized to access credential with id  =  {request.Id} ";
                    }
                }
                else
                {
                    deleteServiceCredentialCommandResponse.Success = false;
                    deleteServiceCredentialCommandResponse.Code = StatusCode.NotFound;
                    deleteServiceCredentialCommandResponse.Message = $" credential with id  =  {request.Id} not exist ";
                }


            }
            return deleteServiceCredentialCommandResponse;
        }

    }
}
