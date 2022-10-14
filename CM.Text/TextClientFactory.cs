using System;
using System.Net.Http;
using CM.Text.Interfaces;
using JetBrains.Annotations;

namespace CM.Text
{
    /// <summary>
    ///     Interface to a factory to create <see cref="ITextClient"/>s for different api keys
    /// </summary>
    public interface ITextClientFactory
    {
        /// <summary>
        /// Gets a client for a specific product token.
        /// </summary>
        /// <param name="apiKey">The api key to use in the new client.</param>
        /// <returns></returns>
        ITextClient GetClient(Guid apiKey);
    }

    /// <summary>
    ///     Factory to create <see cref="TextClient"/>s for different api keys
    /// </summary>
    /// <seealso cref="CM.Text.ITextClientFactory" />
    [PublicAPI]
    public class TextClientFactory : ITextClientFactory
    {
        private readonly HttpClient _httpClient;
        [CanBeNull] private readonly Uri _endPointOverride;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextClientFactory"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="endPointOverride">(Optional) The end point to use, instead of the default "https://gw.cmtelecom.com/v1.0/message".</param>
        public TextClientFactory(HttpClient httpClient, Uri endPointOverride = null)
        {
            this._httpClient = httpClient;
            this._endPointOverride = endPointOverride;
        }

        /// <inheritdoc />
        public ITextClient GetClient(Guid productToken)
        {
            return new TextClient(productToken, this._httpClient, this._endPointOverride);
        }
    }
}
