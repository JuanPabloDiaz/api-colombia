namespace api.Models
{
    public class TelevisionChannel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public Uri Url { get; set; }
        public bool IsActive { get; set; }
    }
}
