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

        public void UpdateCoins(int newCoins)
        {

            try
            {
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
