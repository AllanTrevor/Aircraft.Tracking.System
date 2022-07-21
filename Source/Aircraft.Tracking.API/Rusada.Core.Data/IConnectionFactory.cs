using System.Data;

namespace Rusada.Core.Data
{
	/// <summary>
	/// Connection Factory.
	/// </summary>
	public interface IConnectionFactory
	{
		/// <summary>
		/// Gets the connection.
		/// </summary>
		/// <returns></returns>
		IDbConnection GetConnection();
	}
}
