namespace PersonDirectoryApi.Controllers.Resources
{
    public class PersonResourceWithPhotoBytes
    {
        public PersonResource PersonResource { get; set; }

        public byte[]? PhotoBytes { get; set; }
    }
}
