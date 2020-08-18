using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

    public class Order
    {
        public List<ProductWithQuantity> ProductWithQuantities { get; set; } = new List<ProductWithQuantity>();

        public List<Special> SpecialApplied { get; set; } = new List<Special>();

        public decimal Total
        {
            get
            {
                var totalWithProductWithQuantities = ProductWithQuantities.Select(x => x.Price * x.Quantity).Sum();
                var totalForSpecials = SpecialApplied.Select(x => x.Total).Sum();
                return totalWithProductWithQuantities + totalForSpecials;
            }
        }
    }

}
