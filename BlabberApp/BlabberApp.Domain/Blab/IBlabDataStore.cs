
namespace BlabberApp.Domain.Blab
{
   public interface IBlabDataStore
    {
        void Create(BlabEntity message);
        BlabEntity Read(string message);
        void Delete(string message);
        BlabEntity Find(string message);
    }
}
