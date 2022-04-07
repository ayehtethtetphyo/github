using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace github.Models
{
    public class ModelClass
    {

        public string contact_name { get; set; }
        public int id { get; set; }

        //public string ConnectionString { get; set; }

        //public ConnectionClass(string connectionString)
        //{
        //    this.ConnectionString = connectionString;
        //}

        //private MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(ConnectionString);
        //}
    }
}
