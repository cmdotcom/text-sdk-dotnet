[![.NET build & tests](https://github.com/cmdotcom/text-sdk-dotnet/actions/workflows/main.yml/badge.svg)](https://github.com/cmdotcom/text-sdk-dotnet/actions/workflows/main.yml)
[![NuGetV](https://img.shields.io/nuget/v/CM.Text.svg "NuGet Version")](https://www.nuget.org/packages/CM.Text)
[![NuGetDownloads](https://img.shields.io/nuget/dt/CM.Text.svg "NuGet downloads")](https://www.nuget.org/packages/CM.Text)

# CM Text SDK
A software development kit to provide ways to interact with CM.com's Text service. API's used:
- [Business Messaging](https://www.cm.com/en-en/app/docs/api/business-messaging-api/1.0/index)

# Usage

## Instantiate the client
Using your unique `ApiKey` (or product token) which authorizes you on the CM platform. 
Always keep this key secret!

The product token can be found in the [Channels](https://www.cm.com/app/channels) application on the platform, under the `Gateway` section.

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
For more info please check our documentation: https://www.cm.com/en-en/app/docs/api/business-messaging-api/1.0/index#whatsapp-template-message
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
## Sending interactive template messages
Interactive templates allows you to send templates that include buttons. 
For more info please visit https://www.cm.com/app/docs/en/api/business-messaging-api/1.0/index#/whatsapp-template-message
```cs
var apiKey = new Guid(ConfigurationManager.AppSettings["ApiKey"]);
var client = new TextClient(apiKey);
var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");
builder.WithAllowedChannels(Channel.WhatsApp).WithTemplate(new TemplateMessage() {
	Content = new TemplateMessageContent() {
		Whatsapp = new WhatsappTemplate() {
			Name = "Template name",
			Namespace = "whatsapp template id",
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
							Text = "your message here"
						}
					}
				},
				new TemplateComponents() {
					Type = "button",
					SubType = "quick_reply",
					Index = 0,
					ComponentParameters = new ComponentParameters[] {
						new ComponentParameters() {
							Type = "payload",
							Payload = "developer defined payload"
						}
					}
				}
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
## Sending WhatsApp interactive messages
It is now possible to send list messages and reply buttons without using templates
only supported in WhatsApp

```cs
var apiKey = new Guid(ConfigurationManager.AppSettings["ApiKey"]);
var client = new TextClient(apiKey);
 var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");
     builder.WithAllowedChannels(Channel.WhatsApp).WithInteractive(new CM.Text.BusinessMessaging.Model.MultiChannel.WhatsAppInteractiveMessage()
            {
                whatsAppInteractiveContent = new CM.Text.BusinessMessaging.Model.MultiChannel.WhatsAppInteractiveContent()
                {
                    Type = "list",
                    Header = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveHeader()
                    {
                        Type = "text",
                        Text = "List message example"
                    },
                    Body = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveBody()
                    {
                        Text = "checkout our list message demo"
                    },
                    Action = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveAction()
                    {
                        Button = "button text",
                        Sections = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveSection[]
                         {
                             new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveSection()
                             {
                                 Title = "Select an option",
                                 Rows = new CM.Text.BusinessMessaging.Model.MultiChannel.Rows[]
                                 {
                                     new CM.Text.BusinessMessaging.Model.MultiChannel.Rows()
                                     {
                                         Id = "unique Id",
                                         Title = "unique title1",
                                         Description = "description text"
                                     },
                                     new CM.Text.BusinessMessaging.Model.MultiChannel.Rows()
                                     {
                                         Id = "unique Id2",
                                         Title = "unique title2",
                                         Description = "description text"
                                     },
                                 }
                             }
                         }
                    },
                    Footer = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveFooter()
                    {
                        Text = "footer text"
                    }
                }
        });
            
var message = builder.Build();
var result = await client.SendMessageAsync(message);
```

Only with Reply buttons you can send media like image,video or document 
see following example.

```cs
var apiKey = new Guid(ConfigurationManager.AppSettings["ApiKey"]);
var client = new TextClient(apiKey);
 var builder = new MessageBuilder("Message Text", "Sender_name", "Recipient_PhoneNumber");
    builder.WithAllowedChannels(Channel.WhatsApp).WithInteractive(new CM.Text.BusinessMessaging.Model.MultiChannel.WhatsAppInteractiveMessage()
            {
                whatsAppInteractiveContent = new CM.Text.BusinessMessaging.Model.MultiChannel.WhatsAppInteractiveContent()
                {
                    Type = "button",
                    Header = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveHeader()
                    {
                        Type = "image",                    
                        Media = new CM.Text.BusinessMessaging.Model.MultiChannel.MediaContent()
                         {
                                MediaUri = "https://www.cm.com/cdn/web/blog/content/logo-cmcom.png"
                          }
                        
                    },
                    Body = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveBody()
                    {
                        Text = "checkout our reply message demo"
                    },
                    Action = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveAction()
                    {
                        Buttons = new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveButton[]
                        {
                            new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveButton()
                            {
                               Type = "reply",
                                Reply = new CM.Text.BusinessMessaging.Model.MultiChannel.ReplyMessage()
                                {
                                    Id = "unique-postback-id1",
                                    Title = "First Button"
                                }
                            },
                               new CM.Text.BusinessMessaging.Model.MultiChannel.InteractiveButton()
                            {
                              Type = "reply",
                                Reply = new CM.Text.BusinessMessaging.Model.MultiChannel.ReplyMessage()
                                {
                                    Id = "unique-postback-id2",
                                    Title = "Second Button "
                                }
                            }
                        }
                    }
                }
            });
            
var message = builder.Build();
var result = await client.SendMessageAsync(message);
```
