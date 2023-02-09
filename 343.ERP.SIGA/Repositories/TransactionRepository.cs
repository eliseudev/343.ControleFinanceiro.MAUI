using System;
using _343.ERP.SIGA.Models;
using LiteDB;

namespace _343.ERP.SIGA.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly LiteDatabase _database;
        private readonly string collectionName = "transaction";

        public TransactionRepository(LiteDatabase liteDatabase)
        {
            _database = liteDatabase;
        }

        public void Add(Transaction transaction)
        {
            var add = _database.GetCollection<Transaction>(collectionName);
            add.Insert(transaction);
            add.EnsureIndex(i => i.Date);
        }

        public void Delete(Transaction transaction)
        {
            var d = _database.GetCollection<Transaction>(collectionName);
            d.Delete(transaction.Id);
        }

        public List<Transaction> GetAll()
        {
            return _database.GetCollection<Transaction>(collectionName).Query().OrderByDescending(a => a.Date).ToList();
        }

        public void Update(Transaction transaction)
        {
            var up = _database.GetCollection<Transaction>(collectionName);
            up.Update(transaction.Id, transaction);
        }
    }
}

