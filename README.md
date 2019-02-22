[![Build](https://img.shields.io/appveyor/ci/rvnijnatten/text-sdk-dotnet/master.svg "Build Status")](https://ci.appveyor.com/project/rvnijnatten/text-sdk-dotnet/branch/master)
[![NuGetV](https://img.shields.io/nuget/v/CM.Text.svg "Nuget Version")](https://www.nuget.org/packages/CM.Text)
[![NuGetVPre](https://img.shields.io/nuget/vpre/CM.Text.svg "Nuget Prerelease Version")](https://www.nuget.org/packages/CM.Text)
[![NuGetDownloads](https://img.shields.io/nuget/dt/CM.Text.svg "Nuget downloads")](https://www.nuget.org/packages/CM.Text)
<!-- [![Test](https://img.shields.io/appveyor/tests/rvnijnatten/text-sdk-dotnet/master.svg "Test Status")](https://ci.appveyor.com/project/rvnijnatten/text-sdk-dotnet/branch/master/tests) -->

# CM Text SDK
A software development kit to provide ways to interact with CM.com's Text service. API's used:
- [Business Messaging](https://docs.cmtelecom.com/business-messaging/v1.0)

# Usage

## Instantiate the client
Using your unique `ApiKey` (or product token) which authorizes you on the CM platform. Always keep this key secret!

```cs
var client = new TextClient(new Guid(ConfigurationManager.AppSettings["ApiKey"]));
```

## Send a message
By calling `SendMessageAsync` and providing message text, sender name, recipient phone number(s) and a reference (optional).

```cs
var result = await client.SendMessageAsync("Message_Text", "Sender_Name", new List<string> { "Recipient_PhoneNumber" }, "Your_Reference").ConfigureAwait(false);
```

## Get the result
`SendMessageAsync` returns an object of type `TextClientResult`, example:

```cs
{
  "statusMessage": "Created 1 message(s)",
  "statusCode": 201,
  "details": [
    {
      "reference": "Example_Reference",
      "status": "Accepted",
      "to": "Example_PhoneNumber",
      "parts": 1,
      "details": null
    },
    {
      "reference": "Example_Reference2",
      "status": "Rejected",
      "to": "Example_PhoneNumber2",
      "parts": 0,
      "details": "A body without content was found"
    }
  ]
}
```

## Sending a rich message
By using the `MessageBuilder` it is possible to create images with media for channels such as WhatsApp and RCS
```cs
var apiKey = new Guid(ConfigurationManager.AppSettings["ApiKey"]);
var client = new TextClient(apiKey);
var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");
builder
    .WithAllowedChannels(Channel.WhatsApp)
    .WithRichMessage(
        new MediaMessage(
            "cm.com",
            "https://avatars3.githubusercontent.com/u/8234794?s=200&v=4",
            "image/png"
        )
    );
var message = builder.Build();
var result = await client.SendMessageAsync(message);
```

## Status codes
For all possibly returned status codes, please reference the `TextClientStatusCode` enum.
