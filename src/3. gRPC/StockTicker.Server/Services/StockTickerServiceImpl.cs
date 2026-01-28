using Grpc.Core;
using StockTicker.Server;

namespace StockTicker.Server.Services;

public class StockTickerServiceImpl : global::StockTicker.Server.StockTickerService.StockTickerServiceBase
{
    public override async Task Subscribe(StockRequest request, IServerStreamWriter<StockUpdate> responseStream, ServerCallContext context)
    {
        var random = new Random();
        while (!context.CancellationToken.IsCancellationRequested)
        {
            foreach (var symbol in request.Symbols)
            {
                await responseStream.WriteAsync(new StockUpdate
                {
                    Symbol = symbol,
                    Price = random.NextDouble() * 100,
                    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
                });
            }
            await Task.Delay(1000);
        }
    }
}
