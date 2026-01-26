using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using StarLedger.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Infrastructure.Pesistence
{
    public class LedgerCacheInvalidator : ILedgerCacheInvalidator
    {
        private CancellationTokenSource _resetTokenSource = new CancellationTokenSource(); // main trigger

        public IChangeToken GetExpirationToken()
        {
            return new CancellationChangeToken(_resetTokenSource.Token);
        }

        public void Invalidate()
        {
            // 1. Cancel current token
            _resetTokenSource.Cancel();

            // 2. Dispose the old
            _resetTokenSource.Dispose();

            // 3. Create a new one
            _resetTokenSource = new CancellationTokenSource();
        }
    }
}
