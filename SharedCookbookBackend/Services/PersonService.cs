using Microsoft.EntityFrameworkCore;
using SharedCookbookBackend.Data;
using SharedCookbookBackend.Models;
using System;

namespace SharedCookbookBackend.Services
{
    public class PersonService : IPersonService
    {

        private readonly SharedCookbookContext _context;

        public PersonService(SharedCookbookContext context)
        {
            _context = context;
        }

        #region Create

        public async Task<Person> CreatePerson(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        #endregion Create

        #region Read

        public async Task<Person> GetPerson(int id)
        {
            return await _context.People.FindAsync(id);
        }

        #endregion Read

        #region Update

        public async Task<bool> UpdatePerson(int id, Person person)
        {
            if (id != person.PersonId)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true; // Update was successful
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    throw new KeyNotFoundException("Person not found");
                }
                else
                {
                    throw;
                }
            }
            catch (Exception)
            {
                return false; // Update failed
            }
        }

        #endregion Update

        #region Delete

        public async Task DeletePerson(int id)
        {
            var person = await _context.People.FindAsync(id);
            if (person == null)
            {
                throw new KeyNotFoundException("Person not found");
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();
        }

        #endregion Delete

        #region Helper

        public bool PersonExists(int id)
        {
            return _context.People.Any(e => e.PersonId == id);
        }

        #endregion Helper
    }
}
