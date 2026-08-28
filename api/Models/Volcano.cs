namespace api.Models
{
    public class Volcano
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Elevation { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string? VolcanoType { get; set; }
        public string? ActivityLevel { get; set; }
        public string? ImageUrl { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
    }
}
