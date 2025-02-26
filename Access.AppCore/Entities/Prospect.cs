namespace Access.AppCore.Entities;

public class Prospect : Bases.EntiteBase<int>
{
    public string Code { get; set; } = null!;

    public string Intitule { get; set; } = null!;

    public string? Abreviation { get; set; }

    public string NomCommercial { get; set; } = null!;

    public string MatriculeFiscaleCin { get; set; } = null!;

    public string Gouvernorat { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string CodePostal { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string? AdresseMail { get; set; }

    public string NomPremierResponsable { get; set; } = null!;

    public DateTime CreationLe { get; set; }

    public string CreationPar { get; set; } = null!;
}
