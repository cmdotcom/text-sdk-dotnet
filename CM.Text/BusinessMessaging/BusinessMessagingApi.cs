using System;
using System.Collections.Generic;
using System.Linq;
using CM.Text.BusinessMessaging.Model;
using Newtonsoft.Json;

namespace CM.Text.BusinessMessaging
{
    internal static partial class BusinessMessagingApi
    {
        /// <summary>
        /// Transforms the BusinessMessageApi request result to TextClientResult.
        /// </summary>
        /// <param name="requestResultContent">Content of the request result.</param>
        /// <returns></returns>
        internal static TextClientResult GetTextApiResult(string requestResultContent)
        {
            var deserializedResponse = JsonConvert.DeserializeObject<Response.HttpResponseBody>(requestResultContent);

            return new TextClientResult
            {
                statusMessage = deserializedResponse.details,
                statusCode = (TextClientStatusCode) deserializedResponse.errorCode,
                details = deserializedResponse.messages.Select(message => new TextClientMessageDetail
                {
                    reference = message.reference,
                    status = message.status,
                    to = message.to,
                    parts = message.parts,
                    details = message.messageDetails
                }).ToArray()
            };
        }

        /// <summary>
        /// Gets the HTTP post body.
        /// </summary>
        /// <param name="apiKey">The API key.</param>
        /// <param name="messageText">The message text.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        /// <param name="reference">The reference.</param>
        /// <returns></returns>
        internal static string GetHttpPostBody(Guid apiKey, string messageText, string from, IEnumerable<string> to, string reference)
        {
            return JsonConvert.SerializeObject(new
            { 
                messages = new Request.Messages
                {
                    authentication = new Request.Authentication { producttoken = apiKey.ToString() },
                    msg = new List<Request.Message>
                    {
                        new Request.Message
                        {
                            reference = reference,
                            from = from,
                            body = new Request.Body {content = messageText, type = Constant.BusinessMessagingBodyTypeAuto},
                            to = to.Select(toEntry => new Request.To {number = toEntry}).ToArray(),
                            customGrouping3 = Common.Constant.TextSdkReference
                        }
                    }.ToArray()
                }
            });
        }
    }
}
