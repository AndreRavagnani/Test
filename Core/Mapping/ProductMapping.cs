using Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class ProductMapping : ClassMap<Product>
    {
        public ProductMapping()
        {
            Id(x => x.ID);
            Map(x => x.Description);
            Map(x => x.Name);
            Map(x => x.Price);
            Table("T_PRD");
        }
    }
}
