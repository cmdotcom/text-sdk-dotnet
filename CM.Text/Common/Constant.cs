namespace CM.Text.Common
{
    internal static class Constant
    {
        internal static readonly string TextSdkReference = "text-sdk-dotnet-" +
                                                           typeof(TextClient).Assembly.GetName()
                                                               .Version;
    }
}
