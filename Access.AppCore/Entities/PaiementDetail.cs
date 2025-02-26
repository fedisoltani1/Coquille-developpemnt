namespace Access.AppCore.Entities;

public class PaiementDetail : Bases.EntiteBase<int>
{
    public int PaiementId { get; set; }

    public string PaiementNumero { get; set; } = null!;

    public int CommandeId { get; set; }

    public string CommandeNumero { get; set; } = null!;

    public decimal Montant { get; set; }
}
