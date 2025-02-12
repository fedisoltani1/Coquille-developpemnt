using System.ComponentModel.DataAnnotations.Schema;

namespace Access.AppCore.Entities;

public class Cheque
{
    public int Id { get; set; }

    // ✅ Foreign key reference to Chequier (chequebook)
    public int ChequierId { get; set; }
    public virtual Chequier Chequier { get; set; } = null!;

    // ✅ Foreign key reference to Banque
    public int BanqueId { get; set; } // Foreign key
    public virtual Banque Banque { get; set; } = null!; // Navigation property

    public string Numero { get; set; } = null!;

    public bool IsActif { get; set; }

    // ✅ Foreign key reference to ChequeStatut
    public int ChequeStatutId { get; set; }
    public virtual ChequeStatut ChequeStatut { get; set; } = null!;

    // ✅ NotMapped calculated property
    [NotMapped]
    public string IsActif_value => IsActif ? "Actif" : "Inactif";
}
