using PersonDirectoryApi.Enums;
using PersonDirectoryApi.Models;
using PersonDirectoryApi.Resources;
using PersonDirectoryApi.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectoryApi.Controllers.Resources
{
    public class PersonResource
    {
        public PersonResource()
        {
            PhoneNumbers = new Collection<PhoneNumberResource>();
            ConnectedPersons = new Collection<RelatedPersonResource>();
        }


        //[IsNotMixedLanguage]
        //[IsOnlyLatinOrGeorgian]
        //[Required(ErrorMessageResourceName ="Required", ErrorMessageResourceType = typeof(SharedResource))]
        //[MinLength(2, ErrorMessageResourceName = "NameTooshort", ErrorMessageResourceType = typeof(SharedResource))]
        //[MaxLength(50, ErrorMessageResourceName = "NameTooLong", ErrorMessageResourceType = typeof(SharedResource))]
        public string FirstName { get; set; }

        //[IsNotMixedLanguage]
        //[IsOnlyLatinOrGeorgian]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        //[MinLength(2, ErrorMessageResourceName = "NameTooshort", ErrorMessageResourceType = typeof(SharedResource))]
        //[MaxLength(50, ErrorMessageResourceName = "NameTooLong", ErrorMessageResourceType = typeof(SharedResource))]
        public string LastName { get; set; }

        //[Range(0, 1)]
        public Gender Gender { get; set; }

        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        //[StringLength(11, MinimumLength = 11, ErrorMessageResourceName = "ShouldBe11Characters", ErrorMessageResourceType = typeof(SharedResource))]
        public string PersonalIdNumber { get; set; }

        //[Age18OrOlder]
        //[Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(SharedResource))]
        public DateTime BirthDate { get; set; }

        public int? CityId { get; set; }
        public CityResource City {get; set;}

        public ICollection<PhoneNumberResource>? PhoneNumbers { get; set; }

        public string PhotoFilePath { get; set; }

        public ICollection<RelatedPersonResource>? ConnectedPersons { get; set; }
    }
}
