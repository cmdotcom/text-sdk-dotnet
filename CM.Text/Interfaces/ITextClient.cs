using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CM.Text.BusinessMessaging.Model;
using JetBrains.Annotations;

namespace CM.Text.Interfaces
{
    /// <summary>
    ///     Interface to the client to send text messages.
    /// </summary>
    public interface ITextClient
    {
        /// <summary>
        ///     Sends a message asynchronous.
        /// </summary>
        /// <param name="messageText">The message text.</param>
        /// <param name="from">
        ///     This is the sender name. The maximum length is 11 alphanumerical characters or 16 digits. Example: 'MyCompany'.<br/>
        ///     For Twitter: use the Twitter Snowflake ID of the account you want to use as sender.<br/>
        ///     For MobilePush: use the app key of the account you want to use as sender.<br/>
        ///     For Facebook Messenger: use the Facebook Page ID of the account you want to use as sender.<br/>
        ///     For Google Business Messages: use the Google Business Messages agent ID of the account you want to use as sender (without dashes).<br/>
        ///     For Instagram: use the Instagram Account ID of the account you want to use as sender.<br/>
        ///     For Telegram: use the Telegram Bot ID of the account you want to use as sender.
        /// </param>
        /// <param name="to">
        ///     These are the destination mobile numbers. Restrictions: this value should be in international format.
        ///     Example: '00447911123456'.<br/>
        ///     For Twitter: use the Twitter Snowflake ID.<br/>
        ///     For Facebook Messenger: use the Facebook Page Scoped User ID (PSID).<br/>
        ///     For Google Business Messages: use the Google Business Messages conversation ID (without dashes).<br/>
        ///     For Instagram: use the Instagram Scoped User ID (IGSID).<br/>
        ///     For Telegram: use the Telegram Chat ID.
        /// </param>
        /// <param name="reference">
        ///     Here you can include your message reference. This information will be returned in a status
        ///     report so you can match the message and it's status. Restrictions: 1 - 32 alphanumeric characters and reference
        ///     will not work for demo accounts.
        /// </param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TextClientResult> SendMessageAsync(
            string messageText,
            string from,
            IEnumerable<string> to,
            [CanBeNull] string reference,
            CancellationToken cancellationToken = default);

        /// <summary>
        ///     Sends a message asynchronous.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TextClientResult> SendMessageAsync(
            Message message,
            CancellationToken cancellationToken = default);
    }
}
