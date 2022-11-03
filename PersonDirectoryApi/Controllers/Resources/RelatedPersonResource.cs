using PersonDirectoryApi.Enums;
using PersonDirectoryApi.Models;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectoryApi.Controllers.Resources
{
    public class RelatedPersonResource
    {
        public int RelatedPersonId { get; set; }

        public PersonResource RelatedPerson{get;set;}


        [Required]
        [Range(0, 3)]
        public PersonConnectionType ConnectionType { get; set; }
    }
}
