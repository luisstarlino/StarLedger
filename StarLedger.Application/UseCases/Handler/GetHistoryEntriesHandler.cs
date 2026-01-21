using StarLedger.Application.Interfaces;
using StarLedger.Application.UseCases.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.UseCases.Handler
{
    public class GetHistoryEntriesHandler
    {
        private readonly ILedgerReadRepository _repository;

        public GetHistoryEntriesHandler(ILedgerReadRepository repository)
        {
            _repository = repository;
        }

        public List<HistoryEntriesOutput> Handle()
        {
            return _repository.GetHistoryEntries();
        }
    }
}
