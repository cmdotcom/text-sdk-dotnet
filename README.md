[![Build](https://img.shields.io/appveyor/ci/cmdotcom/text-sdk-dotnet/master.svg "Build Status")](https://ci.appveyor.com/project/cmdotcom/text-sdk-dotnet/branch/master)
[![NuGetV](https://img.shields.io/nuget/v/CM.Text.svg "Nuget Version")](https://www.nuget.org/packages/CM.Text)
[![NuGetDownloads](https://img.shields.io/nuget/dt/CM.Text.svg "Nuget downloads")](https://www.nuget.org/packages/CM.Text)

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
For all possible status codes, please reference the `TextClientStatusCode` enum.


## Sending a WhatsApp template message
By using the `MessageBuilder` it is possible to create template messages. Please note that this is WhatsApp only and your template needs to be approved before sending.
For more info please check our documentation: https://docs.cmtelecom.com/en/api/business-messaging-api/1.0/index#whatsapp-template-message
```cs
var apiKey = new Guid(ConfigurationManager.AppSettings["ApiKey"]);
var client = new TextClient(apiKey);
var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");
builder
 .WithAllowedChannels(Channel.WhatsApp)
 .WithTemplate(new TemplateMessage() {
  Content = new TemplateMessageContent() {
   Whatsapp = new WhatsappTemplate() {
    Name = "template-name",
     Namespace = "the-namespace-of-template",
     Language = new Language() {
      Code = "en",
       Policy = "deterministic"
     },
     Components = new TemplateComponents[] {
      new TemplateComponents() {
       Type = "body",
        ComponentParameters = new ComponentParameters[] {
         new ComponentParameters() {
          Type = "text",
           Text = "firstname"
         }
        }
      },
     }
   }
  }
 });

var message = builder.Build();
var result = await client.SendMessageAsync(message);
```
## Sending a rich WhatsApp template message
It is also possible to send a rich template with an image!			
			
```cs
var apiKey = new Guid(ConfigurationManager.AppSettings["ApiKey"]);
var client = new TextClient(apiKey);
var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");
builder
 .WithAllowedChannels(Channel.WhatsApp)
 .WithTemplate(new TemplateMessage() {
  Content = new TemplateMessageContent() {
   Whatsapp = new WhatsappTemplate() {
    Name = "template-name",
     Namespace = "the-namespace-of-template",
     Language = new Language() {
      Code = "en",
       Policy = "deterministic"
     },
     Components = new TemplateComponents[] {
      new TemplateComponents() {
        Type = "header",
         ComponentParameters = new ComponentParameters[] {
          new ComponentParameters() {
           Type = "image",
            Media = new MediaContent() {
             MediaName = "cm.com",
              MediaUri = "https://avatars3.githubusercontent.com/u/8234794?s=200&v=4"
            }
          }
         }
       },
       new TemplateComponents() {
        Type = "body",
         ComponentParameters = new ComponentParameters[] {
          new ComponentParameters() {
           Type = "text",
            Text = "firstname"
          }
         }
       },
     }
   }
  }
 });

var message = builder.Build();
var result = await client.SendMessageAsync(message);
```
## Sending a WhatsApp template message with date and Currency
It is also possible to send a rich template with an currency and an date!
please note that the timezone is in UTC format		
			
```cs
var apiKey = new Guid(ConfigurationManager.AppSettings["ApiKey"]);
var client = new TextClient(apiKey);
var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");
 builder
 .WithAllowedChannels(Channel.WhatsApp)
 .WithTemplate(new TemplateMessage() {
  Content = new TemplateMessageContent() {
   Whatsapp = new WhatsappTemplate() {
                            Name = "template-name",
                            Namespace = "the-namespace-of-template",
                            Language = new Language()
                            {
                                Code = "en",
                                Policy = "deterministic"
                            },
                            Components = new TemplateComponents[] {
                                new TemplateComponents() {
                                    Type = "header",
                                    ComponentParameters = new ComponentParameters[] {
                                        new ComponentParameters() {
                                            Type = "image",
                                            Media = new MediaContent() {
                                                MediaName = "cm.com",
                                                MediaUri = "https://avatars3.githubusercontent.com/u/8234794?s=200&v=4"
                                            },
                                        }
                                    }
                                },
                                new TemplateComponents()
                                {
                                    Type = "body",
                                    ComponentParameters = new ComponentParameters[]
                                    {
                                        new ComponentParameters()
                                       {
                                           Type = "currency",
                                           Currency = new TemplateCurrency()
                                           {
                                               FallbackValue = "$100.99",
                                               Amount = 100990,
                                               CurrencyCode = "USD"
                                           }
                                       },
                                       new ComponentParameters()
                                       {
                                           Type = "date_time",
                                           DateTime = new TemplateDateTime(DateTime.Now)
                                       }
                                    }}
                            }
                        }
                    }
                });

   var message = builder.Build();
   var result = await client.SendMessageAsync(message);
```
## Sending an Apple Pay Request
It is now possible to send an apple pay request only possible in Apple Business Chat

```cs
var apiKey = new Guid(ConfigurationManager.AppSettings["ApiKey"]);
var client = new TextClient(apiKey);
var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");
 builder
        .WithAllowedChannels(Channel.iMessage)
        .WithApplePay(new ApplePayRequest()
           {
             ApplePayConfiguration = new ApplePayConfiguration()
                 {
                        Total = 1,
                        RecipientCountryCode = "recipient-country-code",
                        CurrencyCode = "currency-code",
                        Description = "product-description",
                        RecipientEmail = "recipient-email",
                        languageCountryCode = "language-country-code",
                        OrderReference = "unique-order-guid",
                        MerchantName = "merchant-name",
                        LineItems = new LineItem[]
                        {
                            new LineItem()
                            {
                                Amount = 1,
                                Label = "product-name",
                                Type = "final-or-pending"
                            },
                        }
                    }
                });
            
var message = builder.Build();
var result = await client.SendMessageAsync(message);
```
