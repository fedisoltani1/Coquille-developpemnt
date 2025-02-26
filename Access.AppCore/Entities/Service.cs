namespace Access.AppCore.Entities;

public class Service : Bases.EntiteBase<int>
{
    public Service()
    {
        Clients = new HashSet<Client>();
    }

    public string Intitule { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsActif { get; set; }

    public virtual ICollection<Client> Clients { get; set; }
}
