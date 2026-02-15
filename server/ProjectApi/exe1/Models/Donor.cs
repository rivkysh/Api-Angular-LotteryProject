namespace exe1.Models
{
    public class Donor
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public ICollection<Prize>? prizes { get; set; }
        public bool IsActive { get; set; }=true;

    }
}