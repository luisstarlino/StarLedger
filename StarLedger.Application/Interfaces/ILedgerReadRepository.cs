using StarLedger.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.Interfaces
{
    public interface ILedgerReadRepository
    {
        decimal GetCurrentBalace();
        IReadOnlyList<HistoryEntriesOutput> GetHistoryEntries(DateTime from, DateTime to);
    }
}
