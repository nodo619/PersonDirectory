using AutoMapper;
using PersonDirectoryApi.Controllers.Resources;
using PersonDirectoryApi.Models;

namespace PersonDirectoryApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //out
            CreateMap<Person, PersonResource>();
            CreateMap<PhoneNumber, PhoneNumberResource>();
            CreateMap<PersonToPerson, RelatedPersonResource>();
            CreateMap<City, CityResource>();

            //in
            CreateMap<PersonResource, Person>();
            CreateMap<PhoneNumberResource, PhoneNumber>();
            CreateMap<RelatedPersonResource, PersonToPerson>();
            

            CreateMap<QuickFilterResource, Filter>();
            CreateMap<FilterResource, Filter>();
        }
    }
}
