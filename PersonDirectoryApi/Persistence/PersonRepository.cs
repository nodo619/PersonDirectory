using Microsoft.EntityFrameworkCore;
using PersonDirectoryApi.Controllers.Resources;
using PersonDirectoryApi.Models;
using System;

namespace PersonDirectoryApi.Persistence
{
    public class PersonRepository : IPersonRepository
    {
        private readonly PersonsDbContext context;

        public PersonRepository(PersonsDbContext context)
        {
            this.context = context;
        }

        //public async Task<Person> GetPerson(int id) 
        //{
        //    var person = context.Persons
        //        .Include(a => a.ConnectedPersons)
        //        .Include(a => a.PhoneNumbers)
        //        .FirstOrDefault(p => p.Id == id);

        //    return person;
        //}

        public async Task CreatePerson(Person person)
        {
            context.Persons.Add(person);
        }

        public async Task AddRelatedPerson(int sourceId, int relatedId, int relationType)
        {
            var sourcePerson = await context.Persons.SingleOrDefaultAsync(a => a.Id == sourceId);
            var relatedPerson = await context.Persons.SingleOrDefaultAsync(a => a.Id == relatedId);
            
            if (sourcePerson != null && relatedPerson != null && Enum.IsDefined(typeof(Enums.PersonConnectionType), relationType))
            {
                var relationTypEenum = (Enums.PersonConnectionType)relationType;

                sourcePerson.ConnectedPersons.Add(new PersonToPerson
                {
                    ConnectionType = relationTypEenum,
                    SourcePerson = sourcePerson,
                    RelatedPerson = relatedPerson,
                    SourcePersonId = sourceId,
                    RelatedPersonId = relatedId
                });
            }

            
        }

        public async Task RemoveRelatedPerson(int sourceId, int relatedId)
        {
            var sourcePerson = await context.Persons.Include(p => p.ConnectedPersons).SingleOrDefaultAsync(a => a.Id == sourceId);

            if (sourcePerson != null)
            {
                var relation = sourcePerson.ConnectedPersons.SingleOrDefault(a => a.RelatedPersonId == relatedId);
                if(relation != null)
                {
                    sourcePerson.ConnectedPersons.Remove(relation);
                }

            }


        }
        public async Task RemovePerson(Person person)
        {
            if (person != null)
            {
                context.Persons.Remove(person);
            }
        }

        public async Task<Person> GetPerson(int id)
        {
            var person = await context.Persons
                .SingleOrDefaultAsync(a => a.Id == id);
            return person;
        }

        public async Task<Person> GetPersonFullData(int id)
        {
            var person = await context.Persons
                .Include(p => p.ConnectedPersons)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.City)
                .Include("ConnectedPersons.RelatedPerson")
                .SingleOrDefaultAsync(a => a.Id == id);
            return person;
        }

        public async Task<IEnumerable<Person>> GetPersons(Filter filter)
        {
            var personsQuery = context.Persons
                .Include(p => p.ConnectedPersons)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.City)
                .Include("ConnectedPersons.RelatedPerson")
                .AsQueryable();

            if(filter.FirstName != null)
            {
                personsQuery = personsQuery.Where(p => p.FirstName.Contains(filter.FirstName));
            }
            if (filter.LastName != null)
            {
                personsQuery = personsQuery.Where(p => p.FirstName.Contains(filter.LastName));
            }
            if (filter.PersonalIdNumber != null)
            {
                personsQuery = personsQuery.Where(p => p.FirstName.Contains(filter.PersonalIdNumber));
            }
            return await personsQuery.ToListAsync(); 
        }

        public async Task<IEnumerable<Person>> GetPersonsAdvanced(Filter filter)
        {

            
            var personsQuery = context.Persons
                .Include(p => p.ConnectedPersons)
                .Include(p => p.PhoneNumbers)
                .Include(p => p.City)
                .Include("ConnectedPersons.RelatedPerson")
                .AsQueryable();

            if (filter.FirstName != null)
            {
                personsQuery = personsQuery.Where(p => p.FirstName.Contains(filter.FirstName));
            }
            if (filter.LastName != null)
            {
                personsQuery = personsQuery.Where(p => p.FirstName.Contains(filter.LastName));
            }
            if (filter.PersonalIdNumber != null)
            {
                personsQuery = personsQuery.Where(p => p.FirstName.Contains(filter.PersonalIdNumber));
            }
            if (filter.BirthYear != null)
            {
                personsQuery = personsQuery.Where(p => p.BirthDate.Year == filter.BirthYear);
            }
            if (filter.BirthMonth != null)
            {
                personsQuery = personsQuery.Where(p => p.BirthDate.Month == filter.BirthMonth);
            }
            if (filter.BirthDay != null)
            {
                personsQuery = personsQuery.Where(p => p.BirthDate.Day == filter.BirthDay);
            }
            if (filter.CityId != null)
            {
                personsQuery = personsQuery.Where(p => p.CityId == filter.CityId);
            }
            if (filter.Gender != null)
            {
                personsQuery = personsQuery.Where(p => p.Gender == filter.Gender);
            }
            if (filter.PhoneNumber != null)
            {
                personsQuery = personsQuery
                    .Where(p => p.PhoneNumbers
                        .Any(pn => pn.PhoneNumberValue
                            .Contains(filter.PhoneNumber)));
            }
            if(filter.PageSize > 0)
            {
                int toSkip = filter.PageSize * filter.PageNumber - 1;
                personsQuery = personsQuery.Skip(toSkip).Take(filter.PageSize);
            }


            return await personsQuery.ToListAsync();
        }

        public async Task<int?> GetRelationsCount(int id, int relationType)
        {
            if(Enum.IsDefined(typeof(Enums.PersonConnectionType), relationType))
            {
                var relationTypEenum = (Enums.PersonConnectionType)relationType;

                var person = await context.Persons
                .Include(p => p.ConnectedPersons)
                .Include("ConnectedPersons.RelatedPerson")
                .SingleOrDefaultAsync(p => p.Id == id);

                return person.ConnectedPersons.Count(a => a.ConnectionType == relationTypEenum);
            }
            return null;
        }

        public async Task<byte[]?> GetFile(string filePath)
        {
            if (File.Exists(filePath))
            {
               return await File.ReadAllBytesAsync(filePath);
            }
            return default(byte[]);
        }
    }
}
