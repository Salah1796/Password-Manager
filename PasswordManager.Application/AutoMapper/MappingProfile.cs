using AutoMapper;
using PasswordManager.Application.Common.Responses;
using PasswordManager.Application.Features.ServiceCredential.Commands.Create;
using PasswordManager.Application.Features.ServiceCredential.Commands.Update;
using PasswordManager.Application.Features.ServiceCredential.Queries.GetById;
using PasswordManager.Application.Features.ServiceCredential.Queries.GetList;
using PasswordManager.Application.Models.ViewModels;
using PasswordManager.Application.Models.ViewModels.Identity;
using PasswordManager.Domain.Entities;
using System.Collections.Generic;

namespace PasswordManager.Application.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            #region ServiceCredential

            #region Create
            CreateMap<ServiceCredentialCreateViewModel, CreateServiceCredentialCommand>();
            CreateMap<CreateServiceCredentialCommand, ServiceCredential>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(s=> s.CurrentUserId));
            CreateMap<ServiceCredential, CreateServiceCredentialResponseViewModel>();
            CreateMap<CreateServiceCredentialResponseViewModel, ServiceCredentialViewModel>();
            CreateMap<CreateServiceCredentialCommandResponse, BaseResponse<ServiceCredentialViewModel>>();

            #endregion

            #region Update
            CreateMap<ServiceCredentialEditViewModel, UpdateServiceCredentialCommand>();
            CreateMap<UpdateServiceCredentialCommand, ServiceCredential>();
            CreateMap<ServiceCredential, UpdateServiceCredentialResponseViewModel>();
            CreateMap<UpdateServiceCredentialResponseViewModel, ServiceCredentialViewModel>();
            CreateMap<UpdateServiceCredentialCommandResponse, BaseResponse<ServiceCredentialViewModel>>();
            #endregion

            #region Search
            CreateMap<ServiceCredentialSearchModel, GetServiceCredentialsListQuery>();
            CreateMap<ServiceCredential, GetServiceCredentialsListRespnseViewModel>();
            CreateMap<GetServiceCredentialsListRespnseViewModel, ServiceCredentialLightViewModel>();
            CreateMap<GetServiceCredentialsListResponse, BasePaginatedResponse<List<ServiceCredentialLightViewModel>>>();
            #endregion

            #region GetById
            CreateMap<ServiceCredential, GetServiceCredentialByIdRespnseViewModel>();
            CreateMap<GetServiceCredentialByIdRespnseViewModel, ServiceCredentialViewModel>();
            CreateMap<GetServiceCredentialByIdResponse, BaseResponse<ServiceCredentialViewModel>>();
            #endregion

            CreateMap<ServiceCredentialViewModel, ServiceCredentialEditViewModel>();
            #endregion

            #region Auth
            CreateMap<RegistrationRequest, User>();
            #endregion

        }
    }
}
