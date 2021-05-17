using System;
using System.Collections.Generic;
using System.Data;
using BlabberApp.Domain;
using MySqlConnector;

namespace BlabberApp.DataStore
{
    public class BlabMySqlDataStore : IDomainDataStore
    {
        private MySqlDataStoreConnection Connection;
        public BlabMySqlDataStore(MySqlDataStoreConnection conn)
        {
            Connection = conn;
        }

        public int Create(IDomain o)
        {
            BlabEntity b = (BlabEntity)o;
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO blabs(message, user_id) VALUES (@message, @user_id)";
            cmd.Parameters.AddWithValue("@message", b.message);
            cmd.Parameters.AddWithValue("@user_id", b.userId);
            cmd.ExecuteScalar();
            return (int)cmd.LastInsertedId;

        }

        public void Delete(int ID)
        {
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM blabs WHERE id = '" + ID + "'";
            cmd.ExecuteScalar();
        }


        public IDomain Read(int ID)
        {
            var buf = new BlabEntity();
            var cmd = Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM blabs b LEFT JOIN users u ON b.user_id = u.id WHERE b.id = '" + ID + "';";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                buf.SetId(reader.GetInt32(0));
                buf.message = reader.GetString(1);
                buf.userId = reader.GetInt32(2);
                buf.created = reader.GetDateTime(3);
                buf.user = new UserEntity();
                buf.user.SetId(reader.GetInt32(4));
                buf.user.SetSysId(reader.GetString(5));
                buf.user.Name = reader.GetString(6);
            }
            reader.Close();
            Connection.Close();

            return buf;
        }


        public IDomain[] ReadAll()
        {
            var buf = new List<BlabEntity>();
            var cmd = Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM blabs b LEFT JOIN users u ON b.user_id = u.id ORDER BY b.created DESC;";
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var Blab = new BlabEntity();
                Blab.SetId(reader.GetInt32(0));
                Blab.message = reader.GetString(1);
                Blab.userId = reader.GetInt32(2);
                Blab.created = reader.GetDateTime(3);
                Blab.user = new UserEntity();
                Blab.user.SetId(reader.GetInt32(4));
                Blab.user.SetSysId(reader.GetString(5));
                Blab.user.Name = reader.GetString(6);
                buf.Add(Blab);
            }
            reader.Close();
            Connection.Close();

            return buf.ToArray();
        }

        public void DeleteAll()
        {
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM blabs";
            cmd.ExecuteScalar();
        }

        public void Update(int ID, string message)
        {
            var cmd = (MySqlCommand)Connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE blabs SET message = @message WHERE id = @id";
            cmd.Parameters.AddWithValue("@message", message);
            cmd.Parameters.AddWithValue("@id", ID); 
            cmd.ExecuteScalar();
        }
    }
}
