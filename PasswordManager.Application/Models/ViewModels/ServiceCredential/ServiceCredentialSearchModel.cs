#region Using ...
using PasswordManager.Application.Common.Models;
#endregion

namespace PasswordManager.Application.Models.ViewModels
{
    public class ServiceCredentialSearchModel : BaseFilter
    {
        #region Constructors
        public ServiceCredentialSearchModel()
        {
        }
        #endregion

        #region Properties
        public string ServiceName { get; set; }
        #endregion
    }
}
