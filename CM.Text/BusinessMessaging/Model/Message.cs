using System;
using CM.Text.BusinessMessaging.Model.MultiChannel;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CM.Text.BusinessMessaging.Model {
    /// <summary>
    /// Represents one message. One message can be sent to multiple recipients.
    /// </summary>
    [PublicAPI]
    public class Message {
        /// <summary>
        /// Optional: For each message you send, you can set a reference.
        /// The given reference will be used in the status reports and MO replies for the message,
        /// so you can link the messages to the sent batch.
        /// For more information on status reports, see: https://docs.cmtelecom.com/business-messaging/v1.0#/status_report_webhook
        /// 
        /// The given reference must be between 1 - 32 alphanumeric characters, and will not work using demo accounts.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "reference")]
        public string Reference { get; set; }
        /// <summary>
        /// Required: This is the sender name.
        /// The maximum length is 11 alphanumerical characters or 16 digits. Example: 'CM Telecom'
        /// </summary>
        [JsonProperty("from")]
        public string From { get; set; }
        /// <summary>
        /// Required: The destination mobile numbers.
        /// This value should be in international format.
        /// A single mobile number per request. Example: '00447911123456'
        /// </summary>
        [JsonProperty("to")]
        public Recipient[] Recipients { get; set; }
        /// <summary>
        /// Required: The actual text body of the message.
        /// </summary>
        [JsonProperty("body")]
        public Body Body { get; set; }
        /// <summary>
        /// The custom grouping field is an optional field that can be used to tag messages.
        /// These tags are be used by CM products, like the Transactions API.
        /// 
        /// Applying custom grouping names to messages helps filter your messages.
        /// With up to three levels of custom grouping fields that can be set, subsets of messages can be
        /// further broken down. The custom grouping name can be up to 100 characters of your choosing.
        /// 
        /// It’s recommended to limit the number of unique custom groupings to 1000.
        /// Please contact support in case you would like to exceed this number.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "customGrouping")]
        public string CustomGrouping { get; set; }
        /// <summary>
        /// The custom grouping2 field, like <see cref="CustomGrouping"/> is an optional field that can be used to tag messages.
        /// These tags are be used by CM products, like the Transactions API.
        /// 
        /// Applying custom grouping names to messages helps filter your messages.
        /// With up to three levels of custom grouping fields that can be set, subsets of messages can be
        /// further broken down. The custom grouping name can be up to 100 characters of your choosing.
        /// 
        /// It’s recommended to limit the number of unique custom groupings to 1000.
        /// Please contact support in case you would like to exceed this number.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "customGrouping2")]
        public string CustomGrouping2 { get; set; }
        /// <summary>
        /// The custom grouping3 field, like <see cref="CustomGrouping"/> and <see cref="CustomGrouping2"/> is an optional field that can be used to tag messages.
        /// These tags are be used by CM products, like the Transactions API.
        /// 
        /// Applying custom grouping names to messages helps filter your messages.
        /// With up to three levels of custom grouping fields that can be set, subsets of messages can be
        /// further broken down. The custom grouping name can be up to 100 characters of your choosing.
        /// 
        /// It’s recommended to limit the number of unique custom groupings to 1000.
        /// Please contact support in case you would like to exceed this number. 
        /// </summary>
        /// <remarks>Default value within this SDK is <see cref="Common.Constant.TextSdkReference"/></remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "customGrouping3")]
        public string CustomGrouping3 { get; set; }
        /// <summary>
        /// Used when sending multipart or concatenated SMS messages and always used together with <see cref="MaximumNumberOfMessageParts"/>.
        /// Indicate the minimum and maximum of message parts that you allow the gateway to send for this
        /// message.
        /// Technically the gateway will first check if a message is larger than 160 characters, if so, the
        /// message will be cut into multiple 153 characters parts limited by these parameters.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "minimumNumberOfMessageParts")]
        public int? MinimumNumberOfMessageParts { get; set; }
        /// <summary>
        /// Used when sending multipart or concatenated SMS messages and always used together with <see cref="MinimumNumberOfMessageParts"/>.
        /// Indicate the minimum and maximum of message parts that you allow the gateway to send for this
        /// message.
        /// Technically the gateway will first check if a message is larger than 160 characters, if so, the
        /// message will be cut into multiple 153 characters parts limited by these parameters.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "maximumNumberOfMessageParts")]
        public int? MaximumNumberOfMessageParts { get; set; }

        /// <summary>
        /// The allowed channels field forces a message to only use certain routes.
        /// In this field you can define a list of which channels you want your message to use.
        /// Not defining any channels will be interpreted as allowing all channels.
        /// </summary>
        /// <remarks>Note that for channels other than SMS, CM needs to configure the out going flows.
        /// For those flows to work, we need to be contacted.</remarks>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "allowedChannels", ItemConverterType = typeof(StringEnumConverter))]
        public Channel[] AllowedChannels { get; set; }

        /// <summary>
        /// Used for Hybrid messaging, see https://docs.cmtelecom.com/en/hybrid-messaging/v2.0.0 for more information
        /// Messages will be sent over the <see cref="Channel.Push"/> channel.
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, PropertyName = "appKey")]
        public Guid HybridAppKey { get; set; }

        /// <summary>
        /// Can be used by channels that support rich content (all channels except <see cref="Channel.SMS"/>,
        /// <see cref="Channel.Voice"/> and <see cref="Channel.Push"/> at this moment)
        /// </summary>
        public RichContent RichContent { get; set; }
    }
}
