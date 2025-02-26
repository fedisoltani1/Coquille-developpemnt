namespace Access.AppCore.Entities;

public class FactureLigne : Bases.EntiteBase<int> 
{
    public int FactureId { get; set; }

    public int FactureArticleId { get; set; }

    public string FactureArticleIntitule { get; set; } = null!;

    public decimal FactureArticlePuHt { get; set; }

    public decimal FactureArticlePuTtc { get; set; }

    public int Quantite { get; set; }

    public decimal MontantHt { get; set; }

    public int TaxeId { get; set; }

    public decimal TaxeTaux { get; set; }

    public decimal MontantTva { get; set; }

    public decimal MontantTtc { get; set; }
}
