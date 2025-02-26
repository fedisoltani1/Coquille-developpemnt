namespace Access.AppCore.Entities;

public class SocieteAgence : Bases.EntiteBase<int>
{
    public SocieteAgence()
    {
        Collaborateurs = new HashSet<Collaborateur>();
    }

    public string Intitule { get; set; } = null!;

    public string Gouvernorat { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string CodePostal { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string? AdresseMail { get; set; }

    public string ResponsableName { get; set; } = null!;

    public string ResponsableEmail { get; set; } = null!;

    public string ResponsableTel { get; set; } = null!;

    public bool IsActif { get; set; }

    public string? MatriculeFiscale { get; set; }

    public virtual ICollection<Collaborateur> Collaborateurs { get; set; }
}