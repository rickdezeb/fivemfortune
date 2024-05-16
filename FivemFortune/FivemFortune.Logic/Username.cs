using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FivemFortune.Logic.Interfaces;

namespace FivemFortune.Logic
{
    public class Username
    {
        private readonly IGetData _getData;
        public Username(IGetData getData)
        {
            _getData = getData;
        }

        public string GetUserName()
        {
            string userName = _getData.GetUserName();
            return userName;
        }
    }
}
