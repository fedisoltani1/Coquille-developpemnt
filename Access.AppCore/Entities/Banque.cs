namespace Access.AppCore.Entities;

public class Banque : Bases.EntiteBase<int>
{
    public Banque()
    {
        Chequiers = new HashSet<Chequier>();
        Cheques = new HashSet<Cheque>();
    }

    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }

    public virtual ICollection<Chequier> Chequiers { get; set; }

    public virtual ICollection<Cheque> Cheques { get; set; }
}
