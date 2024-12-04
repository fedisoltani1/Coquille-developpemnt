namespace Access.AppCore.Entities.Bases
{
    public class EntiteBase<TId>
      where TId : IEquatable<TId>
    {
        public TId Id { get; protected set; } = default!;
    }
}
