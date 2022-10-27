#region Using ...

using PasswordManager.Application.Common.Models;
using System;
using System.Diagnostics;
#endregion

namespace PasswordManager.Application.Models.ViewModels
{
    public class ServiceCredentialViewModel
    {
        #region Properties      
        public Guid Id { get; set; }
        public string ServiceName { get; set; }
        public string ServiceURL { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        #endregion
    }
}
