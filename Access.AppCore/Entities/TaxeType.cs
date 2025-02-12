namespace Access.AppCore.Entities;

public class TaxeType
{
    public TaxeType()
    {
        Taxes = new HashSet<Taxes>();
    }

    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Taxes> Taxes { get; set; }
}
