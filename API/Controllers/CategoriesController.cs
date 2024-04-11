using Application.Categories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return HandleResult(await Mediator.Send(new List.Query()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { CategoryId = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Category = category }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(Guid id, Category category)
        {
            category.CategoryId = id;

            return HandleResult(await Mediator.Send(new Edit.Command { Category = category }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { CategoryId = id }));
        }
    }
}