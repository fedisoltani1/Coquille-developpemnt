using System.ComponentModel.DataAnnotations;
using Access.AppCore.Entities;

namespace Access.AppCore.Models.SocieteAgence
{
    public class SocieteAgenceModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Intitule { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Gouvernorat { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Ville { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Adresse { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{4,5}$")]
        public string CodePostal { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{8,15}$")]
        public string Telephone { get; set; } = null!;

        [EmailAddress]
        [StringLength(100)]
        public string? AdresseMail { get; set; }

        [Required]
        [StringLength(100)]
        public string ResponsableName { get; set; } = null!;

        [Required]
        [StringLength(15)]
        public string ResponsableTel { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string ResponsableEmail { get; set; } = null!;

        public bool IsActif { get; set; }

        [StringLength(100)]
        public string? MatriculeFiscale { get; set; }

        public ICollection<Collaborateur> Collaborateurs { get; set; } = new List<Collaborateur>();
    }

}