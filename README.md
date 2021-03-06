# Lykke.RaiBlocks.Client

An unofficial .NET API Wrapper for RaiBlocks RPC Protocol (https://github.com/nanocurrency/raiblocks).

## Compiling
In order to compile Lykke.RaiBlocks.Client, you require the following:

- [Visual Studio 2017](https://www.microsoft.com/net/core#windowsvs2017)

## Examples

#### Get balance for account
```csharp
// Insert your node URI
var node = new RaiBlocksRpc("http://localhost:7076/"); 
var address = new RaiAddress("xrb_3e3j5tkog48pnny9dmfzj1r16pg8t1e76dz5tmac6iq689wyjfpi00000000")
var res = await _node.GetBalanceAsync(address);
```

#### Create account

```csharp
// Insert your node URI
var node = new RaiBlocksRpc("http://localhost:7076/"); 
// Insert next deterministic key in wallet
var res = await _node.CreateAccountAsync("000D1BAEC8EC208142C99059B393051BAC8380F9B5A2E6B2489A277D81789F3F");
```
