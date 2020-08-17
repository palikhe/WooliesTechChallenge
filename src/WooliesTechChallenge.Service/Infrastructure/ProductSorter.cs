using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WooliesTechChallenge.Service.Domain;
using WooliesTechChallenge.Service.Interface;

namespace WooliesTechChallenge.Service.Infrastructure
{
    public class ProductSorter : IProductSorter
    {
        private IApiCaller _apiCaller;

        private Dictionary<string, ProductWithQuantity> _productDictionary = new Dictionary<string, ProductWithQuantity>();

        public ProductSorter(IApiCaller apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public async Task<List<ProductWithQuantity>> SortProduct(string sortOptions)
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

            return productPopularity.Select(x => _productDictionary[x.Key]).ToList();
        }

        private IOrderedEnumerable<KeyValuePair<string, int>> GenerateProductPopularity(List<ShopperHistoryReponse> shopperHistories)
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
                        _productDictionary[product.Name] = product;
                    }
                }
            }

            return productPopularity.OrderByDescending(x => x.Value);
        }
    }
}
