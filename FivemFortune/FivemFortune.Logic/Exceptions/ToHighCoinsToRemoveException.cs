using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivemFortune.Logic.Exceptions
{
    public class ToHighCoinsToRemoveException: Exception
    {
        public int CoinsAmount;

        public ToHighCoinsToRemoveException(int coinsAmount)
        {
            CoinsAmount = coinsAmount;
        }
    }
}
