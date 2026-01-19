using StarLedger.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.UseCases.Command
{
    public class AddEntryCommand
    {
        public decimal Amount { get; set; }
        public EntryType Type { get; set; }
    }
}
