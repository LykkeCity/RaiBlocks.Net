using Newtonsoft.Json;

namespace RaiBlocks.Results
{
    public class BlockAccountResult
    {
        [JsonProperty("account")]
        public string Aaccount { get; set; }
    }
}
