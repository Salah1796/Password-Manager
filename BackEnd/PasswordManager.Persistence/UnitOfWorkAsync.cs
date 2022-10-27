#region Using ...
using PasswordManager.Application.Contracts.Persistence;
using System;
using System.Threading.Tasks;
#endregion

namespace PasswordManager.Persistence
{
	/// <summary>
	/// 
	/// </summary>
	public class UnitOfWorkAsync : IUnitOfWorkAsync
	{
		#region Data Members
		private PasswordManagerDbContext _context;
		#endregion

		#region Constructors
		public UnitOfWorkAsync(PasswordManagerDbContext context)
		{
			this._context = context;
		}
		#endregion

		#region IUnitOfWork	
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public async Task<int> CommitAsync()
		{
			var result = await this._context.SaveChangesAsync();
			return result;
		}

        #endregion
    }
}
