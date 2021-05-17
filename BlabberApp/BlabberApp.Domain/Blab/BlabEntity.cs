
using Newtonsoft.Json;
using System;

namespace BlabberApp.Domain
{
    public class BlabEntity: IDomain
    {
        // Attributes
        [JsonProperty]
        private int id;
        public string message { get; set; }
        public int userId { get; set; }

        public DateTime created { get; set; }
        public UserEntity user { get; set; }

        public int GetId()
        {
            return id;
        }

        public void SetId(int id)
        {
            this.id = id;
        }
    }
}