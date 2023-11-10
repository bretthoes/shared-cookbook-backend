using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedCookbookBackend.Data;
using SharedCookbookBackend.Models;
using SharedCookbookBackend.Services;

namespace SharedCookbookBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookbooksController : ControllerBase
    {
        private readonly ICookbookService _cookbookService;

        public CookbooksController(ICookbookService cookbookService)
        {
            _cookbookService = cookbookService;
        }

        // GET: api/Cookbooks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cookbook>>> GetCookbooks()
        {
            var cookbooks = await _cookbookService.GetCookbooks();

            if (cookbooks == null || !cookbooks.Any())
            {
                return NotFound();
            }
            return cookbooks;
        }

        // GET: api/Cookbooks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cookbook>> GetCookbook(int id)
        {
            var cookbook = await _cookbookService.GetCookbook(id);

            if (cookbook == null)
            {
                return NotFound();
            }

            return cookbook;
        }

        // GET: api/Cookbooks/ByPersonId/{personId}
        [HttpGet("ByPerson/{personId}")]
        public async Task<ActionResult<IEnumerable<Cookbook>>> GetCookbooksByPersonId(int personId)
        {
            var cookbooks = await _cookbookService.GetCookbooksByPersonId(personId);

            if (cookbooks == null || !cookbooks.Any())
            {
                return NotFound();
            }

            return cookbooks;
        }



        // PUT: api/Cookbooks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookbook(int id, Cookbook cookbook)
        {
            if (id != cookbook.CookbookId)
            {
                return BadRequest();
            }

            bool updated = await _cookbookService.UpdateCookbook(id, cookbook);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }


        // POST: api/Cookbooks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cookbook>> PostCookbook(Cookbook cookbook)
        {
            await _cookbookService.CreateCookbook(cookbook);
            return CreatedAtAction("GetCookbook", new { id = cookbook.CookbookId }, cookbook);
        }

        // DELETE: api/Cookbooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookbook(int id)
        {
            await _cookbookService.DeleteCookbook(id);
            return NoContent();
        }
    }
}
