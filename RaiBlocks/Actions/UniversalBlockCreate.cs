using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RaiBlocks.Converters;
using RaiBlocks.Interfaces;
using RaiBlocks.Results;
using RaiBlocks.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace RaiBlocks.Actions
{
    public class UniversalBlockCreate : IAction<BlockCreateResult>
    {
        [JsonProperty("action")]
        public string Action { get; } = "block_create";

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public BlockType Type { get; } = BlockType.state;
        
        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
        
        [JsonProperty("representative")]
        public string RepresentativeNumber { get; set; }

        [JsonProperty("account")]
        public string AccountNumber { get; set; }

        [JsonConverter(typeof(StringToRawConverter))]
        [JsonProperty("balance")]
        public RaiUnits.RaiRaw Balance { get; set; }

        [JsonProperty("work")]
        public string Work { get; set; }
        
        [JsonProperty("signature")]
        public string Signature { get; set; }
    }
}
