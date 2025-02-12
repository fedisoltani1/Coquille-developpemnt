namespace Access.AppCore.Entities;

public class Client
{
    public Client()
    {
        ClientContacts = new HashSet<ClientContact>();
        Clients = new HashSet<Client>();
    }

    public int Id { get; set; }

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

    public bool IsAssujettiTva { get; set; }

    public bool IsAssujettiTpf { get; set; }

    public bool IsActif { get; set; }

    public int ServiceId { get; set; }

    public string ServiceInitule { get; set; } = null!;

    public int NombreTentativeLivraison { get; set; }

    public int CollaborateurId { get; set; }

    public string CollaborateurName { get; set; } = null!;

    public bool IsFacture { get; set; }

    public string Classe { get; set; } = null!;

    public int ModeReglementFacturationId { get; set; }

    public string ModeReglementFacturationIntitule { get; set; } = null!;

    public int ModeReglementPaimentId { get; set; }

    public string ModeReglementPaimentIntitule { get; set; } = null!;

    public int FacturationCategorieId { get; set; }

    public string FacturationCategorieIntitule { get; set; } = null!;

    public int NombreJoursPaiement { get; set; }

    public DateOnly? DateFinContrat { get; set; }

    public bool IsGenerationBonLivraison { get; set; }

    public int ClientTypeId { get; set; }

    public string ClientTypeIntitule { get; set; } = null!;

    public int? ClientId { get; set; }

    public string NomPremierResponsable { get; set; } = null!;

    public int? ClientWarehouseId { get; set; }

    public string? ClientWarehouseIntitule { get; set; }

    public bool IsStatPayout { get; set; }

    public bool IsStatFacturation { get; set; }

    public DateTime CreationLe { get; set; }

    public DateTime? ModificationLe { get; set; }

    public string CreationPar { get; set; } = null!;

    public string? ModificationPar { get; set; }

    public bool IsInterne { get; set; }

    public virtual ICollection<ClientContact> ClientContacts { get; set; }

    public virtual Client? ClientInfo { get; set; }

    public virtual ClientType ClientType { get; set; } = null!;

    public virtual ClientWarehouse? ClientWarehouse { get; set; }

    public virtual Collaborateur Collaborateur { get; set; } = null!;

    public virtual FacturationCategory FacturationCategorie { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; }

    public virtual ModesReglementFacturation ModeReglementFacturation { get; set; } = null!;

    public virtual ModesReglementPaiement ModeReglementPaiment { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
