using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    public class ApplePayRequest : IRichMessage
    {
        [JsonProperty("payment")]
        public ApplePayConfiguration ApplePayConfiguration { get; set; }
    }
}
