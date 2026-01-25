using Microsoft.AspNetCore.Mvc;
using StarLedger.Application.UseCases;
using StarLedger.Application.UseCases.Command;
using StarLedger.Application.UseCases.Handler;
using StarLedger.Application.UseCases.Query;
using System.Globalization;

namespace StarLedger.WebApi.Controllers
{
    [ApiController]
    [Route("ledger")]
    public class LedgerController : ControllerBase
    {
        private readonly AddEntryCommandHandler _commandHandler;
        private readonly GetBalanceQueryHandler _queryHandler;
        private readonly GetHistoryEntriesHandler _historyEntriesHandler;




        public LedgerController(AddEntryCommandHandler commandHandler, GetBalanceQueryHandler queryHandler, GetHistoryEntriesHandler historyEntriesHandler)
        {
            _historyEntriesHandler = historyEntriesHandler;
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

        [Route("history")]
        [HttpGet]
        public IActionResult GetHistory([FromQuery] string from, [FromQuery] string to)
        {
            if (!DateTime.TryParseExact(from, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var fromDate))
                return BadRequest("Invalid 'from' date format. Use yyyy-MM-dd.");

            if (!DateTime.TryParseExact(to, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var toDate))
                return BadRequest("Invalid 'to' date format. Use yyyy-MM-dd.");

            var historyEntry = _historyEntriesHandler.Handle(fromDate, toDate);
            return Ok(historyEntry);
        }
    }
}
