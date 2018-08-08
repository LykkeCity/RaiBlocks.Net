using Newtonsoft.Json;
using RaiBlocks.Interfaces;
using RaiBlocks.Results;
using RaiBlocks.ValueObjects;
using System;

namespace RaiBlocks.Actions
{
    public class GetAccountInformation : IAction<AccountInformationResult>
    {
        [JsonProperty("action")]
        public string Action { get; } = "account_info";

        [JsonProperty("account")]
        public string AccountNumber { get; set; }
        
        [JsonProperty("representative")]
        public bool Representative { get; set; }
        
        [JsonProperty("weight")]
        public bool Weight { get; set; }
        
        [JsonProperty("pending")]
        public bool Pending { get; set; }
        

        public GetAccountInformation(RaiAddress address, bool representative = false, bool weight = false, bool pending = false)
        {
            AccountNumber = address ?? throw new ArgumentNullException(nameof(address));
            Representative = representative;
            Weight = weight;
            Pending = pending;
        }
    }
}
