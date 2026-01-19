using StarLedger.Application.Interfaces;
using StarLedger.Application.UseCases.Command;
using StarLedger.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.UseCases.Handler
{
    public class AddEntryCommandHandler
    {
        private readonly ILedgerRepository _repository;

        public AddEntryCommandHandler(ILedgerRepository repository)
        {
            _repository = repository;
        }

        public void Handle(AddEntryCommand command)
        {
            var account = _repository.Get();

            var entry = new LedgerEntry(command.Amount, command.Type);
            account.AddEntry(entry);

            _repository.Save(account);
        }
    }
}
