using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionTicketP6.Models
{
    public class Compatibilite
    {
        [Key]
        public int Id { get; set; } 

        public int IdVersion { get; set; } // Clé étrangère vers Version
        [ForeignKey(nameof(IdVersion))]
        public ProductVersion? Version { get; set; }

        public int IdOs { get; set; } // Clé étrangère vers Système_Exploitation
        [ForeignKey(nameof(IdOs))]
        public SystemeExploitation? SystemeExploitation { get; set; }
    }
}
