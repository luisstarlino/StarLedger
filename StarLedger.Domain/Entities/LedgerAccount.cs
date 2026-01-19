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

            // --- Credit === ADD
            var isCredit = entry.Type == Enums.EntryType.Credit;    // | type = 0 (Working well)
            var isDebid = entry.Type == Enums.EntryType.Debit;      // | type = 1



            if (entry.Type == Enums.EntryType.Debit && Balance == 0 || entry.Type == Enums.EntryType.Debit && Balance < entry.Amount)
                throw new InvalidOperationException("You dont have credits!");

            _entries.Add(entry);
        }
    }
}
