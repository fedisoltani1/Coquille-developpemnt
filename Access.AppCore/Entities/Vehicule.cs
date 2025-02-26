namespace Access.AppCore.Entities;

public class Vehicule : Bases.EntiteBase<int>
{
    public string Matricule { get; set; } = null!;

    public string Marque { get; set; } = null!;

    public string Modele { get; set; } = null!;

    public DateOnly? DateDerniereVisite { get; set; }

    public DateOnly? DateVignette { get; set; }

    public DateOnly? DateDernierVidange { get; set; }

    public int Kilometrage { get; set; }

    public bool IsGps { get; set; }

    public int VehiculeTypeId { get; set; }

    public string VehiculeTypeIntitule { get; set; } = null!;

    public DateTime CreationLe { get; set; }

    public string? ModificationLe { get; set; }

    public DateTime CreationPar { get; set; }

    public string? ModificationPar { get; set; }

    public bool IsActif { get; set; }

    public int PoidsMaximal { get; set; }
}
