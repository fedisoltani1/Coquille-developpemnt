using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Access.Web.Modeles.DomaineValeur
{
    public class DomaineValeurElementViewModel
    {
        [DisplayName("Identifiant")]
        public int Id { get; set; }

        [DisplayName("Code domaine de valeurs")]
        [ValidateNever]
        public string CodeDomaineValeur { get; set; }

        [DisplayName("Code élément")]
        [Required(ErrorMessage = "Le code élément est obligatoire")]
        public string Code { get; set; }

        [DisplayName("Description courte")]
        [Required(ErrorMessage = "La description courte est obligatoire")]
        public string DescriptionCourte { get; set; }

        [DisplayName("Description complète")]
        [Required(ErrorMessage = "La description complète est obligatoire")]
        public string DescriptionComplete { get; set; }

        [DisplayName("Ordre d'affichage")]
        [Required(ErrorMessage = "L'ordre d'affichage est obligatoire")]
        public int SequenceAffichage { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La date saisie n'est pas valide ou n'a pas le format AAAA-MM-JJ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date début")]
        [Required(ErrorMessage = "La date début est obligatoire")]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La date saisie n'est pas valide ou n'a pas le format AAAA-MM-JJ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date fin")]
        public DateTime? DateFin { get; set; }

        [ValidateNever]
        public DomaineValeurViewModel DomaineValeur { get; set; }
    }
}
