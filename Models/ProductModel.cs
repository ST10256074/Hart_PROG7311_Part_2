using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hart_PROG7311_Part_2.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductModelID { get; set; }

        [ForeignKey("FarmerModelID")]
        public int FarmerId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [AllowNull]
        public IFormFile ImageFile { get; set; }
        public float Price { get; set; }
        public float Volume { get; set; }
        public DateTime ListedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public ProductModel(int FarmerId, string Name, string Category, string Description, string Image, float Price, float Volumne, DateTime ListedAt, DateTime CreatedAt)
        {
            this.FarmerId = FarmerId;
            this.Name = Name;
            this.Category = Category;
            this.Description = Description;
            this.Image = Image;
            this.Price = Price;
            this.Volume = Volumne;
            this.ListedAt = ListedAt;
            this.CreatedAt = CreatedAt;
        }

    }
}
