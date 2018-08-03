using Newtonsoft.Json;
using RaiBlocks.Interfaces;
using RaiBlocks.Results;
using RaiBlocks.ValueObjects;
using System;

namespace RaiBlocks.Actions
{
    public class GetAccountHistory : IAction<AccountHistoryResult>
    {
        [JsonProperty("action")]
        public string Action { get; } = "account_history";

        [JsonProperty("account")]
        public string AccountNumber { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }
        
        [JsonProperty("head")]
        public string Head { get; set; }


        public GetAccountHistory(RaiAddress address, int count = 1, string head = null)
        {
            if (count < 1) throw new ArgumentException("Count must be larger than 0");

            AccountNumber = address ?? throw new ArgumentNullException(nameof(address));
            Count = count;
            Head = head;
        }
    }
}
