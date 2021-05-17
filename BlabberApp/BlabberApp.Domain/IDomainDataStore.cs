
namespace BlabberApp.Domain
{
    public interface IDomainDataStore
    {
        int Create(IDomain o);
        IDomain Read(int ID);
        void Delete(int ID);
        void Update(int ID, string message);
    }
}