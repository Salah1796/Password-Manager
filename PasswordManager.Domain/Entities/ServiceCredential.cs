using PasswordManager.Domain.Common;
using PasswordManager.Domain.Common.Contracts;
using System;
using System.Collections.Generic;

namespace PasswordManager.Domain.Entities
{
    public class ServiceCredential : IEntityIdentity<Guid>, IDeletionSignature
        , IModificatioDateSignature, ICreationDateSignature, IEntityCreatedUserSignature
    {
        #region IEntityIdentity

        public Guid Id { get; set; }

        #endregion

        #region IDeletionSignature

        public bool IsDeleted { get; set; }
        public DateTime? DeletionDate { get; set; }
        public Guid? DeletedByUserId { get; set; }
        public bool? MustDeletedPhysical { get; set; }

        #endregion

        #region ICreationDateSignature

        public DateTime CreationDate { get; set; }

        #endregion

        #region IModificatioDateSignature

        public DateTime? FirstModificationDate { get; set; }
        public DateTime? LastModificationDate { get; set; }

        #endregion

        #region IEntityCreatedUserSignature
        public Guid CreatedByUserId { get; set; }
        #endregion

        public string ServiceName { get; set; }
        public string ServiceURL { get; set; }
        public string AccountUsername { get; set; }
        public string AccountPassword { get; set; }

        public  Guid UserId { get; set; }
        public virtual User User { get; set; }  
    }
}