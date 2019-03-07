﻿using System;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging.Model.MultiChannel {
    /// <summary>
    /// Whatsapp template, see https://developers.facebook.com/docs/whatsapp/api/messages/message-templates for more information
    /// Used only in <see cref="Channel.WhatsApp"/>.
    /// </summary>
    /// <remarks>Templates need to be configured by CM and approved by Whatsapp before it is possible
    /// to send these messages.
    /// </remarks>
    [PublicAPI]
    public class WhatsappTemplate {
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
        [JsonProperty("localizable_params")]
        public LocalizableParam[] LocalizableParams { get; set; }
    }

    /// <summary>
    /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
    /// This field is an array of values to apply to variables in the template
    /// </summary>
    [PublicAPI]
    public class LocalizableParam {
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
    public class TemplateCurrency {
        /// <summary>
        /// Currency code, for example USD or EUR
        /// </summary>
        [JsonProperty("currency_code")]
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
    public class TemplateDateTime {
        /// <summary>
        /// The date component as described in https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
        /// </summary>
        [JsonProperty("component")]
        public TemplateDateTimeComponent Component { get;  }

        /// <summary>
        /// Constructor initializing the component.
        /// </summary>
        /// <param name="moment"></param>
        public TemplateDateTime(DateTime moment) {
            Component = new TemplateDateTimeComponent(moment);
        }
    }

    /// <summary>
    /// Used to localize a date time as described in
    /// https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
    /// </summary>
    public class TemplateDateTimeComponent {
        /// <summary>
        /// The day of the week.
        /// </summary>
        /// <remarks>There will be no checking whether this is correct,</remarks>
        [JsonProperty("day_of_week")]
        public string DayOfWeek { get; }
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
        /// Constructor initializing the values.
        /// </summary>
        /// <param name="moment"></param>
        public TemplateDateTimeComponent(DateTime moment) {
            Minute = moment.Minute;
            Hour = moment.Hour;
            Month = moment.Month;
            Year = moment.Year;
            DayOfMonth = moment.Day;
            DayOfWeek = moment.DayOfWeek.ToString();
        }
    }
    /// <summary>
    /// Source: https://developers.facebook.com/docs/whatsapp/api/messages/message-templates
    /// The language parameter sets the language policy for an Message Template;
    /// you can set it to either fallback or deterministic.
    /// </summary>
    public class Language {
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
}
