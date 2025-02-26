namespace Access.AppCore.Entities;

public class FacturationCategory : Bases.EntiteBase<int>
{
    public FacturationCategory()
    {
        Clients = new HashSet<Client>();
    }

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }

    public virtual ICollection<Client> Clients { get; set; }
}
