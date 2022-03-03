using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using GMDB.Application.Features;
using GMDB.Application.Features.Categories;

namespace GMDB.API.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {

        public IMediator Mediator { get; }
        public CategoriesController(IMediator mediator)
        {
            Mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<CategoryDto>))]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await Mediator.Send(new GetCategoriesQuery());
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoryDto))]
        public async Task<IActionResult> GetSingleCategory([FromRoute] string categoryId)
        {
            var category = await Mediator.Send(new GetSingleCategoryQuery(categoryId));
            return Ok(category);
        }

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoryDto))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForm form)
        {
            var category = await Mediator.Send(new CreateCategoryCommand(form));
            return Ok(category);
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoryDto))]
        public async Task<IActionResult> UpdateCategory([FromRoute] string categoryId, [FromBody] CategoryForm form)
        {
            var category = await Mediator.Send(new UpdateCategoryCommand(categoryId, form));
            return Ok(category);
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteCategory([FromRoute] string categoryId)
        {
            await Mediator.Send(new DeleteCategoryCommand(categoryId));
            return NoContent();
        }
    }
}
