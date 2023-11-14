using SharedCookbookBackend.Models;

namespace SharedCookbookBackend.Services
{
    public interface ICookbookService
    {
        Task<List<Cookbook>> GetCookbooks();
        Task<Cookbook> GetCookbook(int id);
        Task<List<Cookbook>> GetCookbooksForPerson(int personId);
        Task<bool> UpdateCookbook(int id, Cookbook cookbook);
        Task<Cookbook> CreateCookbook(Cookbook cookbook);
        Task DeleteCookbook(int id);
        bool CookbookExists(int id);
        Task<List<CookbookInvitation>> GetInvitationsForPerson(int personId);
    }
}
