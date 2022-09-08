namespace CM.Text.Common
{
    internal static class Constant
    {
        internal static readonly string TextSdkReference = $"text-sdk-dotnet-{typeof(TextClient).Assembly.GetName().Version}";

        internal static readonly string BusinessMessagingGatewayJsonEndpoint = "http://gateway.staging.messaging.cmgroep.local/v1.0/message";
        internal static readonly string BusinessMessagingGatewayMediaTypeJson = "application/json";
        internal static readonly string BusinessMessagingBodyTypeAuto = "AUTO";
        internal static readonly int BusinessMessagingMessagePartsMinDefault = 1;
        internal static readonly int BusinessMessagingMessagePartsMaxDefault = 8;
    }
}
