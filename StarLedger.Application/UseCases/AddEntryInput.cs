using StarLedger.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.UseCases
{
    public class AddEntryInput
    {
        public decimal Amount { get; set; }
        public EntryType Type { get; set; }
    }
}
