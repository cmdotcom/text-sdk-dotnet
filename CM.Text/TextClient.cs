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
using CM.Text.Interfaces;
using JetBrains.Annotations;

namespace CM.Text
{
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
            _apiKey = apiKey;
            _httpClient = httpClient ?? ClientSingletonLazy.Value;
            _endPointOverride = endPointOverride;
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
                       _endPointOverride ?? new Uri(Constant.BusinessMessagingGatewayJsonEndpoint)
                   ))
            {
                request.Content = new StringContent(
                    BusinessMessagingApi.GetHttpPostBody(_apiKey, messageText, from, to, reference),
                    Encoding.UTF8,
                    Constant.BusinessMessagingGatewayMediaTypeJson
                );

                using (var requestResult = await _httpClient.SendAsync(request, cancellationToken)
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
                _endPointOverride ?? new Uri(Constant.BusinessMessagingGatewayJsonEndpoint)
            ))
            {
                request.Content = new StringContent(
                    BusinessMessagingApi.GetHttpPostBody(_apiKey, message),
                    Encoding.UTF8,
                    Constant.BusinessMessagingGatewayMediaTypeJson
                );

                using (var requestResult = await _httpClient.SendAsync(request, cancellationToken)
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
