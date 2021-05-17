using System.Collections.Generic;
using BlabberApp.Domain;
using BlabberApp.Domain.Blab;

namespace BlabberApp.DataStore
{
    public class InMemoryBlab : IBlabDataStore
    {
        private List<BlabEntity> Blabs;

        public InMemoryBlab()
        {
            Blabs = new List<BlabEntity>();
        }

        public InMemoryBlab(BlabEntity[] blabs)
        {
            Blabs = new List<BlabEntity>();
            Blabs.AddRange(blabs);
        }

        public void Add(BlabEntity blab)
        {
            Create(blab);
        }

        public int Count()
        {
            return Blabs.Count;
        }
        public void Create(BlabEntity blabEntity)
        {
            Blabs.Add(blabEntity);
        }

        public void Delete(string message)
        {
            Blabs.RemoveAt(FindIndex(message));
        }

        public BlabEntity Find(string message)
        {
            return Read(message);
        }

        public BlabEntity Read(string message)
        {
            return Blabs[FindIndex(message)];
        }

        public void Remove(string message)
        {
            Delete(message);
        }

        private int FindIndex(string message)
        {
            return Blabs.FindIndex((BlabEntity u) => message.Equals(u.message) == true);
        }
    }
}

