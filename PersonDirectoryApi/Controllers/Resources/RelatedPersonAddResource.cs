namespace PersonDirectoryApi.Controllers.Resources
{
    public class RelatedPersonAddResource
    {
        public int SourcePersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public int RelationType { get; set; }
    }
}
