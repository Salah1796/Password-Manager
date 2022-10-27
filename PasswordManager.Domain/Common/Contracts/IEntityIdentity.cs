#region Using ...
using System;
using System.Collections.Generic;
using System.Text;
#endregion

namespace PasswordManager.Domain.Common.Contracts
{
	public interface IEntityIdentity<TPrimeryKey>
	{
	   TPrimeryKey Id { get; set; }
	}
}
