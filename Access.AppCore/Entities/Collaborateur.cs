namespace Access.AppCore.Entities;

public class Collaborateur : Bases.EntiteBase<int>
{

    public Collaborateur()
    {
        Clients = new HashSet<Client>();
        SocieteAgences = new HashSet<SocieteAgence>();
        SocieteDepartements = new HashSet<SocieteDepartement>();
    }

    public string NomComplet { get; set; } = null!;

    public string? Cin { get; set; }

    public string Telephone { get; set; } = null!;

    public string? AdresseMail { get; set; }

    public string Fonction { get; set; } = null!;

    public int RoleId { get; set; }

    public string RoleIntitule { get; set; } = null!;

    public string Adresse { get; set; } = null!;

    public string Gouvernorat { get; set; } = null!;

    public string CodePostal { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public bool IsActif { get; set; }

    public DateTime CreationLe { get; set; }

    public DateTime? ModificationLe { get; set; }

    public string CreationPar { get; set; } = null!;

    public string? ModificationPar { get; set; }

    public bool IsExterne { get; set; }

    public int AgenceId { get; set; }

    public string AgenceIntitule { get; set; } = null!;

    public virtual SocieteAgence Agence { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; }

    public virtual CollaborateurRole Role { get; set; } = null!;

    public virtual ICollection<SocieteAgence> SocieteAgences { get; set; }

    public virtual ICollection<SocieteDepartement> SocieteDepartements { get; set; }
}
