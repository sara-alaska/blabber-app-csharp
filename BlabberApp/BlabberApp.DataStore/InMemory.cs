using System.Collections.Generic;
using BlabberApp.Domain;


namespace BlabberApp.DataStore
{
    public class InMemory : IDomainDataStore, IDomainServices
    {
        private List<IDomain> MyBuffer;

        public InMemory()
        {
            MyBuffer = new List<IDomain>();
        }

        public InMemory(IDomain[] myBuffer)
        {
            MyBuffer = new List<IDomain>();
            MyBuffer.AddRange(myBuffer);
        }

        public void Add(IDomain obj)
        {
            Create(obj);
        }

        public int Count()
        {
            return MyBuffer.Count;
        }
        public int Create(IDomain IDomain)
        {
            MyBuffer.Add(IDomain);
            return 0;
        }


        public IDomain Read(int ID)
        {
            return MyBuffer[FindIndex(ID)];
        }

        public void Remove(int ID)
        {
            MyBuffer.RemoveAt(FindIndex(ID));
        }

        public void Delete(int ID)
        {
            Remove(ID);
        }


        private int FindIndex(int ID)
        {
            return MyBuffer.FindIndex((IDomain o) => ID.Equals(o.GetId()) == true);
        }

        public void Update(int ID, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
