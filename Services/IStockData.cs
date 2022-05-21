using RealtimeGraphWithHostedService.Models;
using System.Threading.Tasks;

namespace RealtimeGraphWithHostedService.Services
{
    public interface IStockData
    {
        Task<ProductModel> GetStockData(int productid);
    }
}