using SharedCookbookBackend.Models;

namespace SharedCookbookBackend.Services
{
    public interface IPersonService
    {
        Task<Person> GetPerson(int id);
        Task<bool> UpdatePerson(int id, Person Person);
        Task<Person> CreatePerson(Person Person);
        Task DeletePerson(int id);
        bool PersonExists(int id);
    }
}
