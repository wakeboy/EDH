using System.Threading.Tasks;

namespace GiftAidCalculator.TestConsole.Repository
{
    public interface IRepository<T>
    {
        T GetAsync();
    }
}
