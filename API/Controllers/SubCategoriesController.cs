using Application.SubCategories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class SubCategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<SubCategory>>> GetSubCategories()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(SubCategory SubCategory)
        {
            return HandleResult(await Mediator.Send(new Create.Command { SubCategory = SubCategory }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditSubCategory(Guid id, SubCategory SubCategory)
        {
            SubCategory.Id = id;

            return HandleResult(await Mediator.Send(new Edit.Command { SubCategory = SubCategory }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}