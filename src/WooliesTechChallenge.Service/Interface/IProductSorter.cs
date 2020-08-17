using System.Collections.Generic;
using System.Threading.Tasks;
using WooliesTechChallenge.Service.Domain;

namespace WooliesTechChallenge.Service.Interface
{
    public interface IProductSorter
    {
        Task<List<ProductWithQuantity>> SortProduct(string sortOptions);
    }
}
