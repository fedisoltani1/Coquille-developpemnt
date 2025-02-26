namespace Access.AppCore.Entities;

public class TaxeType : Bases.EntiteBase<int>
{
    public TaxeType()
    {
        Taxes = new HashSet<Taxe>();
    }

    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Taxe> Taxes { get; set; }
}
