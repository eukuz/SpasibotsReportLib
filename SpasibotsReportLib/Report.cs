using System;
using System.Collections.Generic;
using System.Text;

namespace SpasibotsReportLib
{
    public class Report
    {
        //public Report(string )
        public static string GetQuizReport(string fio, string socialNetworkLink, string socialNetwork, (string, string)[] questionsAnswers)
        {
            string report = $"Вам пришла новая анкета от {fio}, в социальной сети {socialNetwork} : {socialNetworkLink}";

            string quizRep = "\r\n\r\nAнкета:";
            foreach ((string,string) qa in questionsAnswers)
            {
                quizRep += $"\r\n\tВопрос: \"{qa.Item1}\"\tОтвет:\"{qa.Item2}\"";
            }
            return report + quizRep;
        }
    }
}
