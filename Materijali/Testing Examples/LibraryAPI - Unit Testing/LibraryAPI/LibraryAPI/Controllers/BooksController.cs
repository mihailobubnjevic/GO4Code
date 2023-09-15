using LibraryAPI.DTOs;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _service;
        public BooksController(IBooksService service) 
        {
            _service = service;
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksGetDetailsResponse>>> Get()
        {
            var result = await _service.GetAsync();
            return Ok(result);
        }

        [Authorize(Roles = Roles.User)]
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksGetDetailsResponse>> GetDetails(int id)
        {
            var result = await _service.GetDetailsAsync(id);

            return result is null ? NotFound() : Ok(result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public async Task<ActionResult<BooksGetDetailsResponse>> Post(BooksCreateRequest book)
        {
            var result = await _service.CreateAsync(book);

            return CreatedAtAction(nameof(GetDetails), new { id = result.Id }, result);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            return result == false ? NotFound() : NoContent();
        }
    }
}
