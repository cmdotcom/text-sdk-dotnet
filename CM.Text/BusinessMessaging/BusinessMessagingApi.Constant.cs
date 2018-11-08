namespace CM.Text.BusinessMessaging
{
    internal static partial class BusinessMessagingApi
    {
        internal static class Constant
        {
            internal const string BusinessMessagingGatewayJsonEndpoint = "https://gw.cmtelecom.com/v1.0/message";
            internal const string BusinessMessagingGatewayMediaTypeJson = "application/json";
            internal const string BusinessMessagingBodyTypeAuto = "AUTO";

            internal const int BusinessMessagingMessagePartsMinDefault = 1;
            internal const int BusinessMessagingMessagePartsMaxDefault = 8;
        }
    }
}
