using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// Whatsapp template, see https://developers.facebook.com/docs/whatsapp/api/messages/message-templates for more information
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    /// <remarks>Templates need to be configured by CM and approved by Whatsapp before it is possible
    /// to send these messages.
    /// </remarks>
    [PublicAPI]
    public class WhatsappTemplate
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// The namespace that will be used
        /// </summary>
        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// The element name that indicates which template to use within the namespace
        /// </summary>
        [JsonProperty("element_name")]
        public string Name { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// Allows for the specification of a deterministic or fallback language.
        /// 
        /// The language parameter sets the language policy for an Message Template;
        /// you can set it to either fallback or deterministic.
        /// </summary>
        [JsonProperty("language")]
        public Language Language { get; set; }


        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// This field is an array of values to apply to variables in the template
        /// </summary>
        public TemplateComponents[] Components { get; set; }
    }

    /// <summary>
    /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
    /// This field is an array of values to apply to variables in the template
    /// </summary>
    [PublicAPI]
    public class LocalizableParam
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// 
        /// Default text if localization fails
        /// </summary>
        [JsonProperty("default")]
        public string Default { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// 
        /// If the currency object is used, it contains required parameters currency_code and amount_1000.
        /// </summary>
        [JsonProperty("currency")]
        public TemplateCurrency Currency { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// 
        /// If the date_time object is used, further definition of the date and time is required. 
        /// </summary>
        [JsonProperty("date_time")]
        public TemplateDateTime DateTime { get; set; }

    }

    /// <summary>
    /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
    ///
    /// Object to make it possible to use a localized currency format.
    /// If the currency object is used, it contains required parameters currency_code and amount_1000.
    /// </summary>
    [PublicAPI]
    public class TemplateCurrency
    {
        /// <summary>
        /// The Fallback amount
        /// </summary>
        [JsonProperty("fallback_value")]
        public string FallbackValue { get; set; }

        /// <summary>
        /// Currency code, for example USD or EUR
        /// </summary>
        [JsonProperty("code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Amount in currency_code times 1000
        /// </summary>
        /// <example>50110 EUR becomes €50.11 in the message</example>
        [JsonProperty("amount_1000")]
        public long Amount { get; set; }
    }

    /// <summary>
    /// Used to localize a date/time in a message based on the end-users settings.
    /// </summary>
    public class TemplateDateTime
    {
        /// <summary>
        /// The fallback date in UTC format
        /// </summary>
        /// <remarks>There will be no checking whether this is correct,</remarks>
        [JsonProperty("fallback_value")]
        public string FallbackValue { get; }

        /// <summary>
        /// The day of the week as specified in Facebook documentation
        /// Options: "MONDAY", 1, "TUESDAY", 2, "WEDNESDAY", 3, "THURSDAY", 4, "FRIDAY", 5, "SATURDAY", 6, "SUNDAY", 7
        /// see https://developers.facebook.com/docs/whatsapp/message-templates/localization
        /// 
        /// </summary>
        /// <remarks>There will be no checking whether this is correct,</remarks>
        [JsonProperty("day_of_week")]
        public int DayOfWeek { get; }
        /// <summary>
        /// The day of the month.
        /// </summary>
        [JsonProperty("day_of_month")]
        public int DayOfMonth { get; }
        /// <summary>
        /// The year.
        /// </summary>
        [JsonProperty("year")]
        public int Year { get; }
        /// <summary>
        /// The month.
        /// </summary>
        [JsonProperty("month")]
        public int Month { get; }
        /// <summary>
        /// The hour (24 hour notation)
        /// </summary>
        [JsonProperty("hour")]
        public int Hour { get; }
        /// <summary>
        /// The minute of the hour.
        /// </summary>
        [JsonProperty("minute")]
        public int Minute { get; }

        /// <summary>
        /// Constructor initializing the component.
        /// </summary>
        /// <param name="moment"></param>
        public TemplateDateTime(DateTime moment)
        {
            FallbackValue = moment.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
            Minute = moment.Minute;
            Hour = moment.Hour;
            Month = moment.Month;
            Year = moment.Year;
            DayOfMonth = moment.Day;
            DayOfWeek = moment.DayOfWeek == System.DayOfWeek.Friday ? 7 : (int)moment.DayOfWeek;
        }
    }


    /// <summary>
    /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
    /// The language parameter sets the language policy for an Message Template;
    /// you can set it to either fallback or deterministic.
    /// </summary>
    public class Language
    {
        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// The code of the language or locale to use — Accepts both language and language_locale formats (e.g., en and en_US).
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// Options: fallback, deterministic
        /// The language policy the message should follow
        /// </summary>
        [JsonProperty("policy")]
        public string Policy { get; set; }
    }
    /// <summary>
    /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
    /// Dynamic content of the message. Separated in in different sections.
    /// </summary>
    public class TemplateComponents
    {
        /// <summary>
        ///  Required. describes the component type. Possible values: header, content, footer.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///  Can be empty. describes the Type of button being created. Possible values: quick_reply, url.
        /// </summary>
        [JsonProperty("sub_type")]
        public string SubType { get; set; }
        /// <summary>
        ///  Can be empty. Position index of the button.
        /// You can have up to 3 buttons using index values of 0-2.
        /// </summary>
        [JsonProperty("index")]
        public int Index { get; set; }

        /// <summary>
        ///  Can be empty. Array containing the dynamic content of the message.
        /// </summary>
        [JsonProperty("parameters")]
        public ComponentParameters[] ComponentParameters { get; set; }
    }
    /// <summary>
    /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
    /// Dynamic content of a media template message.
    /// </summary>
    public class ComponentParameters
    {
        /// <summary>
        ///  Describes the parameter type. Possible values: text, currency, date_time, image, document.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Only to be filled in when `type` = `text`.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
        /// <summary>
        /// Only to be filled in when `type` = `document` or `image`.
        /// </summary>
        [JsonProperty("media")]
        public MediaContent Media { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// 
        /// Default text if localization fails
        /// </summary>
        [JsonProperty("default")]
        public string Default { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// 
        /// If the currency object is used, it contains required parameters currency_code and amount_1000.
        /// </summary>
        [JsonProperty("currency")]
        public TemplateCurrency Currency { get; set; }

        /// <summary>
        /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// 
        /// If the date_time object is used, further definition of the date and time is required. 
        /// </summary>
        [JsonProperty("date_time")]
        public TemplateDateTime DateTime { get; set; }

        /// <summary>
        /// Developer-defined payload that will be returned when the button is clicked in addition to the display text on the button
        /// Required for quick_reply buttons
        /// </summary>
        [JsonProperty("payload")]
        public string Payload { get; set; }
    }
}
