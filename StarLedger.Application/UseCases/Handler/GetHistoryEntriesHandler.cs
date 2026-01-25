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

        public List<HistoryEntriesOutput> Handle(DateTime from, DateTime to)
        {
            return _repository.GetHistoryEntries(from, to);
        }
    }
}
