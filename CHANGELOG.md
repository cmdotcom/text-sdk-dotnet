# Changelog
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.10.0] - TBD
### Changed
- Add Context.MessageId on RichMessages supporting WhatsApp for referencing a previous message
- Updated `System.Text.Json` to 8.0.5 fixing a [high impact security vulnerability](https://github.com/advisories/GHSA-hh2w-p6rv-4g7w)

## [2.9.0] - 2024-06-20
### Changed
- New global messaging endpoint

## [2.8.0] - 2024-01-08
### Added
- Implementing OTP Request and verify

## [2.7.0] - 2023-06-26
### Added
- Whatsapp Multi-Product Template Messages

## [2.6.0] - 2022-12-07
### Added
- System.Text.Json, replaces Newtsonsoft, possibly breaking
- Add Telegram as tag for the project
- Multi target to .NET 7 and use .NET 7 included System.Text.Json
### Changed
- Enable "Treat Warnings as Errors" to adhere to code guidelines
- Give internal response body messagerrorcode the correct type
- Some internal refactoring
- Changed PackageIconUrl > PackageIcon and added icon manually as it PackageIconUrl was deprecated
- Change RichContent interface to support derived types
### Removed 
- Newtsonsoft.Json dependency

## [2.5.2] - 2022-10-14
- Enable nupkg generation in project

## [2.5.1] - 2022-10-12
- Upped Newtonsoft.Json

## [2.5.0] - 2022-06-17
- Add Telegram

## [2.4.1] - 2022-02-01
- Fix support for a custom end point URI in second SendMessage method

## [2.4.0] - 2022-01-31
- Fix failure on body.type set to null
- Add support for a custom end point URI

## [2.3.0] - 2021-10-27
- Add TextClientFactory

## [2.2.1] - 2021-09-10
- Add support for reply buttons with media

## [2.2.0] - 2021-09-09
- Add support for interactive whatsapp messages

## [2.1.0] - 2021-07-08
- Ignore HybridAppKey when null instead of empty, to support Notifire flow of channel MobilePush
- Add DefaultValueHandling to RichContent property of Message model.
- Add Tag property to TextMessage model used within a rich message.
- Add Suggestions property to TextMessage model used within a rich message.
- Add AppleBusinessChat as channel type, and marked iMessage as obsolete.

## [2.0.6] - 2021-07-06
- Add Instagram

## [2.0.5] - 2021-05-25
- Correct JSON formatting of MediaContent

## [2.0.4] - 2021-05-20
- Added media en description to ReplySuggestion

## [2.0.3] - 2021-04-08
- Add Facebook Messenger and Google Business Messages channel

## [2.0.2] - 2020-12-23
- Add MobilePush channel

## [2.0.1] - 2020-11-23
- Add support for interactive templates

## [2.0.0] - 2020-08-26
- Removed Localizable Params because it is Deprecated by Facebook,
- Also updated the WhatsApp Template Signature based on Facebook spec updates.

## [1.8.0] - 2020-06-24
- Add Twitter support

## [1.7.0] - 2020-02-14
- Able to set validity period. (@GuidoNeele)
- Fixed issue when adding suggestions.
- Resolved typo's in documentation.

## [1.6.1] - 2020-02-14
- Version is equal to 1.7.0, due to not working release flow.

## [1.6.0] - 2020-02-07
- Add Rich templates + ApplePay

## [1.5.2] - 2019-12-04
- Fix WhatsApp template signature (@Michel16867)

## [1.5.0] - 2019-11-01
- Added several RichFeatures.
 1. TemplateMessage
 2. LocationPushMessage
 3. ContactMessage

## [1.4.0] - 2019-03-05
- Fix typo in conversation

## [1.3.0] - 2019-02-26
- Add license information

## [1.2.0] - 2019-02-22
- Add multichannel options

## [1.1.0] - 2019-02-22
- Add option to pass http client to constructor

## [1.0.1] - 2018-11-08
- Initial release
