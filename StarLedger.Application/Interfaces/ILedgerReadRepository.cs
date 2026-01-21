using StarLedger.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.Interfaces
{
    public interface ILedgerReadRepository
    {
        decimal GetCurrentBalace();
        List<HistoryEntriesOutput> GetHistoryEntries();
    }
}
