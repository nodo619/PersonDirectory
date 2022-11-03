using PersonDirectoryApi.Enums;

namespace PersonDirectoryApi.Controllers.Resources
{
    public class FilterResource
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalIdNumber { get; set; }

        public int? BirthYear { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthDay { get; set; }

        public int? CityId { get; set; }

        public string? PhoneNumber { get; set; }

        public Gender? Gender { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
