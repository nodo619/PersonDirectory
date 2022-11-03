using Microsoft.VisualBasic;
using PersonDirectoryApi.Enums;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectoryApi.Models
{
    public class Person
    {
        public Person()
        {
            PhoneNumbers = new Collection<PhoneNumber>();
            ConnectedPersons = new Collection<PersonToPerson>();
            ConnectionOfPersons = new Collection<PersonToPerson>(); 
        }


        public int Id { get; set; }
        [Required(ErrorMessage ="First Name is required")]
        [MinLength(2, ErrorMessage = "First Name Too short")]
        [MaxLength(50, ErrorMessage = "First Name Too long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(2, ErrorMessage = "Last Name Too short")]
        [MaxLength(50, ErrorMessage = "Last Name Too long")]
        public string LastName { get; set; }

        [Range(0,1)]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "PIN is required")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "PIN should be 11 characters")]
        public string PersonalIdNumber { get; set; }

        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime BirthDate { get; set; }

        public int? CityId { get; set; }

        public City? City { get; set; }

        public ICollection<PhoneNumber> PhoneNumbers { get; set; }

        public string PhotoFilePath { get; set; }

        public ICollection<PersonToPerson> ConnectedPersons { get; set; }

        public ICollection<PersonToPerson> ConnectionOfPersons { get; set; }
    }
}
