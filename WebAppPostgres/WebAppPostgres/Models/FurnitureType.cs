using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPostgres.Models
{
    public class FurnitureType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FurnitureTypeID { get; set; }
     
        public string? FurnitureTypeName { get; set; }
    }
}
