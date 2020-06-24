using JetBrains.Annotations;

namespace CM.Text.BusinessMessaging.Model
{
    /// <summary>
    ///     Used by <see cref="Message.AllowedChannels" /> to force a message to only use certain routes.
    /// </summary>
    /// <remarks>
    ///     Note that for channels other than SMS, CM needs to configure the out going flows.
    ///     For those flows to work, we need to be contacted.
    /// </remarks>
    [PublicAPI]
    public enum Channel
    {
        /// <summary>
        ///     Messages will be sent as SMS text messages
        /// </summary>
        SMS,

        /// <summary>
        ///     Send messages using WhatsApp for business
        /// </summary>
        /// <remarks>
        ///     Note that CM needs to configure this for you to work.
        /// </remarks>
        WhatsApp,

        /// <summary>
        ///     Sends messages to push using Hybrid messages.
        ///     See also https://docs.cmtelecom.com/en/hybrid-messaging/v2.0.0
        /// </summary>
        /// <remarks>Works only when <see cref="Message.HybridAppKey" /> is set</remarks>
        Push,

        /// <summary>
        ///     Messages will be sent over RCS.
        /// </summary>
        /// <remarks>
        ///     Note that CM needs to configure this for you to work.
        /// </remarks>
        RCS,

        /// <summary>
        ///     Messages will be sent over Viber.
        /// </summary>
        /// <remarks>
        ///     Note that CM needs to configure this for you to work.
        /// </remarks>
        Viber,

        /// <summary>
        ///     Messages will be sent using text to speech.
        /// </summary>
        /// <remarks>
        ///     Note that CM needs to configure this for you to work.
        /// </remarks>
        Voice,

        /// <summary>
        ///     Messages will be sent over Apple Business Chat.
        /// </summary>
        /// <remarks>
        ///     Note that CM needs to configure this for you to work.
        /// </remarks>
        // ReSharper disable once InconsistentNaming
        iMessage,

        /// <summary>
        ///     Messages will be sent over Line.
        /// </summary>
        /// <remarks>
        ///     Note that CM needs to configure this for you to work.
        /// </remarks>
        Line,

        /// <summary>
        ///     Messages will be sent over Twitter.
        /// </summary>
        /// <remarks>
        ///     Note that CM needs to configure this for you to work.
        /// </remarks>
        Twitter
    }
}
