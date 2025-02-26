using System.ComponentModel.DataAnnotations;

namespace Access.Web.Modeles.Societe
{
    public class SocieteViewModel
    {
        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Required(ErrorMessage = "La raison sociale est obligatoire.")]
        [StringLength(100, ErrorMessage = "La raison sociale ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Raison Sociale")]
        public string RaisonSocial { get; set; } = null!;

        [Required(ErrorMessage = "Le matricule fiscal est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le matricule fiscal ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Matricule fiscale")]
        public string MatriculeFiscale { get; set; } = null!;

        [StringLength(100, ErrorMessage = "Le registre de commerce ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Registre commerce")]
        public string? RegistreCommerce { get; set; }

        [Required(ErrorMessage = "L'activité est obligatoire.")]
        [StringLength(100, ErrorMessage = "L'activité ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Activité")]
        public string Activite { get; set; } = null!;

        [Required(ErrorMessage = "Le nom commercial est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom commercial ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Nom commercial")]
        public string NomCommercial { get; set; } = null!;

        [Required(ErrorMessage = "Le gouvernorat est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le gouvernorat ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Gouvernorat")]
        public string Gouvernorat { get; set; } = null!;

        [Required(ErrorMessage = "La ville est obligatoire.")]
        [StringLength(100, ErrorMessage = "La ville ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Ville")]
        public string Ville { get; set; } = null!;

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        [StringLength(200, ErrorMessage = "L'adresse ne doit pas dépasser 200 caractères.")]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; } = null!;

        [Required(ErrorMessage = "Le code postal est obligatoire.")]
        [RegularExpression(@"^\d{4,5}$", ErrorMessage = "Le code postal doit être composé de 4 ou 5 chiffres.")]
        [Display(Name = "Code postal")]
        public string CodePostal { get; set; } = null!;

        [Required(ErrorMessage = "L'adresse e-mail est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        [StringLength(100, ErrorMessage = "L'adresse e-mail ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Adresse Email")]
        public string AdresseMail { get; set; } = null!;

        [Required(ErrorMessage = "Le téléphone est obligatoire.")]
        [RegularExpression(@"^\d{8,15}$", ErrorMessage = "Le numéro de téléphone doit comporter entre 8 et 15 chiffres.")]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; } = null!;

        [Required(ErrorMessage = "Le secteur est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le secteur ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Secteur")]
        public string Secteur { get; set; } = null!;

        [Required(ErrorMessage = "Le nom du responsable est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom du responsable ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Responsable")]
        public string PremierResponsable { get; set; } = null!;
    }
}
