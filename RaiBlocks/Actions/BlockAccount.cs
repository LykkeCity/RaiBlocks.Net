using Newtonsoft.Json;
using RaiBlocks.Interfaces;
using RaiBlocks.Results;

namespace RaiBlocks.Actions
{
    public class BlockAccount : IAction<BlockAccountResult>
    {
        [JsonProperty("action")]
        public string Action { get; } = "block_account";
        
        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
