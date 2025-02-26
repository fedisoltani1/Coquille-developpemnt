namespace Access.AppCore.Entities;

public class CollaborateurRole : Bases.EntiteBase<int>
{
    public CollaborateurRole()
    {
        Collaborateurs = new HashSet<Collaborateur>();
    }

    public string Intitule { get; set; } = null!;

    public virtual ICollection<Collaborateur> Collaborateurs { get; set; }
}
