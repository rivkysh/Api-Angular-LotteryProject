using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace exe1.Models
{
    public class Prize
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "שם הפרס הוא שדה חובה")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public ICollection<Basket>? Owners { get; set; }
        
        [ForeignKey("Donor")]
        public int DonorId { get; set; }
        [JsonIgnore]
        public Donor? Donor { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public Category? Category { get; set; }

        public string? ImgUrl { get; set; }

        public int PurchacesAmount { get; set; }

        public User? Thewinner { get; set; } = null;

       public bool IsActive { get; set; } = true;

        public int quantity {  get; set; }= 1;

        public bool Islottered { get; set; } = false;

        public bool IsBought { get; set; } = false;

    }
}