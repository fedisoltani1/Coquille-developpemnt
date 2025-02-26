namespace Access.AppCore.Entities;

public class Societe : Bases.EntiteBase<int>
{
    public string RaisonSocial { get; set; } = null!;

    public string MatriculeFiscale { get; set; } = null!;

    public string? RegistreCommerce { get; set; }

    public string Activite { get; set; } = null!;

    public string NomCommercial { get; set; } = null!;

    public string Gouvernorat { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string CodePostal { get; set; } = null!;

    public string AdresseMail { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Secteur { get; set; } = null!;

    public string PremierResponsable { get; set; } = null!;
}
