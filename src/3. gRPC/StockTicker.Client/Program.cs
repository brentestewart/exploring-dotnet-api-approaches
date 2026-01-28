using Grpc.Net.Client;

using var channel = GrpcChannel.ForAddress("http://localhost:5020");
var client = new global::StockTicker.Server.StockTickerService.StockTickerServiceClient(channel);

var request = new global::StockTicker.Server.StockRequest();
request.Symbols.Add("MSFT");
//request.Symbols.Add("AAPL");

using var call = client.Subscribe(request);
while (await call.ResponseStream.MoveNext(CancellationToken.None))
{
    var update = call.ResponseStream.Current;
    Console.WriteLine($"{update.Symbol}: {update.Price:C} at {DateTimeOffset.FromUnixTimeSeconds(update.Timestamp)}");
}