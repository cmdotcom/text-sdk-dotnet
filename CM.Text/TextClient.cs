using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CM.Text.BusinessMessaging;
using CM.Text.BusinessMessaging.Model;
using CM.Text.Common;
using JetBrains.Annotations;

namespace CM.Text
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
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Sends a message asynchronous.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<TextClientResult> SendMessageAsync(
            Message message,
            CancellationToken cancellationToken = default(CancellationToken));
    }

    /// <summary>
    ///     This class provides methods to send text messages.
    /// </summary>
    [PublicAPI]
    public class TextClient : ITextClient
    {
        private static readonly Lazy<HttpClient> ClientSingletonLazy = new Lazy<HttpClient>();
        private readonly Guid _apiKey;
        [CanBeNull] private readonly Uri _endPointOverride;
        private readonly HttpClient _httpClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextClient" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        [PublicAPI]
        [SuppressMessage("ReSharper", "IntroduceOptionalParameters.Global", Justification = "Backwards compatibility")]
        public TextClient(Guid apiKey) : this(apiKey, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextClient" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="httpClient">An optional HTTP client.</param>
        [PublicAPI]
        [SuppressMessage("ReSharper", "IntroduceOptionalParameters.Global", Justification = "Binary backwards compatibility")]
        public TextClient(Guid apiKey, [CanBeNull] HttpClient httpClient): this(apiKey, httpClient, null)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="TextClient" /> class.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="httpClient">An optional HTTP client.</param>
        /// <param name="endPointOverride">(Optional) The end point to use, instead of the default "https://gw.cmtelecom.com/v1.0/message".</param>
        [PublicAPI]
        public TextClient(Guid apiKey, [CanBeNull] HttpClient httpClient, [CanBeNull] Uri endPointOverride)
        {
            this._apiKey = apiKey;
            this._httpClient = httpClient ?? ClientSingletonLazy.Value;
            this._endPointOverride = endPointOverride;
        }

        /// <inheritdoc />
        [PublicAPI]
        public async Task<TextClientResult> SendMessageAsync(
            string messageText,
            string from,
            IEnumerable<string> to,
            string reference,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var request = new HttpRequestMessage(
                       HttpMethod.Post,
                       this._endPointOverride ?? new Uri(Constant.BusinessMessagingGatewayJsonEndpoint)
                   ))
            {
                request.Content = new StringContent(
                    BusinessMessagingApi.GetHttpPostBody(this._apiKey, messageText, from, to, reference),
                    Encoding.UTF8,
                    Constant.BusinessMessagingGatewayMediaTypeJson
                );

                using (var requestResult = await this._httpClient.SendAsync(request, cancellationToken)
                    .ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    return BusinessMessagingApi.GetTextApiResult(
                        await requestResult.Content.ReadAsStringAsync()
                            .ConfigureAwait(false)
                    );
                }
            }
        }

        /// <summary>
        ///     Sends a message asynchronously.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [PublicAPI]
        public async Task<TextClientResult> SendMessageAsync(
            Message message,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var request = new HttpRequestMessage(
                HttpMethod.Post,
                this._endPointOverride ?? new Uri(Constant.BusinessMessagingGatewayJsonEndpoint)
            ))
            {
                request.Content = new StringContent(
                    BusinessMessagingApi.GetHttpPostBody(this._apiKey, message),
                    Encoding.UTF8,
                    Constant.BusinessMessagingGatewayMediaTypeJson
                );

                using (var requestResult = await this._httpClient.SendAsync(request, cancellationToken)
                    .ConfigureAwait(false))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    return BusinessMessagingApi.GetTextApiResult(
                        await requestResult.Content.ReadAsStringAsync()
                            .ConfigureAwait(false)
                    );
                }
            }
        }
    }
}
