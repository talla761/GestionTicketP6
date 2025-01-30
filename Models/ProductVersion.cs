using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace GestionTicketP6.Models
{
    public class ProductVersion
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string NumeroVersion { get; set; } = string.Empty;   // Numéro de version

        //public DateTime Date_Lancement { get; set; } // Date de lancement

        // Clé étrangère pour Produit
        public int IdProduit { get; set; }
        [ForeignKey(nameof(IdProduit))]
        public Produit? Produit { get; set; }

        // Relation N-N avec Système_Exploitation via Compatibilité
        public List<Compatibilite>? Compatibilites { get; set; } 

        // Relation 1-N avec Ticket
        public ICollection<Ticket>? Tickets { get; set; } 
    }
}
