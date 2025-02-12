namespace Access.AppCore.Entities;

public class Facture
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public string Numero { get; set; } = null!;

    public DateOnly Date { get; set; }

    public decimal MontantHt { get; set; }

    public decimal MontantTva { get; set; }

    public decimal MontantTpf { get; set; }

    public decimal MontantTtc { get; set; }

    public DateTime CreationLe { get; set; }

    public string CreationPar { get; set; } = null!;

    public DateTime? ModificationLe { get; set; }

    public string? ModificationPar { get; set; }

    public int FactureStatutId { get; set; }
}
