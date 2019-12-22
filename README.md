![GitHub release (latest by date)](https://img.shields.io/github/v/release/kate-orlova/sendgrid-email-provider-for-kentico)
[![GitHub release](https://img.shields.io/github/release-date/kate-orlova/sendgrid-email-provider-for-kentico.svg?style=flat)](https://github.com/kate-orlova/sendgrid-email-provider-for-kentico/releases/tag/MVPRelease)
[![GitHub license](https://img.shields.io/github/license/kate-orlova/sendgrid-email-provider-for-kentico.svg)](https://github.com/kate-orlova/sendgrid-email-provider-for-kentico/blob/master/LICENSE)
![GitHub language count](https://img.shields.io/github/languages/count/kate-orlova/sendgrid-email-provider-for-kentico.svg?style=flat)
![GitHub top language](https://img.shields.io/github/languages/top/kate-orlova/sendgrid-email-provider-for-kentico.svg?style=flat)
![GitHub repo size](https://img.shields.io/github/repo-size/kate-orlova/sendgrid-email-provider-for-kentico.svg?style=flat)

# SendGrid Email Provider for Kentico
SendGrid Email Provider for Kentico project is an extension for your Kentico solution to enable use of [SendGrid](https://sendgrid.com/) as SMTP Server. The project contains a _SendGridEmailProvider_ class implementing the integration with [SendGrid API version 3](https://sendgrid.com/docs/API_Reference/api_v3.html). It also uses the standard out-of-the-box Kentico features such as the email queue support and error logging into the Kentico Event Log.

# Configuration Guide
1. Include _SendGridEmailProviderForKentico_ project into your Kentico solution
1. Restore Nuget packages for _SendGridEmailProviderForKentico_ project
1. Check Kentico references in SendGridEmailProviderForKentico project (the ones pointing to _/lib/_ folder) and make sure that you use your Kentico assemblies 
1. Install Nuget package _"Sendgrid"_ version "9.10.0" in your _Kentico CMSApp_
1. Register for your SendGrid account
1. Modify _SendGridEmailProvider.cs_ to utilise your _SendGrid API key_ from settings
1. Build and run

That is all, you are ready to send emails from your Kentico site via SendGrid.

# Contribution
Hope you found the above solution helpful, your contributions and suggestions will be very much appreciated. Please submit a pull request with your code enhancements.

# License
The SendGrid Email Provider for Kentico is released under the MIT license what means that you can modify and use it how you want even for commercial use. Please give it a star if you like it and your experience was positive.
