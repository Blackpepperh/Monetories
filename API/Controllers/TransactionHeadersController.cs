using Application.TransactionHeaders;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TransactionHeadersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TransactionHeader>>> GetTransactionHeaders()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionHeader(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { TransactionHeaderId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactionHeader(TransactionHeader transactionHeader)
        {
            return HandleResult(await Mediator.Send(new Create.Command { TransactionHeader = transactionHeader }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTransactionHeader(Guid id, TransactionHeader transactionHeader)
        {
            transactionHeader.TransactionHeaderId = id;

            return HandleResult(await Mediator.Send(new Edit.Command { TransactionHeader = transactionHeader }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionHeader(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { TransactionHeaderId = id }));
        }
    }
}