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

        public IReadOnlyList<HistoryEntriesOutput> GetHistoryEntries(DateTime from, DateTime to)
        {
            // --- Get from DB
            var histories2 = _repository.Get();

            var histories = _repository.Get().HistoryEntries
            .Where(e => e.Date.Date >=from.Date && e.Date.Date <=to.Date)
            .Select(e => new HistoryEntriesOutput
            {
                    Amount = e.Amount,
                    Type = e.Type,
                    Date = e.Date,
            }).ToList();

            return histories;
        }
    }
}
