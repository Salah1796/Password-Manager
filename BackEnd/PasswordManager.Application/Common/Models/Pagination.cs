
namespace PasswordManager.Application.Common.Models
{
	public class Pagination
	{
		#region Properties
		public int PageIndex { get; set; } = 0;
		public int PageSize { get; set; } = 10;
		public long TotalCount { get; set; }
		public bool GetTotalCount { get; set; } = true;
		#endregion
	}
}
