namespace CM.Text.Common
{
    internal static class Constant
    {
        internal static readonly string TextSdkReference = $"text-sdk-dotnet-{typeof(TextClient).Assembly.GetName().Version}";

        internal const string BusinessMessagingGatewayJsonEndpoint = "https://gw.messaging.cm.com/v1.0/message";
        
        internal const string OtpRequestEndpoint = "https://api.cm.com/otp/v2/otp";
        internal const string OtpVerifyEndpointFormatter = "https://api.cm.com/otp/v2/otp/{0}/verify";
        
        internal static readonly string BusinessMessagingGatewayMediaTypeJson = "application/json";
        internal static readonly string BusinessMessagingBodyTypeAuto = "AUTO";
        internal static readonly int BusinessMessagingMessagePartsMinDefault = 1;
        internal static readonly int BusinessMessagingMessagePartsMaxDefault = 8;
    }
}
