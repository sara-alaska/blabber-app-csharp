using System;
using System.Collections.Generic;
using BlabberApp.Domain;

namespace BlabberApp.DataStore
{
    public class InMemoryUser : IUserEntityDataStore, IUserEntity
    {
        private List<UserEntity> Users;

        public InMemoryUser()
        {
            Users = new List<UserEntity>();
        }

        public InMemoryUser(UserEntity[] users)
        {
            Users = new List<UserEntity>();
            Users.AddRange(users);
        }

        public void Add(UserEntity user)
        {
            Create(user);
        }

        public int Count()
        {
            return Users.Count;
        }
        public int Create(UserEntity userEntity)
        {
            Users.Add(userEntity);
            return 0;
        }

        public void Delete(string username)
        {
            Users.RemoveAt(FindIndex(username));
        }

        public UserEntity Find(string username)
        {
            return Read(username);
        }

        public UserEntity Read(string username)
        {
            return Users[FindIndex(username)];
        }

        public void Remove(string username)
        {
            Delete(username);
        }

        private int FindIndex(string username)
        {
            return Users.FindIndex((UserEntity u) => username.Equals(u.GetId()) == true);
        }
    }
}