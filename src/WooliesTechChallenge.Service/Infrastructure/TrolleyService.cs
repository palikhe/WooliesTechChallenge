using Newtonsoft.Json;
using System.Linq;
using WooliesTechChallenge.Service.Domain;
using WooliesTechChallenge.Service.Interface;
using WooliesTechChallenge.Service.Utility;

namespace WooliesTechChallenge.Service.Infrastructure
{
    public class TrolleyService : ITrolleyService
    {
        public Order ApplySpecial(Order order, Special special)
        {
            if(!CanApplySpecial(order, special))
            {
                return order;
            }

            var orderAfterApplyingSpecials = JsonConvert.DeserializeObject<Order>(JsonConvert.SerializeObject(order));

            foreach (var item in special.Quantities)
            {
                orderAfterApplyingSpecials.ProductWithQuantities.Where(x => x.Name == item.Name).FirstOrDefault().Quantity -= item.Quantity;
            }

            orderAfterApplyingSpecials.SpecialApplied.Add(special);
            return orderAfterApplyingSpecials;
        }

        private bool CanApplySpecial(Order order, Special special)
        {
            foreach (var item in special.Quantities)
            {
                if(!(order.ProductWithQuantities.Where(x => x.Name == item.Name).FirstOrDefault()?.Quantity >= item.Quantity))
                {
                    return false;
                }
            }
            return true;
        }

        public decimal GetLowestTotal(TrolleyRequest trolleyRequest)
        {
            var order = trolleyRequest.ToOrder();
            var specials = trolleyRequest.Specials;

            specials.Sort((a, b) =>
            {
                return GetSavingsFromSpecial(b, order).CompareTo(GetSavingsFromSpecial(a, order));
            });

            foreach (var item in specials)
            {
                order = ApplySpecial(order, item);
            }

            return order.Total;
        }

        private decimal GetSavingsFromSpecial(Special special, Order order)
        {
            if (!CanApplySpecial(order, special))
            {
                return 0;
            }

            var totalWithoutSpecial = order.Total;

            var orderAfterApplyingSpecial = ApplySpecial(order, special);

            return totalWithoutSpecial - orderAfterApplyingSpecial.Total;
        }
    }
}
