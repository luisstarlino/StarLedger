using StarLedger.Application.Interfaces;
using StarLedger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.UseCases
{
    public class AddEntryUseCase
    {
        private readonly ILedgerRepository _repository;

        public AddEntryUseCase(ILedgerRepository repository)
        {
            _repository = repository;
        }

        public AddEntryOutput Execute(AddEntryInput input)
        {
            var account = _repository.Get(); // --- Get the ledger

            var entry = new LedgerEntry(input.Amount, input.Type);
            account.AddEntry(entry);

            _repository.Save(account);

            return new AddEntryOutput
            {
                CurrentBalance = account.Balance,
            };
        }

    }
}
