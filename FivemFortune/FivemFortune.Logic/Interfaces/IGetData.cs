using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivemFortune.Logic.Interfaces
{
    public interface IGetData
    {
        public string GetUserName();
        public int GetCoins();
        public List<Crates> GetAllCrates();

    }
}
