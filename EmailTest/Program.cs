using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var message = new MailMessage()
                {
                    Subject = ConfigurationManager.AppSettings["Subject"],
                    Body = ConfigurationManager.AppSettings["Body"]
                };
                message.To.Add(ConfigurationManager.AppSettings["ToAddress"]);

                var smtp = new SmtpClient();
                smtp.Send(message);

                Console.WriteLine("Email Sent.");
            }
            catch (Exception ex)
            {
                var outputException = ex;
                while (outputException != null)
                {
                    Console.WriteLine();
                    Console.WriteLine(outputException.Message);
                    Console.WriteLine(outputException.StackTrace);

                    outputException = outputException.InnerException;
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to close.");

            Console.ReadKey();
        }
    }
}
