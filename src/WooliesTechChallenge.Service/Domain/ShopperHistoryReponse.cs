using System.Collections.Generic;

namespace WooliesTechChallenge.Service.Domain
{
    public class ShopperHistoryReponse
    {
        public int CustomerId { get; set; }

        public List<ProductWithQuantity> Products { get; set; }
    }

}
