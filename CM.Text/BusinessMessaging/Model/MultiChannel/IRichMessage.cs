using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model.MultiChannel
{
    /// <summary>
    ///     One element in a <see cref="RichContent.Conversation" />
    /// Requires a json derived type for serialization to work
    /// </summary>
    [PublicAPI]
    [JsonDerivedType(typeof(MediaMessage))]
    [JsonDerivedType(typeof(ApplePayRequest))]
    [JsonDerivedType(typeof(CarouselMessage))]
    [JsonDerivedType(typeof(ContactMessage))]
    [JsonDerivedType(typeof(LocationPushMessage))]
    [JsonDerivedType(typeof(TemplateMessage))]
    [JsonDerivedType(typeof(TextMessage))]
    [JsonDerivedType(typeof(WhatsAppInteractiveMessage))]
    public interface IRichMessage
    {
    }
}
