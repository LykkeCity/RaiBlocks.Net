using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using RaiBlocks.Converters;

namespace RaiBlocks.Results
{
    public class AccountsPendingResult : ErrorResult
    {
        [JsonProperty("blocks")] 
        public Dictionary<string, Dictionary<string, AccountPendingBlock>> Blocks { get; set; }
        
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            if (Blocks == null && Error == null)
            {
                Blocks = new Dictionary<string, Dictionary<string, AccountPendingBlock>>();
            }
        }
                
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
