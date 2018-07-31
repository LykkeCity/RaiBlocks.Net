using System.Collections.Generic;
using Newtonsoft.Json;
using RaiBlocks.Interfaces;
using RaiBlocks.Results;

namespace RaiBlocks.Actions
{
    public class AccountsPending: IAction<AccountsPendingResult>
    {
        [JsonProperty("action")]
        public string Action { get; } = "accounts_pending";
        
        [JsonProperty("accounts")]
        public List<string> Accounts { get; set; }
        
        [JsonProperty("count")]
        public long Count { get; set; }
        
        [JsonProperty("source")]
        public bool Source { get; set; }      
    }
}
