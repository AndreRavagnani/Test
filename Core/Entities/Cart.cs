using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Cart
    {
        public virtual int ID { get; set; }
        public virtual IList<Product> Products { get; set; }

        public Cart()
        {
            Products = new List<Product>();
        }
    }
}
