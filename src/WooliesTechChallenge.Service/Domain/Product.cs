using System.Collections.Generic;

namespace WooliesTechChallenge.Service.Domain
{
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }

    public class TrolleyRequest
    {
        public List<Product> Products { get; set; }

        public List<Special> Specials { get; set; }

        public List<ProductCount> Quantities { get; set; }
    }

    public class ProductCount
    {
        public string Name { get; set; }

        public decimal Quantity { get; set; }
    }

    public class Special
    {
        public List<ProductCount> Quantities { get; set; }
        public int Total { get; set; }
    }

}
