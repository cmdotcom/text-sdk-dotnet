using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    /// Used to send one or multiple contacts, for now only supported in <see cref="Channel.WhatsApp"/>.
    ///
    /// See also https://developers.facebook.com/docs/whatsapp/api/messages/others#contacts
    /// </summary>
    [PublicAPI]
    public class ContactMessage : IRichMessage
    {
        /// <summary>
        /// The contacts to send.
        /// 
        /// See also https://developers.facebook.com/docs/whatsapp/api/messages/others#contacts
        /// </summary>
        [JsonPropertyName("contacts")]
        public Contact[] Contacts { get; set; }
        
        /// <summary>
        /// Contextual properties of the message
        /// </summary>
        [JsonPropertyName("context")]
        [CanBeNull]
        public MessageContext MessageContext { get; set; }
    }

    /// <summary>
    /// Represents 1 contact.
    /// See also https://developers.facebook.com/docs/whatsapp/api/messages/others#contacts
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Full contact address(es)
        /// </summary>
        [JsonPropertyName("addresses")]
        public ContactAddress[] ContactAddresses { get; set; }

        /// <summary>
        /// YYYY-MM-DD formatted string of the birthday of the contact
        /// </summary>
        [JsonPropertyName("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// Contact email address(es)
        /// </summary>
        [JsonPropertyName("emails")]
        public ContactEmail[] EmailAddresses { get; set; }

        /// <summary>
        /// Full contact name
        /// </summary>
        [JsonPropertyName("name")]
        public ContactName Name { get; set; }

        /// <summary>
        /// Contact organization information
        /// </summary>
        [JsonPropertyName("org")]
        public ContactOrganization Organization { get; set; }

        /// <summary>
        /// Contact phone number(s)
        /// </summary>
        [JsonPropertyName("phones")]
        public ContactPhoneNumber[] PhoneNumbers { get; set; }

        /// <summary>
        /// Contact URL(s)
        /// </summary>
        [JsonPropertyName("urls")]
        public ContactUrl[] Urls { get; set; }
    }

    /// <summary>
    /// One address of a contact
    /// See also https://developers.facebook.com/docs/whatsapp/api/messages/others#contacts
    /// </summary>
    public class ContactAddress
    {
        /// <summary>
        /// City name
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }
        /// <summary>
        /// Full country name
        /// </summary>
        [JsonPropertyName("country")]
        public string Country { get; set; }
        /// <summary>
        /// Two-letter country abbreviation
        /// </summary>
        [JsonPropertyName("country_code")]
        public string CountryCode { get; set; }
        /// <summary>
        /// State abbreviation
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }
        /// <summary>
        /// Street number and name
        /// </summary>
        [JsonPropertyName("street")]
        public string Street { get; set; }
        /// <summary>
        /// Standard Values: HOME, WORK
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
        /// <summary>
        /// ZIP code
        /// </summary>
        [JsonPropertyName("zip")]
        public string ZipCode { get; set; }
    }

    /// <summary>
    /// One email address of a contact.
    /// See also https://developers.facebook.com/docs/whatsapp/api/messages/others#contacts
    /// </summary>
    public class ContactEmail
    {
        /// <summary>
        /// Email address
        /// </summary>
        [JsonPropertyName("email")]
        public string EmailAddress { get; set; }
        /// <summary>
        /// Standard Values: HOME, WORK
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// The name of a contact.
    /// See also https://developers.facebook.com/docs/whatsapp/api/messages/others#contacts
    /// </summary>
    public class ContactName
    {
        /// <summary>
        /// First name
        /// </summary>
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }
        /// <summary>
        /// Last name
        /// </summary>
        [JsonPropertyName("last_name")]
        public string LastName { get; set; }
        /// <summary>
        /// Middle name
        /// </summary>
        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }
        /// <summary>
        /// Name prefix
        /// </summary>
        [JsonPropertyName("name_prefix")]
        public string NamePrefix { get; set; }
        /// <summary>
        /// Name suffix
        /// </summary>
        [JsonPropertyName("name_suffix")]
        public string NameSuffix { get; set; }
        /// <summary>
        /// Full name as it normally appears
        /// </summary>
        [JsonPropertyName("formatted_name")]
        public string FormattedName { get; set; }
    }
    /// <summary>
    /// The organization of a contact
    /// See also https://developers.facebook.com/docs/whatsapp/api/messages/others#contacts
    /// </summary>
    public class ContactOrganization
    {
        /// <summary>
        /// Name of the contact's company
        /// </summary>
        [JsonPropertyName("company")]
        public string Company { get; set; }
        /// <summary>
        /// Name of the contact's department
        /// </summary>
        [JsonPropertyName("department")]
        public string Department { get; set; }
        /// <summary>
        /// Contact's business title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    /// <summary>
    /// Phone number of a contact
    /// </summary>
    public class ContactPhoneNumber
    {
        /// <summary>
        /// The phone number of the contact
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        /// <summary>
        /// Standard Values: CELL, MAIN, IPHONE, HOME, WORK
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }

    /// <summary>
    /// An Url for a contact
    /// See also https://developers.facebook.com/docs/whatsapp/api/messages/others#contacts
    /// </summary>
    public class ContactUrl
    {
        /// <summary>
        /// URL
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }
        /// <summary>
        /// Standard Values: HOME, WORK
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
