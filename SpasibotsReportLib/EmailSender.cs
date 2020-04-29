using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SpasibotsReportLib
{
    public class EmailSender
    {
        public static async Task SendGmailAsync(string fromGmailAddress, string fromGmailPassword, string fromBotName, string toAddress, string subj, string toName, string body)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(fromGmailAddress);
                mail.To.Add(toAddress);
                mail.Subject = subj;
                mail.Body = $"Уважаемый {toName}," +
                $"\r\n\r\n{body}\r\n\r\n" +
                $"\r\nЭто письмо сформировано автоматически. Пожалуйста, не отвечайте на него." +
                $"\r\nЕсли у Вас есть вопросы, Вы можете обратиться по электронной почте spasibots@yandex.ru." +
                $"\r\nС надеждой на долговременное и взаимовыгодное партнерство" +
                $"\r\n{fromBotName}, команда Spasibots";
                //mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential(fromGmailAddress, fromGmailPassword);
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(mail);
                }
            }
            Console.WriteLine("Письмо отправлено");
        }
    }
}
