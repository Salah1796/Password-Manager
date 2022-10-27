
using AutoMapper;
using Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PasswordManager.API.Filters;
using PasswordManager.Application.AutoMapper;
using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Features.ServiceCredential.Commands.Delete;
using PasswordManager.Application.Features.ServiceCredential.Queries.GetById;
using PasswordManager.Application.Models.ViewModels;

namespace PasswordManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ServiceCredentialController : ControllerBase
    {

        #region Data Members
        private readonly IMediator _mediator;
        private readonly ILogger<ServiceCredentialController> _logger;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        #endregion

        public ServiceCredentialController(ILogger<ServiceCredentialController> logger, IMediator mediator, IMapper mapper, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        [Route("Search")]
        [HttpPost]
        
        public async Task<BasePaginatedResponse<List<ServiceCredentialLightViewModel>>> Search(ServiceCredentialSearchModel ServiceCredentialSearchModel)
        {
            var result = new BasePaginatedResponse<List<ServiceCredentialLightViewModel>>();
            var currentUserId = _currentUserService.GetCurrentUserId();
            var ServiceCredentialesListQuery = ServiceCredentialSearchModel.ToServiceCredentialesListQuery(_mapper);
            if (ServiceCredentialesListQuery != null)
            {
                ServiceCredentialesListQuery.CurrentUserId = currentUserId.GetValueOrDefault();
                var response = await _mediator.Send(ServiceCredentialesListQuery);
                result = response.BasePaginatedResponse<List<ServiceCredentialLightViewModel>>(_mapper);
            }
            return result;
        }

        [Route("Get/{Id}")]
        [HttpGet]
        public async Task<BaseResponse<ServiceCredentialViewModel>> GetById(Guid Id)
        {
            var result = new BaseResponse<ServiceCredentialViewModel>();
            var currentUserId = _currentUserService.GetCurrentUserId();
            var serviceCredentialByIdQuery = new GetServiceCredentialByIdQuery() { Id = Id,CurrentUserId = currentUserId.GetValueOrDefault()};
            if (serviceCredentialByIdQuery != null)
            {
                var response = await _mediator.Send(serviceCredentialByIdQuery);
                result = response.ToBaseResponse<ServiceCredentialViewModel>(_mapper);
            }
            return result;
        }


        [Route("Add")]
        [HttpPost]
        public async Task<BaseResponse<ServiceCredentialViewModel>> Add(ServiceCredentialCreateViewModel ServiceCredentialCreateViewModel)
        {
            var result = new BaseResponse<ServiceCredentialViewModel>();
            var currentUserId = _currentUserService.GetCurrentUserId();
            var ServiceCredentialCreateCommand = ServiceCredentialCreateViewModel.ToServiceCredentialCreateCommand(_mapper);
            if (ServiceCredentialCreateCommand != null)
            {
                ServiceCredentialCreateCommand.CurrentUserId = currentUserId.GetValueOrDefault(); 
                var response = await _mediator.Send(ServiceCredentialCreateCommand);
                result = response.ToBaseResponse<ServiceCredentialViewModel>(_mapper);
            }
            return result;
        }

        [Route("Update")]
        [HttpPut]
        public async Task<BaseResponse<ServiceCredentialViewModel>> Update(ServiceCredentialEditViewModel ServiceCredentialCreateViewModel)
        {
            var result = new BaseResponse<ServiceCredentialViewModel>();
            var currentUserId = _currentUserService.GetCurrentUserId();
            var ServiceCredentialUpdateCommand = ServiceCredentialCreateViewModel.ToServiceCredentialUpdateCommand(_mapper);
            if (ServiceCredentialUpdateCommand != null)
            {
                ServiceCredentialUpdateCommand.CurrentUserId = currentUserId.GetValueOrDefault();  
                var response = await _mediator.Send(ServiceCredentialUpdateCommand);
                result = response.ToBaseResponse<ServiceCredentialViewModel>(_mapper);
            }
            return result;
        }


        [Route("Delete/{Id}")]
        [HttpDelete]
        public async Task<DeleteServiceCredentialCommandResponse> Delete(Guid Id)
        {
            DeleteServiceCredentialCommandResponse response = null;
            var currentUserId = _currentUserService.GetCurrentUserId();
            var ServiceCredentialDeleteCommand = new DeleteServiceCredentialCommand(Id, currentUserId.GetValueOrDefault());
            response = await _mediator.Send(ServiceCredentialDeleteCommand);
            return response;
        }

    }
}

