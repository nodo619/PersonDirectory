using PersonDirectoryApi.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonDirectoryApi.Controllers.Resources
{
    public class PhoneNumberResource
    {
       
        [Required]
        [Range(0, 2)]
        public PhoneNumberType PhoneType { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "Phone number too short")]
        [MaxLength(50, ErrorMessage = "Phone number too long")]
        public string PhoneNumberValue { get; set; }
    }
}
