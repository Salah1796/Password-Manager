namespace PasswordManager.Application.Models.ViewModels
{
    public class ServiceCredentialCreateViewModel 
    {

        #region Properties      
        public string ServiceName { get; set; }
        public string ServiceURL { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }
        #endregion
    }
}
