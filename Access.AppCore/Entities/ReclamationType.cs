namespace Access.AppCore.Entities;

public class ReclamationType
{
    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public int SocieteDepartementId { get; set; }

    public string SocieteDepartementIntitule { get; set; } = null!;

    public bool IsActif { get; set; }
}
