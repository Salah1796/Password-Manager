#region Using ...
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace PasswordManager.Domain.Common.Contracts
{
	public interface IModificatioDateSignature 
	{
		#region Properties
		DateTime? FirstModificationDate { get; set; }
		DateTime? LastModificationDate { get; set; }
		#endregion
	}
}
