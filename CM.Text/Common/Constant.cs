namespace CM.Text.Common
{
    internal static class Constant
    {
        internal static readonly string TextSdkReference = $"text-sdk-dotnet-{typeof(TextClient).Assembly.GetName().Version}";

        internal const string BusinessMessagingGatewayJsonEndpoint = "https://gw.cmtelecom.com/v1.0/message";
        internal static readonly string BusinessMessagingGatewayMediaTypeJson = "application/json";
        internal static readonly string BusinessMessagingBodyTypeAuto = "AUTO";
        internal static readonly int BusinessMessagingMessagePartsMinDefault = 1;
        internal static readonly int BusinessMessagingMessagePartsMaxDefault = 8;
    }
}
