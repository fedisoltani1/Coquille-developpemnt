namespace Access.AppCore.Entities;

public class ReclamationPriorite : Bases.EntiteBase<int>
{
    public string Intitule { get; set; } = null!;

    public string Couleur { get; set; } = null!;

    public bool IsActif { get; set; }
}
