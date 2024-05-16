using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FivemFortune.Logic;
using FivemFortune.Logic.Interfaces;


namespace FivemFortune.Data
{
    public class GetData : IGetData
    {
        private readonly DatabaseConnection _dbConnection;

        private int coins = 0;

        public GetData(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public string GetUserName()
        {
            string userName = null;

            try
            {
                string query = "SELECT name FROM users";

                userName = _dbConnection.ExecuteQuerySingle(query, (reader) => reader["name"].ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return userName;
        }
        public int GetCoins()
        {

            try
            {
                string query = "SELECT coins FROM users";

                coins = Convert.ToInt32(_dbConnection.ExecuteQuerySingle(query, (reader) => reader["coins"]));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return coins;
        }
        public List<Crates> GetAllCrates()
        {
            string query = "SELECT id, name, price FROM crates";
            List<Crates> crates = _dbConnection.ExecuteQuery(query, (reader) =>
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["name"].ToString();
                int price = Convert.ToInt32(reader["price"]);
                return new Crates(id, name, price);
            });
            return crates;
        }

    }
}
