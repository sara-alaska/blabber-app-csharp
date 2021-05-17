namespace BlabberApp.Domain
{
    public interface IUserEntityDataStore
    {
        int Create(UserEntity usr);
        UserEntity Read(string username);
        void Delete(string username);
    }
}