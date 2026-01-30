
<div align="center">

[![.NET build & tests](https://github.com/cmdotcom/text-sdk-dotnet/actions/workflows/main.yml/badge.svg)](https://github.com/cmdotcom/text-sdk-dotnet/actions/workflows/main.yml)
[![NuGet Version](https://img.shields.io/nuget/v/CM.Text.svg?logo=nuget&color=0078d7&label=version)](https://www.nuget.org/packages/CM.Text)
[![NuGet Downloads](https://img.shields.io/nuget/dt/CM.Text.svg?logo=nuget&color=green&label=downloads)](https://www.nuget.org/packages/CM.Text)

# CM Text SDK .NET

**Send SMS, WhatsApp, RCS, iMessage and more — the modern way.**

Powerful .NET client for [CM.com Messaging APIs](https://developers.cm.com/messaging/docs)

</div>

## ✨ Features

- Plain SMS / text messaging  
- Rich messages (images, media) — WhatsApp, RCS, …  
- WhatsApp **template messages** (simple, rich, currency/date, interactive)  
- WhatsApp **interactive messages** (lists, reply buttons + media)  
- Apple Business Chat **Apple Pay requests**  
- One-Time Password (**OTP**) sending & verification  

## 🚀 Quick Start

```csharp
using CM.Text;

// Keep your key secret!
var apiKey = Guid.Parse("your-product-token-here");
var client = new TextClient(apiKey);

// Simple SMS
var result = await client.SendMessageAsync(
    message: "Hello from C# 🚀",
    sender: "MyBrand",
    recipients: new[] { "+31612345678" },
    reference: "msg-001"
);
```

> `SendMessageAsync` returns a `TextClientResult` object with status & delivery details.

## 📖 Table of Contents

<details open>
<summary>Core Usage</summary>

### Instantiate the client

```csharp
var client = new TextClient(Guid.Parse("your-api-key"));
```

### Send plain text message(s)

```csharp
var result = await client.SendMessageAsync(
    "Welcome! Your order is confirmed.",
    "ShopName",
    new List<string> { "+310612345678", "+31698765432" },
    "order-1234"
);
```

</details>

<details>
<summary>Rich Messages (WhatsApp, RCS, …)</summary>

Use `MessageBuilder` for media attachments

```csharp
var builder = new MessageBuilder(
    "Check out our new collection!",
    "FashionStore",
    "+31612345678"
);

builder
    .WithAllowedChannels(Channel.WhatsApp)
    .WithRichMessage(
        new MediaMessage(
            "cm.com logo",
            "https://avatars3.githubusercontent.com/u/8234794?s=200&v=4",
            "image/png"
        )
    );

var message = builder.Build();
var result = await client.SendMessageAsync(message);
```

</details>

<details>
<summary>WhatsApp Template Messages</summary>

**Important:** Template must be approved by WhatsApp first

#### Basic template

```csharp
var builder = new MessageBuilder("ignored", "ignored", "+316xxxxxxxx");

builder
    .WithAllowedChannels(Channel.WhatsApp)
    .WithTemplate(new TemplateMessage
    {
        Content = new TemplateMessageContent
        {
            Whatsapp = new WhatsappTemplate
            {
                Name = "hello_world",
                Namespace = "xxxxxxxx_xxxx_xxxx_xxxx_xxxxxxxxxxxx",
                Language = new Language { Code = "en", Policy = "deterministic" },
                Components = new[]
                {
                    new TemplateComponents
                    {
                        Type = "body",
                        ComponentParameters = new[]
                        {
                            new ComponentParameters { Type = "text", Text = "John" }
                        }
                    }
                }
            }
        }
    });

var result = await client.SendMessageAsync(builder.Build());
```

#### Rich template (image header)

```csharp
builder.WithTemplate(new TemplateMessage
{
    Content = new TemplateMessageContent
    {
        Whatsapp = new WhatsappTemplate
        {
            Name      = "welcome_template",
            Namespace = "xxxxxxxx_xxxx_xxxx_xxxx_xxxxxxxxxxxx",
            Language  = new Language { Code = "en", Policy = "deterministic" },
            Components = new[]
            {
                new TemplateComponents
                {
                    Type = "header",
                    ComponentParameters = new[]
                    {
                        new ComponentParameters
                        {
                            Type = "image",
                            Media = new MediaContent
                            {
                                MediaName = "welcome",
                                MediaUri  = "https://example.com/welcome.jpg"
                            }
                        }
                    }
                },
                new TemplateComponents
                {
                    Type = "body",
                    ComponentParameters = new[]
                    {
                        new ComponentParameters { Type = "text", Text = "Jane" }
                    }
                }
            }
        }
    }
});
```

#### Template with currency & date (UTC)

```csharp
// Add to Components array:
new TemplateComponents
{
    Type = "body",
    ComponentParameters = new[]
    {
        new ComponentParameters
        {
            Type = "currency",
            Currency = new TemplateCurrency
            {
                FallbackValue = "€49.99",
                Amount        = 499900,     // in smallest unit (cents)
                CurrencyCode  = "EUR"
            }
        },
        new ComponentParameters
        {
            Type = "date_time",
            DateTime = new TemplateDateTime(DateTime.UtcNow.AddDays(7))
        }
    }
}
```

</details>

<details>
<summary>WhatsApp Interactive Messages (no template required)</summary>

#### List message example

```csharp
builder
    .WithAllowedChannels(Channel.WhatsApp)
    .WithInteractive(new WhatsAppInteractiveMessage
    {
        whatsAppInteractiveContent = new WhatsAppInteractiveContent
        {
            Type = "list",
            Header = new InteractiveHeader { Type = "text", Text = "Our Menu" },
            Body   = new InteractiveBody   { Text = "What would you like today?" },
            Action = new InteractiveAction
            {
                Button = "View options",
                Sections = new[]
                {
                    new InteractiveSection
                    {
                        Title = "Drinks",
                        Rows = new[]
                        {
                            new Rows { Id = "cola",  Title = "Cola",  Description = "€2.50" },
                            new Rows { Id = "water", Title = "Water", Description = "€1.50" }
                        }
                    }
                }
            },
            Footer = new InteractiveFooter { Text = "Prices incl. VAT • Valid today only" }
        }
    });
```

#### Reply buttons + image

```csharp
builder
    .WithAllowedChannels(Channel.WhatsApp)
    .WithInteractive(new WhatsAppInteractiveMessage
    {
        whatsAppInteractiveContent = new WhatsAppInteractiveContent
        {
            Type = "button",
            Header = new InteractiveHeader
            {
                Type = "image",
                Media = new MediaContent { MediaUri = "https://example.com/product.jpg" }
            },
            Body = new InteractiveBody { Text = "Which size do you prefer?" },
            Action = new InteractiveAction
            {
                Buttons = new[]
                {
                    new InteractiveButton { Type = "reply", Reply = new ReplyMessage { Id = "s", Title = "Small"  } },
                    new InteractiveButton { Type = "reply", Reply = new ReplyMessage { Id = "m", Title = "Medium" } },
                    new InteractiveButton { Type = "reply", Reply = new ReplyMessage { Id = "l", Title = "Large"  } }
                }
            }
        }
    });
```

</details>

<details>
<summary>Apple Pay Request (Apple Business Chat / iMessage only)</summary>

```csharp
builder
    .WithAllowedChannels(Channel.iMessage)
    .WithApplePay(new ApplePayRequest
    {
        ApplePayConfiguration = new ApplePayConfiguration
        {
            Total               = 42.99m,
            RecipientCountryCode = "NL",
            CurrencyCode        = "EUR",
            Description         = "Premium Subscription – 1 month",
            RecipientEmail      = "customer@example.com",
            languageCountryCode = "en-NL",
            OrderReference      = Guid.NewGuid().ToString(),
            MerchantName        = "MyAwesomeShop",
            LineItems = new[]
            {
                new LineItem { Amount = 39.99m, Label = "Plan", Type = "final" },
                new LineItem { Amount =  3.00m, Label = "VAT",  Type = "final" }
            }
        }
    });

var message = builder.Build();
var result  = await client.SendMessageAsync(message);
```

</details>

<details>
<summary>One-Time Password (OTP)</summary>

```csharp
// Send OTP
var otpBuilder = new OtpRequestBuilder("MyApp", "+31612345678");
otpBuilder.WithMessage("Your verification code is {code}. Valid for 10 minutes.");

var otpResult = await client.SendOtpAsync(otpBuilder.Build());

// Verify later
var verifyResult = client.VerifyOtp(otpResult.OtpId, "483920");
bool isValid = verifyResult.Verified;
```

→ More advanced OTP options: [developers.cm.com/identity/docs/one-time-password-create](https://developers.cm.com/identity/docs/one-time-password-create)

</details>

## 📄 Status & Result

All send operations return a `TextClientResult` object.

Example success response:

```json
{
  "statusMessage": "Created 1 message(s)",
  "statusCode": 201,
  "details": [
    {
      "reference": "order-1234",
      "status": "Accepted",
      "to": "+31612345678",
      "parts": 1
    }
  ]
}
```

See `TextClientStatusCode` enum for all possible status values.

## 🔗 Useful Links

- 🌐 [Official Messaging Documentation](https://developers.cm.com/messaging/docs)  
- 📦 [NuGet Package – CM.Text](https://www.nuget.org/packages/CM.Text)  
- 🐛 [Report Issues / Contribute](https://github.com/cmdotcom/text-sdk-dotnet/issues)  

Happy messaging! 🚀
