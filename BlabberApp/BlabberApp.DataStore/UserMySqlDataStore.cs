using System.Collections.Generic;
using System.Data;
using BlabberApp.Domain;
using MySqlConnector;

namespace BlabberApp.DataStore
{
    public class UserMySqlDataStore : IDomainDataStore
    {
        private IDbConnection Connection;
        public UserMySqlDataStore(IDbConnection conn)
        {
            Connection = conn;
        }

        public int Create(IDomain o)
        {
            UserEntity u = (UserEntity)o;
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO users(name, sys_id) VALUES (@name, @sysid)";
            cmd.Parameters.AddWithValue("@name", u.Name);
            cmd.Parameters.AddWithValue("@sysid", u.GetSysId());
            cmd.ExecuteScalar();

            return (int)cmd.LastInsertedId;

        }

        public void DeleteAll()
        {
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM users";
            cmd.ExecuteScalar();
        }

        public void Delete(int ID)
        {
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM users WHERE id = '"+ ID +"'";
            cmd.ExecuteScalar();
        }

        public IDomain Read(string name, string email)
        {
            var buf = new UserEntity();
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM users WHERE name = @name AND sys_id = @email";
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buf.SetId(reader.GetInt32(0));
                buf.SetSysId(reader.GetString(1));
                buf.Name = reader.GetString(2);
            }
            reader.Close();
            Connection.Close();

            return buf;
        }

        public IDomain[] ReadAll()
        {
            var buf = new List<UserEntity>();
            var cmd = Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM users;";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var User = new UserEntity();
                User.SetSysId(reader.GetString(1));
                User.Name = reader.GetString(2);
                buf.Add(User);
            }
            reader.Close();
            Connection.Close();

            return buf.ToArray();
        }

        public IDomain Read(int ID)
        {
            var buf = new UserEntity();
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM users WHERE id = @ID";
            cmd.Parameters.AddWithValue("@ID", ID);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buf.SetId(reader.GetInt32(0));
                buf.SetSysId(reader.GetString(1));
                buf.Name = reader.GetString(2);
            }
            reader.Close();
            Connection.Close();

            return buf;
        }

        public int Update(int ID)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int ID, string message)
        {
            throw new System.NotImplementedException();
        }
    }
}
