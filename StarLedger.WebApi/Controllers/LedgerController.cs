using Microsoft.AspNetCore.Mvc;
using StarLedger.Application.UseCases;
using StarLedger.Application.UseCases.Command;
using StarLedger.Application.UseCases.Handler;
using StarLedger.Application.UseCases.Query;

namespace StarLedger.WebApi.Controllers
{
    [ApiController]
    [Route("ledger")]
    public class LedgerController : ControllerBase
    {
        private readonly AddEntryCommandHandler _commandHandler;
        private readonly GetBalanceQueryHandler _queryHandler;

        

        public LedgerController(AddEntryCommandHandler commandHandler, GetBalanceQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        [HttpPost("entry")]
        public IActionResult Add(AddEntryCommand input)
        {
            _commandHandler.Handle(input);
            return Accepted();
        }

        [HttpGet("balance")]
        public IActionResult GetBalance()
        {
            var balance = _queryHandler.Handle(new GetBalanceQuery());
            return Ok(balance);
        }
    }
}
