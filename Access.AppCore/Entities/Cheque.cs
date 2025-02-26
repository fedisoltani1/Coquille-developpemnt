using System.ComponentModel.DataAnnotations.Schema;

namespace Access.AppCore.Entities;

public class Cheque : Bases.EntiteBase<int>
{
    public int ChequierId { get; set; }

    public virtual Chequier Chequier { get; set; } = null!;

    public int BanqueId { get; set; }

    public virtual Banque Banque { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public bool IsActif { get; set; }

    public int ChequeStatutId { get; set; }

    public virtual ChequeStatut ChequeStatut { get; set; } = null!;

    [NotMapped]
    public string IsActif_value => IsActif ? "Actif" : "Inactif";
}
