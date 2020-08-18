using System.Collections.Generic;
using System.Linq;
using WooliesTechChallenge.Service.Domain;

namespace WooliesTechChallenge.Service.Utility
{
    public static class DictionaryExtensions
    {
        public static int TryGetValue(this Dictionary<string, int> dict, string key)
        {
            if (dict.ContainsKey(key)){
                return dict[key];
            }

            return 0;
        }
    }

    public static class TrolleyRequestExtensions
    {
        public static Order ToOrder(this TrolleyRequest trolleyRequest)
        {
            return  new Order()
            {
                ProductWithQuantities = trolleyRequest.Products.Select(x =>
                {
                    return new ProductWithQuantity()
                    {
                        Name = x.Name,
                        Price = x.Price,
                        Quantity = trolleyRequest.Quantities.Where(x => x.Name == x.Name).FirstOrDefault().Quantity
                    };
                }).ToList()
            };
        }
    }
}
