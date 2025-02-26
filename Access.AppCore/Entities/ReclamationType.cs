namespace Access.AppCore.Entities;

public class ReclamationType : Bases.EntiteBase<int>
{
    public string Intitule { get; set; } = null!;

    public int SocieteDepartementId { get; set; }

    public string SocieteDepartementIntitule { get; set; } = null!;

    public bool IsActif { get; set; }
}
