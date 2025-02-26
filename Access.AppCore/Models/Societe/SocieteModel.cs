using System.ComponentModel.DataAnnotations;

namespace Access.AppCore.Models.Societe
{
    public class SocieteModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RaisonSocial { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string MatriculeFiscale { get; set; } = null!;

        [StringLength(100)]
        public string? RegistreCommerce { get; set; }

        [Required]
        [StringLength(100)]
        public string Activite { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string NomCommercial { get; set; } = null!;

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
        [EmailAddress]
        [StringLength(100)]
        public string AdresseMail { get; set; } = null!;

        [Required]
        [RegularExpression(@"^\d{8,15}$")]
        public string Telephone { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Secteur { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string PremierResponsable { get; set; } = null!;
    }
}
