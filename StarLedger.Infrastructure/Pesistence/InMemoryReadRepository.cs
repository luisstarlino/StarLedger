using StarLedger.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Infrastructure.Pesistence
{
    public class InMemoryReadRepository : ILedgerReadRepository
    {
        private readonly ILedgerRepository _repository;

        public InMemoryReadRepository (ILedgerRepository repository)
        {
            _repository = repository; 
        }

        public decimal GetCurrentBalace()
        {
            return _repository.Get().Balance;
        }
    }
}
