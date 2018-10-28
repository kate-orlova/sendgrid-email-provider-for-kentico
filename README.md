# SendGrid Email Provider for Kentico
SendGridEmailProviderForKentico project is an extension for your Kentico solution to enable use of [SendGrid](https://sendgrid.com/) as SMTP Server. The project contains a SendGridEmailProvider class implementing the integration with [SendGrid API version 3](https://sendgrid.com/docs/API_Reference/api_v3.html). It also uses the standard out-of-the-box Kentico features such as the email queue support and error logging into the Event Log.

# Installation Guide
1. Include SendGridEmailProviderForKentico project into your Kentico solution
1. Restore Nuget packages for SendGridEmailProviderForKentico project
1. Check Kentico references in SendGridEmailProviderForKentico project (the ones pointing to /lib/ folder) and make sure that you use your Kentico assemblies 
1. Install Nuget package "Sendgrid" version "9.10.0" in your Kentico CMSApp
1. Modify SendGridEmailProvider.cs to utilise your SendGrid API key from settings
1. Build and run
1. That is all, you are ready to send emails from Kentico via SendGrid
