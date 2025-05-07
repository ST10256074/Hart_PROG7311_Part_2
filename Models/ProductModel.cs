using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public float Price { get; set; }
        public float Volume { get; set; }
        public DateTime ListedAt { get; set; }
        public DateTime CreatedAt {  get; set; }

    }
}
