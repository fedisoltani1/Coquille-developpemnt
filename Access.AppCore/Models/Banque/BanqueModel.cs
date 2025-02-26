using System.ComponentModel.DataAnnotations;
using Access.AppCore.Entities;

namespace Access.AppCore.Models.Banque
{
    public class BanqueModel
    {
        public BanqueModel()
        {
            Chequiers = new HashSet<Chequier>();
            Cheques = new HashSet<Cheque>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Code { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string Intitule { get; set; } = null!;

        public bool IsActif { get; set; } = true;

        public virtual ICollection<Chequier> Chequiers { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }
    }
}
