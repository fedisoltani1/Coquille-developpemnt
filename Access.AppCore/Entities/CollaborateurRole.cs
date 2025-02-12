namespace Access.AppCore.Entities;

public class CollaborateurRole
{
    public CollaborateurRole()
    {
        Collaborateurs = new HashSet<Collaborateur>();
    }

    public int Id { get; set; }

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Collaborateur> Collaborateurs { get; set; }
}
