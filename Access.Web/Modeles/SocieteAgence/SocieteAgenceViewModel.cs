using System.ComponentModel.DataAnnotations;
using Access.AppCore.Entities;

namespace Access.Web.Modeles.SocieteAgence
{
    public class SocieteAgenceViewModel
    {
        [Display(Name = "Identifiant")]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'intitulé est obligatoire.")]
        [StringLength(200, ErrorMessage = "L'intitulé ne doit pas dépasser 200 caractères.")]
        [Display(Name = "Intitulé")]
        public string Intitule { get; set; } = null!;

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

        [Required(ErrorMessage = "Le téléphone est obligatoire.")]
        [RegularExpression(@"^\d{8,15}$", ErrorMessage = "Le numéro de téléphone doit comporter entre 8 et 15 chiffres.")]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; } = null!;

        [EmailAddress]
        [StringLength(100, ErrorMessage = "L'adresse e-mail ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Adresse email")]
        public string? AdresseMail { get; set; }

        [StringLength(100, ErrorMessage = "Le matricule fiscal ne doit pas dépasser 100 caractères.")]
        [Display(Name = "Matricule fiscale")]
        public string? MatriculeFiscale { get; set; }

        [Required(ErrorMessage = "Le nom du responsable est obligatoire.")]
        [StringLength(150, ErrorMessage = "Le nom du responsable ne doit pas dépasser 150 caractères.")]
        [Display(Name = "Nom")]
        public string ResponsableName { get; set; } = null!;

        [Required(ErrorMessage = "Le numéro de téléphone du responsable est obligatoire.")]
        [StringLength(15, ErrorMessage = "Le numéro de téléphone ne doit pas dépasser 15 caractères.")]
        [Display(Name = "Téléphone")]
        public string ResponsableTel { get; set; } = null!;

        [Required(ErrorMessage = "L'email du responsable est obligatoire.")]
        [StringLength(150, ErrorMessage = "L'email ne doit pas dépasser 150 caractères.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer une adresse email valide.")]
        [Display(Name = "Email")]
        public string ResponsableEmail { get; set; } = null!;

        [Required]
        [Display(Name = "Statut")]
        public bool IsActif { get; set; } = true;

        public ICollection<Collaborateur> Collaborateurs { get; set; } = new List<Collaborateur>();
    }
}

