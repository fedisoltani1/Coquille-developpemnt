namespace Access.AppCore.Entities;

public class SocieteAgence
{
    public SocieteAgence()
    {
        Collaborateurs = new HashSet <Collaborateur>();
    }

    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public string Gouvernorat { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string CodePostal { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string? AdresseMail { get; set; }

    public int CollaborateurId { get; set; }

    public string CollaborateurName { get; set; } = null!;

    public bool IsActif { get; set; }

    public string? MatriculeFiscale { get; set; }

    public virtual Collaborateur Collaborateur { get; set; } = null!;

    public virtual ICollection<Collaborateur> Collaborateurs { get; set; }
}
