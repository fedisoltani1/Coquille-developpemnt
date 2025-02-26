namespace Access.AppCore.Entities;

public class ChequierStatut : Bases.EntiteBase<int>
{
    public ChequierStatut()
    {
        Chequiers = new HashSet<Chequier>();
    }

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Chequier> Chequiers { get; set; }
}
