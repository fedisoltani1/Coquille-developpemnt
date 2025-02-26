namespace Access.AppCore.Entities;

public class ModesReglementPaiement : Bases.EntiteBase<int>
{
    public ModesReglementPaiement()
    {
        Clients = new HashSet<Client>();
    } 

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }

    public virtual ICollection<Client> Clients { get; set; }
}
