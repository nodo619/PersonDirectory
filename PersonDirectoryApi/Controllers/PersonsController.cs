using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Localization;
using PersonDirectoryApi.Controllers.ActionFilters;
using PersonDirectoryApi.Controllers.Resources;
using PersonDirectoryApi.Models;
using PersonDirectoryApi.Persistence;
using PersonDirectoryApi.Resources;

namespace PersonDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPersonRepository personRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public PersonsDbContext Context { get; }
        public IUnitOfWork UnitOfWork { get; }

        public PersonsController(IMapper mapper,
            PersonsDbContext context,
            IPersonRepository personRepository,
            IUnitOfWork unitOfWork,
            IWebHostEnvironment hostingEnvironment
            )
        {
            this.mapper = mapper;
            Context = context;
            this.personRepository = personRepository;
            UnitOfWork = unitOfWork;
            this.hostingEnvironment = hostingEnvironment;
        }


        //[ServiceFilter(typeof(ValidationActionFilter))]
        //[HttpPost("test")]
        //public async Task<ActionResult<PersonResource>> Test(PersonResource pr)
        //{
        //    var mappedPerson = mapper.Map<Person>(pr);
        //    await personRepository.CreatePerson(mappedPerson);
        //    await UnitOfWork.CompleteAsync();


        //    return Ok();
        //}

        [HttpPost("[action]")]
        public async Task<ActionResult<PersonResource>> AddRelated(RelatedPersonAddResource rp)
        {

            await personRepository.AddRelatedPerson(rp.SourcePersonId, rp.RelatedPersonId, rp.RelationType);
            await UnitOfWork.CompleteAsync();

            return Ok();
        }
        [HttpDelete("[action]")]
        public async Task<ActionResult<PersonResource>> RemoveRelated(RelatedPersonRemoveResource rp)
        {

            await personRepository.RemoveRelatedPerson(rp.SourcePersonId, rp.RelatedPersonId);
            await UnitOfWork.CompleteAsync();

            return Ok();
        }

        [HttpDelete("[action]")]
        public async Task<ActionResult<PersonResource>> RemovePerson(int id)
        {
            var person = await personRepository.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }

            await personRepository.RemovePerson(person);
            await UnitOfWork.CompleteAsync();

            return Ok();
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<PersonResource>> CreatePerson(PersonResource pr)
        {
            var mappedPerson = mapper.Map<Person>(pr);
            await personRepository.CreatePerson(mappedPerson);
            await UnitOfWork.CompleteAsync();


            return Ok();
        }
        [HttpPut("[action]")]
        public async Task<ActionResult<PersonResource>> UpdatePerson(int id, PersonResource pr)
        {
            var person = await personRepository.GetPersonFullData(id);

            if (person == null)
            {
                return NotFound();
            }

            mapper.Map<PersonResource, Person>(pr, person);
            await UnitOfWork.CompleteAsync();


            return Ok();
        }

        [HttpGet("[action]")] 
        public async Task<ActionResult<PersonResourceWithPhotoBytes>> GetPerson(int id)
        {
            var person = await personRepository.GetPersonFullData(id);

            if(person == null)
            {
                return NotFound();
            }
            
            var mappedPerson = mapper.Map<PersonResource>(person);

            var file = await personRepository.GetFile(mappedPerson.PhotoFilePath);

            var result = new PersonResourceWithPhotoBytes
            {
                PersonResource = mappedPerson,
                PhotoBytes = file
            };

            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<PersonResource>>> GetPersonsQuick([FromQuery] QuickFilterResource filterResource)
        {
            var mappedFilter = mapper.Map<QuickFilterResource, Filter>(filterResource);
            var persons = await personRepository.GetPersons(mappedFilter);

            var personResources = mapper.Map<IEnumerable<Person>, IEnumerable<PersonResource>>(persons);

            return Ok(personResources);
        }
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<PersonResource>>> GetPersonsAdvanced([FromQuery] FilterResource filterResource)
        {
            var mappedFilter = mapper.Map<FilterResource, Filter>(filterResource);
            var persons = await personRepository.GetPersonsAdvanced(mappedFilter);

            var personResources = mapper.Map<IEnumerable<Person>, IEnumerable<PersonResource>>(persons);

            return Ok(personResources);
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<int>> GetRelationsCount(int personId, int relationType)
        {
            var count = await personRepository.GetRelationsCount(personId, relationType);


            return Ok(count);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadPhoto(int personId, IFormFile file)
        {
            var person = await personRepository.GetPersonFullData(personId);

            if (person == null)
            {
                return NotFound();
            }

            var directoryPath = Path.Combine(hostingEnvironment.ContentRootPath, "photos");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var filePath = Path.Combine(directoryPath, file.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);

            await file.CopyToAsync(stream);

            person.PhotoFilePath = $"photos/{file.FileName}";

            await UnitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
