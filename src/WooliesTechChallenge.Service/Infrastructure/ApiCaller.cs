using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WooliesTechChallenge.Service.Configuration;
using WooliesTechChallenge.Service.Domain;
using WooliesTechChallenge.Service.Interface;
using WooliesTechChallenge.Service.Utility;

namespace WooliesTechChallenge.Service.Infrastructure
{
    public class ApiCaller : IApiCaller
    {
        private WooliesX _configuration;

        public ApiCaller(IOptions<WooliesX> configuration)
        {
            _configuration = configuration.Value;
        }

        private async Task<T> GetResource<T>(string baseUrl, string relativeUrl) where T: class
        {
            using(var httpClient = new HttpClient())
            {
                var uri = UrlBuilder.CombineUrl(baseUrl, relativeUrl)
                                    .AddQueryString(nameof(WooliesX.Token), _configuration.Token);


                var response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
            }

            return default(T); 
        }

        public async Task<List<ProductWithQuantity>> GetProducts()
        {
            return await GetResource<List<ProductWithQuantity>>(_configuration.ResourceBaseUrl, _configuration.ProductsUrl);
        }

        public async Task<List<ShopperHistoryReponse>> GetShopperHistory()
        {
            return await GetResource<List<ShopperHistoryReponse>>(_configuration.ResourceBaseUrl, _configuration.ShopperHistoryUrl);
        }
    }
}
