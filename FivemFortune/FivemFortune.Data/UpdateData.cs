using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FivemFortune.Logic;
using FivemFortune.Logic.Interfaces;

namespace FivemFortune.Data
{
    public class UpdateData : IUpdateData
    {
        private readonly DatabaseConnection _dbConnection;

        public UpdateData(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void UpdateCoins(int coinsToRemove)
        {
            int newCoins = 0;

            try
            {
                string selectQuery = "SELECT coins FROM users";
                int currentCoins = _dbConnection.ExecuteQuerySingle(selectQuery, (reader) => Convert.ToInt32(reader["coins"]));

                newCoins = currentCoins - coinsToRemove;
                if (newCoins < 0)
                {
                    newCoins = 0;
                }

                string updateQuery = $"UPDATE users SET coins = {newCoins}";
                _dbConnection.ExecuteUpdateQuerry(updateQuery);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
