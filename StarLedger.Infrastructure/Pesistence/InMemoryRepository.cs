using StarLedger.Application.Interfaces;
using StarLedger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Infrastructure.Pesistence
{
    public class InMemoryRepository : ILedgerRepository
    {
        // --- IN MEMORY STORE
        private LedgerAccount _account = new();
        private ILedgerCacheInvalidator _cleanCache;

        public InMemoryRepository(ILedgerCacheInvalidator cacheRepository)
        {
            _cleanCache = cacheRepository;
        }


        public LedgerAccount Get()
        {
            return _account;
        }

        public void Save(LedgerAccount account)
        {
            _account = account;
            _cleanCache.Invalidate();
        }
    }
}
