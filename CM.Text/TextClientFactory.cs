using System;
using System.Net.Http;
using JetBrains.Annotations;

namespace CM.Text
{
    /// <summary>
    /// Factory to create <see cref="TextClient"/>s for different api keys
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
    /// 
    /// </summary>
    /// <seealso cref="CM.Text.ITextClientFactory" />
    [PublicAPI]
    public class TextClientFactory : ITextClientFactory
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TextClientFactory"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        public TextClientFactory(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        /// <inheritdoc />
        public ITextClient GetClient(Guid productToken)
        {
            return new TextClient(productToken, this._httpClient);
        }
    }
}
