namespace Access.AppCore.Entities;

public class Paiement
{
    public int Id { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int ClientId { get; set; }

    public string ClientCode { get; set; } = null!;

    public string ClientIntitule { get; set; } = null!;

    public decimal Montant { get; set; }

    public int NombreCommande { get; set; }

    public int PaiementStatutId { get; set; }

    public string? PaiementStatutIntitule { get; set; }

    public DateTime CreationLe { get; set; }

    public string? CreationPar { get; set; }

    public DateTime ModificationLe { get; set; }

    public string? ModificationPar { get; set; }

    public int ModeReglementPaiementId { get; set; }

    public string ModeReglementPaiementIntitule { get; set; } = null!;

    public int? BanqueId { get; set; }

    public string? BanqueIntitule { get; set; }

    public int? ChequierId { get; set; }

    public int? ChequeId { get; set; }

    public string? ChequeNumero { get; set; }

    public string? ClientRib { get; set; }

    public string? NumeroTransaction { get; set; }

    public string? Commentaire { get; set; }
}
