using System.Collections.Generic;
using Newtonsoft.Json;
using RaiBlocks.ValueObjects;

namespace RaiBlocks.Results
{
    public class GetChainResult
    {
        [JsonProperty("blocks")]
        public List<string> Blocks { get; set; }
    }
}
