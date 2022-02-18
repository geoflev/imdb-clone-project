using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using IMDBClone.Application.Features;
using System.Threading.Tasks;
using IMDBClone.Application.Features.Categories;

namespace IMDB_Clone_API.Controllers
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

        [HttpPost()]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoryDto))]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForm form)
        {
            var category = await Mediator.Send(new CreateCategoryCommand(form));
            return Ok(category);
        }
    }
}
