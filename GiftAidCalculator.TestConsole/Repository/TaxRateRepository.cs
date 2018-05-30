using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GiftAidCalculator.TestConsole.Repository
{
    public class TaxRateRepository : IRepository<decimal>
    {
        public decimal GetAsync()
        {
            return 20m;
        }
    }
}
