using Microsoft.Extensions.Caching.Memory;
using StarLedger.Application.Interfaces;
using StarLedger.Application.UseCases;
using StarLedger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Infrastructure.Pesistence
{
    // *** 1. CACHE READ REPOSITORY (Simple TTL)
    public class InCachedLedgerRepository : ILedgerReadRepository
    {
        private readonly ILedgerReadRepository _inner;
        private readonly IMemoryCache _cache;

        public InCachedLedgerRepository(ILedgerReadRepository inner, IMemoryCache cache)
        {
            _inner = inner;
            _cache = cache;
        }

        public decimal GetCurrentBalace()
        {
            return _inner.GetCurrentBalace();
        }

        public IReadOnlyList<HistoryEntriesOutput> GetHistoryEntries(DateTime from, DateTime to)
        {
            // --- Key
            var cacheKey = $"ledger_entries_{from:yyyyMMdd}_{to:yyyyMMdd}";

            if (_cache.TryGetValue(cacheKey, out IReadOnlyList<HistoryEntriesOutput> cached)) return cached;

            var result = _inner.GetHistoryEntries(from, to);

            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(5));

            return result;
        }
    }
}
