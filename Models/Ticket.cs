using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTicketP6.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateCreation { get; set; } // Date de création
        public DateTime? DateResolution { get; set; } // Date de résolution (nullable)

        [Required]
        [MaxLength(250)]
        public string Statut { get; set; } = string.Empty;         // Statut (en cours/résolu)

        [Required] 
        public string Probleme { get; set; } = string.Empty;       // Description du problème
        public string? Resolution { get; set; }    

        // Clé étrangère vers Version
        public int IdVersion { get; set; }
        [ForeignKey(nameof(IdVersion))]
        public ProductVersion? Version { get; set; }

        // Clé étrangère vers Système_Exploitation
        public int IdOs { get; set; }
        [ForeignKey(nameof(IdOs))]
        public SystemeExploitation? SystemeExploitation { get; set; }
    }
}
