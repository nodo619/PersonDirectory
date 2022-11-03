using PersonDirectoryApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectoryApi.Models
{
    public class PhoneNumber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0,2)]
        public PhoneNumberType PhoneType { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Phone number too short")]
        [MaxLength(50, ErrorMessage = "Phone number too long")]
        public string PhoneNumberValue { get; set; }

        public Person Person { get; set; }
    }
}
