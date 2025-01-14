using System.ComponentModel.DataAnnotations;

namespace GestionTicketP6.Models
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Nom { get; set; } = string.Empty;

        // Relation 1-N avec Version
        public ICollection<ProductVersion>? Versions { get; set; } 
    }
}
