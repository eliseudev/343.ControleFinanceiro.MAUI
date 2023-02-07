using System;
using LiteDB;

namespace _343.ERP.SIGA.Models
{
    public class Transaction
    {
        [BsonId]
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        public string Nome { get; set; }
        public DateTimeOffset Date { get; set; }
        public double Value { get; set; }
    }

    public enum TransactionType
    {
        Income,
        Expenses
    }
}

