using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using PersonDirectoryApi.Controllers.ActionFilters;
using PersonDirectoryApi.Controllers.Resources;
using PersonDirectoryApi.Models;
using PersonDirectoryApi.Persistence;
using PersonDirectoryApi.Resources;
using System.Collections.Generic;

namespace PersonDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPersonRepository personRepository;
        private readonly IStringLocalizer<SharedResource> stringLocalizer;

        public TestController(IMapper mapper, PersonsDbContext context, IPersonRepository personRepository, IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this.mapper = mapper;
            Context = context;
            this.personRepository = personRepository;
            UnitOfWork = unitOfWork;
            this.stringLocalizer = stringLocalizer;
        }

        public PersonsDbContext Context { get; }
        public IUnitOfWork UnitOfWork { get; }

        //[HttpGet("test2")]
        //public async Task<ActionResult<PersonResource>> Test2()
        //{
        //    //Context.Persons.Add(new Models.Person
        //    //{
        //    //    FirstName = "testUser",
        //    //    LastName = "testuser",
        //    //    BirthDate = new DateTime(1993, 8, 10),
        //    //    CityId = 1,
        //    //    Gender = 0,
        //    //    PersonalIdNumber = "01011087586",
        //    //    PhotoFilePath = "patht1"
        //    //});
        //    //Context.Persons.Add(new Models.Person
        //    //{
        //    //    FirstName = "testUser 3",
        //    //    LastName = "testuser 3",
        //    //    BirthDate = new DateTime(1993, 8, 10),
        //    //    CityId = 1,
        //    //    Gender = 0,
        //    //    PersonalIdNumber = "01011087587",
        //    //    PhotoFilePath = "patht2"
        //    //});
        //    //Context.Persons.Add(new Models.Person
        //    //{
        //    //    FirstName = "testUser 4",
        //    //    LastName = "testuser 4",
        //    //    BirthDate = new DateTime(1993, 8, 10),
        //    //    CityId = 1,
        //    //    Gender = 0,
        //    //    PersonalIdNumber = "01011087587",
        //    //    PhotoFilePath = "patht2"
        //    //});
        //    //Context.SaveChanges();


        //    var persons = Context.Persons.Include(a => a.ConnectedPersons).ToList();
        //    //foreach (var item in persons)
        //    //{
        //    //    item.ConnectedPersons.Clear();
        //    //    item.ConnectionOfPersons.Clear();
        //    //}
        //    //Context.SaveChanges();

        //    var person = Context.Persons.FirstOrDefault();
        //    var person2 = Context.Persons.Skip(1).FirstOrDefault();
        //    var person3 = Context.Persons.Skip(2).FirstOrDefault();
        //    var person4 = Context.Persons.Skip(3).FirstOrDefault();

        //    person.PhoneNumbers.Add(new PhoneNumber
        //    {
        //        PhoneNumberValue = "123123",
        //        PhoneType = Enums.PhoneNumberType.Home
        //    });
        //    person.PhoneNumbers.Add(new PhoneNumber
        //    {
        //        PhoneNumberValue = "456456",
        //        PhoneType = Enums.PhoneNumberType.Mobile
        //    });
        //    Context.SaveChanges();

        //    //Context.Persons.Remove(person);
        //    //Context.SaveChanges();
        //    //Context.Persons.Remove(person4);
        //    //Context.SaveChanges();
        //    person.ConnectedPersons.Add(new PersonToPerson
        //    {
        //        ConnectionType = Enums.PersonConnectionType.Colleague,
        //        RelatedPerson = person2
        //    });
        //    person3.ConnectedPersons.Add(new PersonToPerson
        //    {
        //        ConnectionType = Enums.PersonConnectionType.Colleague,
        //        RelatedPerson = person4
        //    });
        //    Context.SaveChanges();

        //    return Ok();
        //}

        //[ServiceFilter(typeof(ValidationActionFilter))]
        //[HttpPost("test")]
        //public async Task<ActionResult<PersonResource>> Test(PersonResource pr)//
        //{
        //    var mappedPerson = mapper.Map<Person>(pr);
        //    personRepository.CreatePerson(mappedPerson);
        //    await UnitOfWork.CompleteAsync();



        //    //var r = stringLocalizer["Required"];
        //    //if (ModelState.IsValid)
        //    //{

        //    //}


        //    //var persons = Context.Persons
        //    //    .Include(a => a.ConnectedPersons)
        //    //    .Include(s => s.PhoneNumbers)
        //    //    .ToList();
        //    //var mapped = mapper.Map<List<PersonResource>>(persons);

        //    //var reverseMapped = mapper.Map<List<Person>>(mapped);

        //    return Ok();
        //}

        //[HttpPost("[action]")]
        //public async Task<ActionResult<PersonResource>> AddRelated(RelatedPersonAddResource rp)
        //{
           
        //    personRepository.AddRelatedPerson(rp.SourcePersonId, rp.RelatedPersonId, rp.RelationType);
        //    await UnitOfWork.CompleteAsync();

        //    return Ok();
        //}
        //[HttpPost("[action]")]
        //public async Task<ActionResult<PersonResource>> RemoveRelated(RelatedPersonRemoveResource rp)
        //{

        //    personRepository.RemoveRelatedPerson(rp.SourcePersonId, rp.RelatedPersonId);
        //    await UnitOfWork.CompleteAsync();

        //    return Ok();
        //}

        //[HttpPost("[action]")]
        //public async Task<ActionResult<PersonResource>> RemovePerson(int id)
        //{
        //    personRepository.RemovePerson(id);
        //    await UnitOfWork.CompleteAsync();

        //    return Ok();
        //}


        //[HttpPost("[action]")]
        //public async Task<ActionResult<PersonResource>> CreatePerson(PersonResource pr)//
        //{
        //    var mappedPerson = mapper.Map<Person>(pr);
        //    personRepository.CreatePerson(mappedPerson);
        //    await UnitOfWork.CompleteAsync();



        //    //var r = stringLocalizer["Required"];
        //    //if (ModelState.IsValid)
        //    //{

        //    //}


        //    //var persons = Context.Persons
        //    //    .Include(a => a.ConnectedPersons)
        //    //    .Include(s => s.PhoneNumbers)
        //    //    .ToList();
        //    //var mapped = mapper.Map<List<PersonResource>>(persons);

        //    //var reverseMapped = mapper.Map<List<Person>>(mapped);

        //    return Ok();
        //}
        //[HttpPut("[action]/{id}")]
        //public async Task<ActionResult<PersonResource>> UpdatePerson(int id, PersonResource pr)//
        //{
        //    var person = await personRepository.GetPersonFullData(id);
        //    mapper.Map<PersonResource, Person>(pr, person);
        //    await UnitOfWork.CompleteAsync();




        //    return Ok();
        //}

        //[HttpGet("[action]")] // ფოტო გასაკეთებელია
        //public async Task<ActionResult<PersonResource>> GetPerson(int id)
        //{
        //    var person = personRepository.GetPersonFullData(id);

        //    var mappedPerson = mapper.Map<PersonResource>(person);

        //    return Ok(mappedPerson);
        //}

        //[HttpGet("[action]")]
        //public async Task<ActionResult<IEnumerable<PersonResource>>> GetPersonsQuick([FromQuery]QuickFilterResource filterResource)
        //{
        //    var mappedFilter = mapper.Map<QuickFilterResource, Filter>(filterResource);
        //    var persons = await personRepository.GetPersons(mappedFilter);

        //    var personResources = mapper.Map<IEnumerable<Person>, IEnumerable<PersonResource>>(persons);

        //    return Ok(personResources);
        //}
        //[HttpGet("[action]")]
        //public async Task<ActionResult<IEnumerable<PersonResource>>> GetPersonsAdvanced([FromQuery] FilterResource filterResource)
        //{
        //    var mappedFilter = mapper.Map<FilterResource, Filter>(filterResource);
        //    var persons = await personRepository.GetPersonsAdvanced(mappedFilter);

        //    var personResources = mapper.Map<IEnumerable<Person>, IEnumerable<PersonResource>>(persons);

        //    return Ok(personResources);
        //}

        //[HttpGet("[action]")]
        //public async Task<ActionResult<int>> GetRelationsCount(int personId, int relationType)
        //{
        //    var count = await personRepository.GetRelationsCount(personId, relationType);


        //    return Ok(count);
        //}
    }


}
