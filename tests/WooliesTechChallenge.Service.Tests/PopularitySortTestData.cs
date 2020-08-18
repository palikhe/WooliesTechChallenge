using System.Collections.Generic;
using WooliesTechChallenge.Service.Domain;

namespace WooliesTechChallenge.Service.Tests
{
    public class PopularitySortTestData
    {
        public List<ProductWithQuantity> AllProducts { get; set; }

        public List<ShopperHistoryReponse> ShopperHistoryReponse { get; set; }

        public List<ProductWithQuantity> ExpectedResult { get; set; }
    }
}
