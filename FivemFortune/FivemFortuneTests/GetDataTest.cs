using FivemFortune.Logic;
using FivemFortune.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivemFortuneTests
{
    public class GetDataTest : IGetData
    {
        public List<Crates> GetAllCrates()
        {
            throw new NotImplementedException();
        }

        public int GetCoins()
        {
            return 50;
        }

        public string GetUserName()
        {
            throw new NotImplementedException();
        }
    }
}
