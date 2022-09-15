using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;
using Newtonsoft.Json;
using InternBA.Features.UserFeatures.Queries;
using InternBA.Features.UserFeatures.Command;

namespace InternBA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories([FromQuery]PageParagram pagination)
        {
            var categories = await mediator.Send(new GetAllCategoriesQuery(pagination));
            var metadata = new
            {
                categories.TotalCount,
                categories.PageSize,
                categories.CurrentPage,
                categories.TotalPages,
                categories.HasNext,
                categories.HasPrevious,
            };
            HttpContext.Response.Headers.Add("Category-Pagination",JsonConvert.SerializeObject(metadata));
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory([FromQuery] GetCategoryByIdQuery query)
        {
         return  Ok(await mediator.Send(query));
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(Guid id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }          

            return Ok(await mediator.Send(command));
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CreateCategoryCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromQuery]DeleteCategoryByIdCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        //Get Attachment  with filters
        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<Category>> GetCategoriesWithFilter([FromQuery] GetCategoryByFilterQuery query)
        {
            return Ok(await mediator.Send(query));
        }

    }
}
