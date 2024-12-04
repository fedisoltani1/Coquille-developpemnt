using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Access.Web.Modeles.DomaineValeur
{
    public class DomaineValeurViewModel
    {
        public DomaineValeurViewModel()
        {
            Elements = new List<DomaineValeurElementViewModel>();
        }

        [DisplayName("Identifiant")]
        public int Id { get; set; }

        [DisplayName("Code")]
        [Required(ErrorMessage = "Le code domaine est obligatoire")]
        public string Code { get; set; }

        [DisplayName("Description courte")]
        [Required(ErrorMessage = "La description courte est obligatoire")]
        public string DescriptionCourte { get; set; }

        [DisplayName("Description complète")]
        [Required(ErrorMessage = "La description complète est obligatoire")]
        public string DescriptionComplete { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La date saisie n'est pas valide ou n'a pas le format AAAA-MM-JJ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date début")]
        [Required(ErrorMessage = "La date début est obligatoire")]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La date saisie n'est pas valide ou n'a pas le format AAAA-MM-JJ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("Date fin")]
        public DateTime? DateFin { get; set; }

        public List<DomaineValeurElementViewModel> Elements { get; set; }

        [DisplayName("Nombre d'éléments")]
        public int NombreElement { get; set; }
    }
}
