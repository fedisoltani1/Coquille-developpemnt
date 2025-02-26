namespace Access.AppCore.Entities;

public class Chequier : Bases.EntiteBase<int>
{
    public string NumeroDebut { get; set; } = null!;

    public string NumeroFin { get; set; } = null!;

    public int ChequierStatutId { get; set; }

    public string ChequierStatutIntitule { get; set; } = null!;

    public bool IsActif { get; set; }

    public int BanqueId { get; set; }

    public ICollection<Cheque> Cheques { get; set; } = null!;

    public virtual Banque Banque { get; set; } = null!;

    public virtual ChequierStatut ChequierStatut { get; set; } = null!;
}
