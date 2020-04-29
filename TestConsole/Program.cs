using System;
using System.Net;
using System.Net.Mail;
using SpasibotsReportLib;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            string  fromMail = "spasibots.report@gmail.com", password = "5wTdmu8qL4NLUad",
                botName = "OprosnikBot", toMail = "eukuz.work@gmail.com", topic = "Новая анкета в "+botName, toName = "Евгений Аскарович";

            (string, string)[] QuA = new (string, string)[3];
            QuA[0] = ("Какая у Вас ниша?", "Мороженое");
            QuA[1] = ("Что бы Вы хотели реализовать с помощью бота?", "Интернет-магазин");
            QuA[2] = ("Какой бюджет вы готовы вложить на создание бота?", "15000 р.");

            EmailSender.SendGmailAsync(fromMail, password, botName, 
                toMail, topic, toName, Report.GetQuizReport("Иван Иванов","@ivanovivan","Телеграм",QuA)).GetAwaiter();
            //spasibots.report@gmail.com
            Console.WriteLine("!!!!");
            Console.ReadKey();
        }

    }
}
