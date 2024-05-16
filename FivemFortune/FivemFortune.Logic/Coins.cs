using FivemFortune.Logic.Exceptions;
using FivemFortune.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivemFortune.Logic
{
    public class Coins
    {
        private readonly IGetData _getData;
        private readonly IUpdateData _updateData;
        public Coins(IGetData getData, IUpdateData updateData)
        {
            _getData = getData;
            _updateData = updateData;
        }

        public int GetCoins()
        {
            int coins = _getData.GetCoins();
            return coins;
        }

        public void UpdateCoins(int coinsToRemove)
        {
            if (coinsToRemove < 0)
            {
                throw new NegativeCoinsToRemoveException(coinsToRemove);
            }
            else if(coinsToRemove > 1500)
            {
                throw new ToHighCoinsToRemoveException(coinsToRemove);
            }
            else {
                int currentCoins = _getData.GetCoins();
                int newCoins = 0;

                newCoins = currentCoins - coinsToRemove;

                if (newCoins < 0)
                {
                    newCoins = 0;
                }


                _updateData.UpdateCoins(newCoins);
        }
    }

        public (bool success, string message, string colorClass) BuyCrate(int price)
        {
            int coins = GetCoins();
            string message;
            string colorClass;

            if (coins < price)
            {
                message = "You don't have enough coins!";
                colorClass = "red";
                return (true, message, colorClass);
            }
            else
            {
                UpdateCoins(price);
                message = "Crate bought successfully!";
                colorClass = "green";
                return (true, message, colorClass);
            }
        }

    }
}
