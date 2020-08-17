using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesTechChallenge.Service.Domain;

namespace WooliesTechChallenge.Service.Interface
{
    public interface IApiCaller
    {
        Task<List<ProductWithQuantity>> GetProducts();

        Task<List<ShopperHistoryReponse>> GetShopperHistory();
    }
}
