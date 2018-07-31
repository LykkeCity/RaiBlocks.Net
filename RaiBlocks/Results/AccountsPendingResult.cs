using System.Collections.Generic;
using Newtonsoft.Json;
using RaiBlocks.Converters;

namespace RaiBlocks.Results
{
    public class AccountsPendingResult
    {
        [JsonProperty("blocks")] 
        public Dictionary<string, Dictionary<string, AccountPendingBlock>> Blocks { get; set; }
                
        public class  AccountPendingBlock
        {
            [JsonConverter(typeof(StringToRawConverter))]
            [JsonProperty("amount")] 
            public RaiUnits.RaiRaw Amount { get; set; }
            
            [JsonProperty("source")] 
            public string Source { get; set; }          
        }
        
    }
}
