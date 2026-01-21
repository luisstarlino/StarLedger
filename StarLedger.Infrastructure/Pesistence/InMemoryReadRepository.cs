using StarLedger.Application.Interfaces;
using StarLedger.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Infrastructure.Pesistence
{
    public class InMemoryReadRepository : ILedgerReadRepository
    {
        private readonly ILedgerRepository _repository;

        public InMemoryReadRepository(ILedgerRepository repository)
        {
            _repository = repository;
        }

        public decimal GetCurrentBalace()
        {
            return _repository.Get().Balance;
        }

        public List<HistoryEntriesOutput> GetHistoryEntries()
        {
            // --- Get from DB
            var histories = _repository.Get().HistoryEntries;

            // --- Map
            List<HistoryEntriesOutput> mapper = new();
            foreach (var historyEntry in histories)
            {
                mapper.Add(new HistoryEntriesOutput
                {
                    Amount = historyEntry.Amount,
                    Type = historyEntry.Type,
                    Date = historyEntry.Date,
                });
            }

            return mapper;
        }
    }
}
