using Newtonsoft.Json;
using RaiBlocks.Interfaces;
using RaiBlocks.Results;

namespace RaiBlocks.Actions
{
    public class GetChain: IAction<GetChainResult>
    {
        [JsonProperty("action")]
        public string Action { get; } = "chain";
        
        [JsonProperty("block")]
        public string Block { get; set; }
        
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
