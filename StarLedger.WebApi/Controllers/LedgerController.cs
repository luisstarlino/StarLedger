using Microsoft.AspNetCore.Mvc;
using StarLedger.Application.UseCases;

namespace StarLedger.WebApi.Controllers
{
    [ApiController]
    [Route("ledger")]
    public class LedgerController : ControllerBase
    {
        private readonly AddEntryUseCase _useCase;

        public LedgerController(AddEntryUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost("entry")]
        public IActionResult Add(AddEntryInput input)
        {
            var result = _useCase.Execute(input);
            return Ok(result);
        }
    }
}
