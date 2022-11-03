using PersonDirectoryApi.Models;

namespace PersonDirectoryApi.Persistence
{
    public interface IPersonRepository
    {
        Task CreatePerson(Person person);

        Task AddRelatedPerson(int sourceId, int relatedId, int relationType);

        Task RemoveRelatedPerson(int sourceId, int relatedId);

        Task RemovePerson(Person person);

        Task<Person> GetPersonFullData(int id);

        Task<IEnumerable<Person>> GetPersons(Filter filter);

        Task<IEnumerable<Person>> GetPersonsAdvanced(Filter filter);

        Task<int?> GetRelationsCount(int id, int relationType);

        Task<byte[]?> GetFile(string filePath);

        Task<Person> GetPerson(int id);
    }
}
