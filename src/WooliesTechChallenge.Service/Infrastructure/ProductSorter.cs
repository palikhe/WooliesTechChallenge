using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesTechChallenge.Service.Domain;
using WooliesTechChallenge.Service.Interface;
using WooliesTechChallenge.Service.Utility;

namespace WooliesTechChallenge.Service.Infrastructure
{
    public class ProductSorter : IProductSorter
    {
        private IApiCaller _apiCaller;

        public ProductSorter(IApiCaller apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public async Task<List<ProductWithQuantity>> SortProducts(string sortOptions)
        {
            switch (sortOptions)
            {
                case string option when (option.Equals(SortOptions.Low.ToString(), StringComparison.OrdinalIgnoreCase)):
                    return (await _apiCaller.GetProducts()).OrderBy(x => x.Price).ToList();

                case string option when (option.Equals(SortOptions.High.ToString(), StringComparison.OrdinalIgnoreCase)):
                    return (await _apiCaller.GetProducts()).OrderByDescending(x => x.Price).ToList();

                case string option when (option.Equals(SortOptions.Ascending.ToString(), StringComparison.OrdinalIgnoreCase)):
                    return (await _apiCaller.GetProducts()).OrderBy(x => x.Name).ToList();

                case string option when (option.Equals(SortOptions.Descending.ToString(), StringComparison.OrdinalIgnoreCase)):
                    return (await _apiCaller.GetProducts()).OrderByDescending(x => x.Name).ToList();

                case string option when (option.Equals(SortOptions.Recommended.ToString(), StringComparison.OrdinalIgnoreCase)):
                    return await SortByPopularity();

                default:
                    break;
            }

            return null;
        }

        private async Task<List<ProductWithQuantity>> SortByPopularity()
        {
            var shopperHistories = await _apiCaller.GetShopperHistory();

            var productPopularity = GenerateProductPopularity(shopperHistories);

            var _products = await _apiCaller.GetProducts();

            _products.Sort((x, y) => { return productPopularity.TryGetValue(y.Name).CompareTo(productPopularity.TryGetValue(x.Name)); });

            return _products;


            //return new List<ProductWithQuantity>()
            //{
            //    new ProductWithQuantity()
            //    {
            //        Name = "Test Product A",
            //        Price = 99.99m,
            //        Quantity = 0
            //    },
            //    new ProductWithQuantity()
            //    {
            //        Name = "Test Product B",
            //        Price = 101.99m,
            //        Quantity = 0
            //    },

            //    new ProductWithQuantity()
            //    {
            //        Name = "Test Product F",
            //        Price = 999999999999.0m,
            //        Quantity = 0
            //    },

            //    new ProductWithQuantity()
            //    {
            //        Name = "Test Product C",
            //        Price = 10.99m,
            //        Quantity = 0
            //    },

            //    new ProductWithQuantity()
            //    {
            //        Name = "Test Product D",
            //        Price = 5,
            //        Quantity = 0
            //    }
            //};
        }

        private Dictionary<string, int> GenerateProductPopularity(List<ShopperHistoryReponse> shopperHistories)
        {
            var productPopularity = new Dictionary<string, int>();

            foreach (var item in shopperHistories)
            {
                foreach (var product in item.Products)
                {
                    if (productPopularity.ContainsKey(product.Name))
                    {
                        productPopularity[product.Name] += 1;
                    }
                    else
                    {
                        productPopularity[product.Name] = 1;
                    }
                }
            }

            return productPopularity;
        }
    }
}
