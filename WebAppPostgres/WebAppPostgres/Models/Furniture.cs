using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPostgres.Models
{
    public class Furniture
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FurnitureId { get; set; }
        [StringLength(250)]
        public string? FurnitureName { get; set; }
        public string? Brand { get; set; }
        public decimal Cost { get; set; }
        public int FurnitureTypeID { get; set; }
        [NotMapped]
        public string? FurnitureTypeName { get; set; }

    }
}
