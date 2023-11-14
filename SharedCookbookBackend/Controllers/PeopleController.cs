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
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }


        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var Person = await _personService.GetPerson(id);

            if (Person == null)
            {
                return NotFound();
            }

            return Ok(Person);
        }


        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person Person)
        {
            if (id != Person.PersonId)
            {
                return BadRequest();
            }

            bool updated = await _personService.UpdatePerson(id, Person);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }


        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            await _personService.CreatePerson(person);
            return CreatedAtAction("GetCookbook", new { id = person.PersonId }, person);
        }

        // DELETE: api/Cookbooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookbook(int id)
        {
            var Person = await GetPerson(id);

            if (Person == null)
            {
                return NotFound();
            }

            await _personService.DeletePerson(id);
            return NoContent();
        }
    }
}
