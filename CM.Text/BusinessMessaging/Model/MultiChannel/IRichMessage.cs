using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     One element in a <see cref="RichContent.Conversation" />
    /// Requires a json derived type for serialization to work
    /// </summary>
    [PublicAPI]
    [JsonDerivedType(typeof(MediaMessage), nameof(MediaMessage))]
    [JsonDerivedType(typeof(ApplePayRequest), nameof(ApplePayRequest))]
    [JsonDerivedType(typeof(CarouselMessage), nameof(CarouselMessage))]
    [JsonDerivedType(typeof(ContactMessage), nameof(ContactMessage))]
    [JsonDerivedType(typeof(LocationPushMessage), nameof(LocationPushMessage))]
    [JsonDerivedType(typeof(TemplateMessage), nameof(TemplateMessage))]
    [JsonDerivedType(typeof(TextMessage), nameof(TextMessage))]
    [JsonDerivedType(typeof(WhatsAppInteractiveMessage), nameof(WhatsAppInteractiveMessage))]
    public interface IRichMessage
    {
    }
}
