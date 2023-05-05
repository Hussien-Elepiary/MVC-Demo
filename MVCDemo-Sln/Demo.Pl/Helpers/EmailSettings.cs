using Demo.DAL.Models;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;

namespace Demo.PL.Helpers
{
	public static class EmailSettings
	{
		/// <summary>
		/// this is an outdated way to send link throw email but this is how to use it better use (MailKit)
		/// </summary>
		/// <param name="email"></param>
		public static void SendEmail(Email email)
		{
			var client = new SmtpClient("smtp.gmail.com", 587);
			client.EnableSsl = true; // if the server have SSL this line mean the mail will use it to encrypt it 
			/// un comment the following commands to send an email
			//client.Credentials = new NetworkCredential("your email", "put the password provided by Google App Passwords in TwoFactor Auth settings");
			//client.Send("YourEmail", email.To, email.Subject, email.Body);

		}
	}
}
