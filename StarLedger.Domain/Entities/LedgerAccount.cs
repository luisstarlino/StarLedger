using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Domain.Entities
{
    public class LedgerAccount
    {
        private readonly List<LedgerEntry> _entries = new();
        public decimal Balance => _entries.Sum(e => e.Type == Enums.EntryType.Credit ? e.Amount : -e.Amount);
        public void AddEntry(LedgerEntry entry)
        {
            if (entry.Type == Enums.EntryType.Debit && Balance < entry.Amount)
                throw new InvalidOperationException("You dont have credits!");

            _entries.Add(entry);
        }
    }
}
