using StarLedger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.Interfaces
{
    public interface ILedgerRepository
    {
        LedgerAccount Get();
        void Save(LedgerAccount account);
    }
}
