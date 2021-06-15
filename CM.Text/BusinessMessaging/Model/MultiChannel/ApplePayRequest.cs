using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplePayRequest : IRichMessage
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("payment")]
        public ApplePayConfiguration ApplePayConfiguration { get; set; }
    }
}
