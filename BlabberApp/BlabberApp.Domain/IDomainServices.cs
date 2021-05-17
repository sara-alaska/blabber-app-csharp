namespace BlabberApp.Domain
{
    public interface IDomainServices
    {
        void Add(IDomain o);
        void Remove(int ID);
    }
}