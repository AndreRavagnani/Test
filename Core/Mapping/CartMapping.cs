using Core.Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
    public class CartMapping : ClassMap<Cart>
    {
        public CartMapping()
        {
            Id(x => x.ID);
            Table("T_CRT");
            HasManyToMany(x => x.Products)
            .Cascade.All()
            .Table("T_CRT_PRD")
            .Not.LazyLoad();
        }
    }
}
