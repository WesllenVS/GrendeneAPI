using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeupAPI.Interface
{
    public interface IProductsInterface
    {
        Task<IEnumerable<object>> GetProductsAsync();
    }
}
