using Application.Currencies;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CurrenciesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Currency>>> GetCurrencies()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrency(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { CurrencyId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurrency(Currency currency)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Currency = currency }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCurrency(Guid id, Currency currency)
        {
            currency.CurrencyId = id;

            return HandleResult(await Mediator.Send(new Edit.Command { Currency = currency }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { CurrencyId = id }));
        }
    }
}