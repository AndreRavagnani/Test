using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SummerPromo : Product
    {
        int discount = 20;
        public override double Price { get => base.Price - ((discount * base.Price) / 100); set => base.Price = value; }
    }
}
