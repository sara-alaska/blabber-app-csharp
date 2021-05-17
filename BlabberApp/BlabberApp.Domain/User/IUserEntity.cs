namespace BlabberApp.Domain
{
    public interface IUserEntity
    {
        void Add(UserEntity user);
        UserEntity Find(string username);
        void Remove(string username);
    }
}