using System;
using _343.ERP.SIGA.Models;

namespace _343.ERP.SIGA.Repositories
{
	public interface ITransactionRepository
	{
		void Add(Transaction transaction);
		void Delete(Transaction transaction);
		List<Transaction> GetAll();
		void Update(Transaction transaction);
	}
}

