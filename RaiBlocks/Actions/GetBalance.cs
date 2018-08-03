using Newtonsoft.Json;
using RaiBlocks.Interfaces;
using RaiBlocks.Results;
using RaiBlocks.ValueObjects;
using System;

namespace RaiBlocks.Actions
{
    public class GetBalance : IAction<BalanceResult>
    {
        [JsonProperty("action")]
        public string Action { get; } = "account_balance";

        [JsonProperty("account")]
        public string AccountNumber { get; set; }

        public GetBalance(RaiAddress address)
        {
            AccountNumber = address ?? throw new ArgumentNullException(nameof(address));
        }
    }
}
