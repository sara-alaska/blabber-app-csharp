using System;
using System.Net.Mail;

namespace BlabberApp.Domain
{
    public class UserEntity: IDomain
    {
        private int id;
        private string _SYS_ID;
        public string Name { get; set; }

        public UserEntity SetSysId(string newID)
        {
            try
            {
                MailAddress m = new MailAddress(newID); // validation only
            }
            catch (FormatException fe)
            {
                throw new FormatException(fe.ToString());
            }

            _SYS_ID = newID;
            return this;
        }

        public string GetSysId()
        {
            return _SYS_ID;
        }


        public void SetId(int id)
        {
            this.id = id;
        }

        public int GetId()
        {
            return id;
        }
    }
}