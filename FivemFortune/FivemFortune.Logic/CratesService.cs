
using FivemFortune.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FivemFortune.Logic
{
    public class CratesService
    {
        private readonly IGetData _getData;

        public CratesService(IGetData getData)
        {
            _getData = getData;
        }

        public List<Crates> GetAllCrates()
        {
            return _getData.GetAllCrates();
        }
    }
}
