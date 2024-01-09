using System;
using System.Text.Json.Serialization;

namespace CM.Text.Identity
{
    /// <summary>
    /// The result of an OTP request.
    /// </summary>
    public class OtpResult
    {
        /// <summary>
        /// The identifier of the OTP.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
        /// <summary>
        /// The channel used to send the code.
        /// </summary>
        [JsonPropertyName("channel")]
        public string Channel { get; set; }
        /// <summary>
        /// Indicates if the code was valid.
        /// </summary>
        [JsonPropertyName("verified")]
        public bool Verified { get; set; }
        /// <summary>
        /// The date the OTP was created.
        /// </summary>
        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// The date the OTP will expire.
        /// </summary>
        [JsonPropertyName("expiresAt")]
        public DateTime ExpiresAt { get; set; }
    }
}
