using StarLedger.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Domain.Entities
{
    public class LedgerEntry
    {
        public decimal Amount { get; }
        public EntryType Type { get; }
        public DateTime Date { get; }

        public LedgerEntry(decimal amount, EntryType type)
        {
            if (amount <= 0) throw new ArgumentException("The amount value has to be more them zero!");

            Amount = amount;
            Type = type;
            Date = DateTime.Now;
        }
    }
}
