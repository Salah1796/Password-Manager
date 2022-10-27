#region Using ...

using PasswordManager.Application.Common.Models;
using System;
using System.Diagnostics;
#endregion

namespace PasswordManager.Application.Models.ViewModels
{
    public class ServiceCredentialEditViewModel : ServiceCredentialCreateViewModel
    {

        #region Properties      
        public Guid Id { get; set; }
        #endregion
    }
}
