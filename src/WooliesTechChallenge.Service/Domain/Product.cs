using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesTechChallenge.Service.Domain
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductWithQuantity : Product
    {
        public decimal Quantity { get; set; }
    }

    public class ShopperHistoryReponse
    {
        public int CustomerId { get; set; }

        public List<ProductWithQuantity> Products { get; set; }
    }

    
}
