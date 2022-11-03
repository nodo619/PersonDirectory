using PersonDirectoryApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectoryApi.Models
{
    public class PersonToPerson
    {

        public int SourcePersonId { get; set; }

        public int? RelatedPersonId { get; set; }

        public Person SourcePerson { get; set; }

        public Person? RelatedPerson { get; set; }


        [Required]
        [Range(0, 3)]
        public PersonConnectionType ConnectionType { get; set; }
    }
}
