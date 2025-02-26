namespace Access.AppCore.Entities;

public class Taxe : Bases.EntiteBase<int>
{
    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public decimal Valeur { get; set; }

    public int TaxeTypeId { get; set; }

    public bool IsActif { get; set; }

    public virtual TaxeType TaxeType { get; set; } = null!;
}
