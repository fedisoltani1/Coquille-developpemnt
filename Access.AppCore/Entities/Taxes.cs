namespace Access.AppCore.Entities;

public class Taxes
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public decimal Valeur { get; set; }

    public int TaxeTypeId { get; set; }

    public bool IsActif { get; set; }

    public virtual TaxeType TaxeType { get; set; } = null!;
}
