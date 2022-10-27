using AutoMapper;
using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Features.ServiceCredential.Commands.Create;
using PasswordManager.Application.Features.ServiceCredential.Commands.Update;
using PasswordManager.Application.Features.ServiceCredential.Queries.GetById;
using PasswordManager.Application.Features.ServiceCredential.Queries.GetList;
using PasswordManager.Application.Models.ViewModels;
using PasswordManager.Application.Models.ViewModels.Identity;
using PasswordManager.Domain.Entities;

namespace PasswordManager.Application.AutoMapper
{
    public static class Extensions
    {
        #region ServiceCredential
        public static CreateServiceCredentialResponseViewModel ToCreateResponseViewModel(this ServiceCredential entity, IMapper mapper)
        {
            var result = mapper.Map<ServiceCredential, CreateServiceCredentialResponseViewModel>(entity);
            return result;
        }
        public static ServiceCredential ToModel(this CreateServiceCredentialCommand entity, IMapper mapper)
        {
            var result = mapper.Map<CreateServiceCredentialCommand, ServiceCredential>(entity);
            return result;
        }
        public static UpdateServiceCredentialResponseViewModel ToUpdateResponseViewModel(this ServiceCredential entity, IMapper mapper)
        {
            var result = mapper.Map<ServiceCredential, UpdateServiceCredentialResponseViewModel>(entity);
            return result;
        }
        public static ServiceCredential ToModel(this UpdateServiceCredentialCommand entity, IMapper mapper)
        {
            var result = mapper.Map<UpdateServiceCredentialCommand, ServiceCredential>(entity);
            return result;
        }

        public static GetServiceCredentialsListQuery ToServiceCredentialesListQuery(this ServiceCredentialSearchModel entity, IMapper mapper)
        {
            var result = mapper.Map<ServiceCredentialSearchModel, GetServiceCredentialsListQuery>(entity);
            return result;
        }

        public static ServiceCredentialLightViewModel ToServiceCredentialeLightViewModel(this GetServiceCredentialsListRespnseViewModel entity, IMapper mapper)
        {
            var result = mapper.Map<GetServiceCredentialsListRespnseViewModel, ServiceCredentialLightViewModel>(entity);
            return result;
        }

        public static CreateServiceCredentialCommand ToServiceCredentialCreateCommand(this ServiceCredentialCreateViewModel entity, IMapper mapper)
        {
            var result = mapper.Map<ServiceCredentialCreateViewModel, CreateServiceCredentialCommand>(entity);
            return result;
        }
        public static ServiceCredentialViewModel ToServiceCredentialViewModel(this CreateServiceCredentialResponseViewModel entity, IMapper mapper)
        {
            var result = mapper.Map<CreateServiceCredentialResponseViewModel, ServiceCredentialViewModel>(entity);
            return result;
        }


        public static UpdateServiceCredentialCommand ToServiceCredentialUpdateCommand(this ServiceCredentialEditViewModel entity, IMapper mapper)
        {
            var result = mapper.Map<ServiceCredentialEditViewModel, UpdateServiceCredentialCommand>(entity);
            return result;
        }
        public static ServiceCredentialViewModel ToServiceCredentialViewModel(this UpdateServiceCredentialResponseViewModel entity, IMapper mapper)
        {
            var result = mapper.Map<UpdateServiceCredentialResponseViewModel, ServiceCredentialViewModel>(entity);
            return result;
        }

        public static BaseResponse<T> ToBaseResponse<T>(this UpdateServiceCredentialCommandResponse entity, IMapper mapper)
        {
            var result = mapper.Map<UpdateServiceCredentialCommandResponse, BaseResponse<T>>(entity);
            return result;
        }
        public static BaseResponse<T> ToBaseResponse<T>(this CreateServiceCredentialCommandResponse entity, IMapper mapper)
        {
            var result = mapper.Map<CreateServiceCredentialCommandResponse, BaseResponse<T>>(entity);
            return result;
        }
        public static BaseResponse<T> ToBaseResponse<T>(this GetServiceCredentialByIdResponse entity, IMapper mapper)
        {
            var result = mapper.Map<GetServiceCredentialByIdResponse, BaseResponse<T>>(entity);
            return result;
        }
        public static BasePaginatedResponse<T> BasePaginatedResponse<T>(this GetServiceCredentialsListResponse entity, IMapper mapper)
        {
            var result = mapper.Map<GetServiceCredentialsListResponse, BasePaginatedResponse<T>>(entity);
            return result;
        }

        public static ServiceCredentialEditViewModel ToEditViewModel(this ServiceCredentialViewModel entity, IMapper mapper)
        {
            var result = mapper.Map<ServiceCredentialViewModel, ServiceCredentialEditViewModel>(entity);
            return result;
        }

        #endregion

        #region Auth
        public static User ToModel(this RegistrationRequest entity, IMapper mapper)
        {
            var result = mapper.Map<RegistrationRequest, User>(entity);
            return result;
        }
        #endregion



    }
}
