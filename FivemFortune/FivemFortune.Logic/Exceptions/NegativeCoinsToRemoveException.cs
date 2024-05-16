using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivemFortune.Logic.Exceptions
{
    public class NegativeCoinsToRemoveException: Exception
    {
        public int CoinsAmount;

        public NegativeCoinsToRemoveException(int coinsAmount)
        {
            CoinsAmount = coinsAmount;
        }
    }
}
