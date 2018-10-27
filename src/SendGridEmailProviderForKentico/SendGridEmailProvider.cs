using CMS.EmailEngine;
using CMS.EventLog;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace SendGridEmailProviderForKentico
{
    public class SendGridEmailProvider : EmailProvider
    {
        protected override void SendEmailInternal(string siteName, MailMessage message, SMTPServerInfo smtpServer)
        {
            DispatchSendGridEmail(message);
        }

        private void DispatchSendGridEmail(MailMessage message, bool isAsync = false, EmailToken emailToken = null)
        {
            try
            {
                var client = new SendGridClient("Specify your SendGrid API key here");

                var messageForSendGrid = ConvertToSendGridMessage(message);
                var task = client.SendEmailAsync(messageForSendGrid);
                var result = task.Result;

                if (result.StatusCode != HttpStatusCode.Accepted)
                {
                    var response = result.Body.ReadAsStringAsync();
                    var body = response.Result;

                    throw new Exception(
                        $"Unsuccessful attempt to send email to {message.To}\nResponse Details.\nDateTime: {DateTime.Now}\nStatus code: {result.StatusCode}\nHeaders: {result.Headers}\nBody: {body}");
                }

                if (isAsync && emailToken != null)
                {
                    OnSendCompleted(new AsyncCompletedEventArgs(null, false, emailToken));
                }
            }
            catch (Exception exception)
            {
                EventLogProvider.LogException("SendGridEmailProvider", "DispatchSendGridEmail", exception);
                if (isAsync && emailToken != null)
                {
                    OnSendCompleted(new AsyncCompletedEventArgs(exception, false, emailToken));
                }
            }
        }

        private static SendGridMessage ConvertToSendGridMessage(MailMessage message)
        {
            var sgMessage =
                new SendGridMessage {From = new EmailAddress(message.From.Address, message.From.DisplayName)};

            foreach (var addressTo in message.To)
            {
                sgMessage.AddTo(new EmailAddress(addressTo.Address));
            }

            foreach (var addressCc in message.CC)
            {
                sgMessage.AddCc(new EmailAddress(addressCc.Address));
            }

            foreach (var addressBcc in message.Bcc)
            {
                sgMessage.AddBcc(new EmailAddress(addressBcc.Address));
            }

            sgMessage.Subject = message.Subject;

            if (message.AlternateViews.Count > 0)
            {
                foreach (var view in message.AlternateViews)
                {
                    if (view.ContentStream.CanSeek)
                    {
                        view.ContentStream.Position = 0;
                    }

                    var reader = new StreamReader(view.ContentStream);

                    switch (view.ContentType.MediaType)
                    {
                        case MediaTypeNames.Text.Html:
                            sgMessage.HtmlContent = reader.ReadToEnd();
                            break;
                        case MediaTypeNames.Text.Plain:
                            sgMessage.PlainTextContent = reader.ReadToEnd();
                            break;
                    }
                }
            }

            foreach (var attachment in message.Attachments)
            {
                sgMessage.AddAttachment(attachment.Name, ConvertToBase64(attachment.ContentStream),
                    attachment.ContentType.MediaType);
            }

            return sgMessage;
        }

        private static string ConvertToBase64(System.IO.Stream sourceStream)
        {
            string result = null;

            if (sourceStream != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    sourceStream.CopyTo(memoryStream);
                    result = Convert.ToBase64String(memoryStream.ToArray());
                }
            }

            return result;
        }
    }
}