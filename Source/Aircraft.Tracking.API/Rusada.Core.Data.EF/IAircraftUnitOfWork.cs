using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Core.Data.EF
{
	/// <summary>
	/// Unit of work interface.
	/// </summary>
	public interface IAircraftUnitOfWork
	{
		IAircraftRepository Aircrafts { get; }

		Task CompleteAsync();

		void Complete();

		Task BeginTransactionAsync();

		void CommitTransaction();

		void RollbackTransaction();
	}
}
