using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Trabalho_Laboratorio.Services
{
	public class EmailSender : IEmailSender
	{
		public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
		{
			Options = optionsAccessor.Value;
		}

		public AuthMessageSenderOptions Options { get; } //set only via Secret Manager

		public Task SendEmailAsync(string email, string subject, string message)
		{
			return Execute(Options.User, Options.Key, subject, message, email);
		}

		public async Task Execute(string emailFrom, string password, string subject, string message, string email)
		{
			var body = "<p>Olá, procedo à confirmação do registo para que a sua conta possa ser ativada ({0})</p><p>Carregue no link:</p><p>{1}</p>";
			var message2 = new MailMessage();
			message2.To.Add(new MailAddress(email));  // replace with valid value
			message2.From = new MailAddress(emailFrom);  // replace with valid value
			message2.Subject = subject;
			message2.Body = string.Format(body, subject, message);
			message2.IsBodyHtml = true;
			using (var smtp = new SmtpClient())
			{
				var credential = new NetworkCredential
				{
					UserName = emailFrom,  // replace with valid value
					Password = password  // replace with valid value
				};
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = credential;
				smtp.Host = "smtp.office365.com";//address webmail
				smtp.Port = 587;
				smtp.EnableSsl = true;

				await smtp.SendMailAsync(message2);

				//var client = new SendGridClient(apiKey);
				//var msg = new SendGridMessage()
				//{
				//	From = new EmailAddress("Joe@contoso.com", Options.SendGridUser),
				//	Subject = subject,
				//	PlainTextContent = message2,
				//	HtmlContent = message2
				//};
				//msg.AddTo(new EmailAddress(email));

				//// Disable click tracking.
				//// See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
				//msg.SetClickTracking(false, false);

				return;
			}
		}
	}
}