using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRevendb.Model
{
    public class Product
    {
        public string Id { get; set; }
        public string  Name { get; set; }
        public Category  Category { get; set; }

    }
}