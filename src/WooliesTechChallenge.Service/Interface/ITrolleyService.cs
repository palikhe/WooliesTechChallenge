using WooliesTechChallenge.Service.Domain;

namespace WooliesTechChallenge.Service.Interface
{
    public interface ITrolleyService
    {
        Order ApplySpecial(Order order, Special special);

        decimal GetLowestTotal(TrolleyRequest trolleyRequest);
    }
}
