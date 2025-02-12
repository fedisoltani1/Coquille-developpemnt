namespace Access.AppCore.Entities;

public class ReclamationPriorite
{
    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public string Couleur { get; set; } = null!;

    public bool IsActif { get; set; }
}
