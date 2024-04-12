using Application.TransactionDetails;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TransactionDetailsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<TransactionDetail>>> GetTransactionDetails()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionDetail(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { TransactionDetailId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransactionDetail(TransactionDetail transactionDetail)
        {
            return HandleResult(await Mediator.Send(new Create.Command { TransactionDetail = transactionDetail }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditTransactionDetail(Guid id, TransactionDetail transactionDetail)
        {
            transactionDetail.TransactionDetailId = id;

            return HandleResult(await Mediator.Send(new Edit.Command { TransactionDetail = transactionDetail }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionDetail(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { TransactionDetailId = id }));
        }
    }
}