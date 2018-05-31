using Microsoft.Extensions.Configuration;

namespace GiftAidCalculator.TestConsole.Repository
{
    public class TaxRateRepository : IRepository<decimal>
    {
        public decimal Get()
        {
            // TODO: get tax rate from data store
            return 20m;
        }
    }
}
