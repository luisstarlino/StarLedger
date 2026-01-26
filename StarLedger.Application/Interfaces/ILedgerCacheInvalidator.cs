using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.Interfaces
{
    public interface ILedgerCacheInvalidator
    {
        IChangeToken GetExpirationToken();
        void Invalidate();
    }
}
