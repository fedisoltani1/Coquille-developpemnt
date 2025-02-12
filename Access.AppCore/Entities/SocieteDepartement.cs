namespace Access.AppCore.Entities;

public class SocieteDepartement
{
    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public bool IsActif { get; set; }

    public int CollaborateurId { get; set; }

    public virtual Collaborateur Collaborateur { get; set; } = null!;
}
