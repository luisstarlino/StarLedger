using StarLedger.Application.Interfaces;
using StarLedger.Application.UseCases.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarLedger.Application.UseCases.Handler
{
    public class GetBalanceQueryHandler
    {
        private readonly ILedgerReadRepository _repository;

        public GetBalanceQueryHandler(ILedgerReadRepository repository)
        {
            _repository = repository;
        }

        public decimal Handle(GetBalanceQuery handler)
        {
            return _repository.GetCurrentBalace();
        }
    }
}
