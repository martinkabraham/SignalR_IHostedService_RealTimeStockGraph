using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using RealtimeGraphWithHostedService.Hubs;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;

namespace RealtimeGraphWithHostedService.Services
{
    public class StockServiceBackgroundCaller : BackgroundService
    {
        public IStockData _stockData { get; }
        public IHubContext<StockDataHub> _stockdataHub { get; }

        private int productId = 1;

        public StockServiceBackgroundCaller(IStockData stockData,IHubContext<StockDataHub> stockdataHub)
        {
            _stockData = stockData;
            _stockdataHub = stockdataHub;
        }                

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var product = await _stockData.GetStockData(productId);
                await _stockdataHub.Clients.All.SendAsync("populatedata",JsonSerializer.Serialize(product));
                Interlocked.Increment(ref productId);
                if (productId == 20) // repeat from begining for demo
                {
                    productId = 1;
                }

                if (productId > 1) // avoid delay for 1 st product
                {
                    await Task.Delay(2000);
                }
            }
            
        }
    }
}
