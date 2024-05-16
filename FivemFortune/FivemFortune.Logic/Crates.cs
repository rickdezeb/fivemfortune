using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FivemFortune.Logic.Exceptions;

namespace FivemFortune.Logic
{
    public class Crates
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }

        public Crates(int ID, string name, int price)
        {
            Id = ID;
            Name = name;
            Price = price;

            if (Price < 0)
            {
                throw new NegativeCoinsToRemoveException(Price);
            }
            if (Price > 1500)
            {
                throw new ToHighCoinsToRemoveException(Price);
            }
        }
    }
}
