using Microsoft.EntityFrameworkCore;
using SharedCookbookBackend.Data;
using SharedCookbookBackend.Enums;
using SharedCookbookBackend.Models;

namespace SharedCookbookBackend.Services
{
    public class CookbookService : ICookbookService
    {
        private readonly SharedCookbookContext _context;

        public CookbookService(SharedCookbookContext context)
        {
            _context = context;
        }

        public async Task<Cookbook> GetCookbook(int id)
        {
            return await _context.Cookbooks.FindAsync(id);
        }

        public async Task<List<Cookbook>> GetCookbooksForPerson(int personId)
        {
            var cookbooks = await _context.Cookbooks
                .Where(c => _context.CookbookMembers
                        .Any(cm => cm.PersonId == personId && cm.CookbookId == c.CookbookId))
                .ToListAsync(); 

            return cookbooks;
        }

        public async Task<List<CookbookInvitation>> GetInvitationsForPerson(int personId)
        {
            var invitations = await _context.CookbookInvitations
                .Where(ci => ci.RecipientPersonId == personId && ci.CookbookInvitationStatus == CookbookInvitationStatus.Sent)
                .OrderByDescending(ci => ci.CookbookInvitationDate)
                .ToListAsync();

            return invitations;
        }

        public async Task<bool> UpdateCookbook(int id, Cookbook cookbook)
        {
            if (id != cookbook.CookbookId)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(cookbook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true; // Update was successful
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CookbookExists(id))
                {
                    throw new KeyNotFoundException("Cookbook not found");
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


        public async Task<Cookbook> CreateCookbook(Cookbook cookbook)
        {
            _context.Cookbooks.Add(cookbook);
            await _context.SaveChangesAsync();
            return cookbook;
        }

        public async Task DeleteCookbook(int id)
        {
            var cookbook = await _context.Cookbooks.FindAsync(id);
            if (cookbook == null)
            {
                throw new KeyNotFoundException("Cookbook not found");
            }

            _context.Cookbooks.Remove(cookbook);
            await _context.SaveChangesAsync();
        }

        private bool CookbookExists(int id)
        {
            return _context.Cookbooks.Any(e => e.CookbookId == id);
        }
    }
}
