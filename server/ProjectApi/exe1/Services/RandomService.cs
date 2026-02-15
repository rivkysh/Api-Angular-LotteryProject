using exe1.Interfaces;
using exe1.Models;
using System;
using System.Net;
using System.Net.Mail;
using static exe1.Dto.DtoRandom;
using System.Net;
using System.Net.Mail;

namespace exe1.Services
{
    public class RandomService : IRandomService
    {
        private readonly IRandomRepository repository;
        public RandomService(IRandomRepository repository)
        {
            this.repository = repository;
        }

       

        //TheRandom
        public async Task<User?> TheRandom(int prizeId)
        {
            var purchases = await repository.TheRandom(prizeId);
            if (purchases.Count == 0)
            {
                return null;
            }
            Random random = new Random();
            var theBasket = purchases[random.Next(purchases.Count)];
            var theUserId = theBasket.UserId;
            var theUser = await repository.FindUserById(theUserId);
            var prize =await repository.FindPrizeById(prizeId);
            prize.Thewinner = theUser;
            prize.Islottered= true;
            await repository.SavetheChanges();
            //SendWinnerEmail(theUser.Email, prize.Name);
            return theUser;
        }
        public async Task<IEnumerable<DtoWinnersReport>> GetWinnerReport()
        {
          var prizes= await repository.GetWinnerReport();
            List<DtoWinnersReport> winnersReports = new List<DtoWinnersReport>();
            foreach (var p in prizes)
            {        

                if (p.Thewinner != null)
                {
                    DtoWinnersReport dto = new DtoWinnersReport();
                    dto.prize = p;
                    dto.user = p.Thewinner;
                    winnersReports.Add(dto);
                }
            }
            return winnersReports;
        }
       

public void SendWinnerEmail(string toEmail, string prizeName)
    {
            //    using (var client = new SmtpClient("localhost", 25)) // שרת מקומי
            //    {
            //        client.EnableSsl = false; // בשרת מקומי אין צורך ב-SSL
            //        client.UseDefaultCredentials = false;

            //        var mailMessage = new MailMessage
            //        {
            //            From = new MailAddress("test@test.com"),
            //            Subject = "בדיקת זכייה",
            //            Body = $"ברכות! זכית בפרס.",
            //            IsBodyHtml = true,
            //        };
            //        mailMessage.To.Add(toEmail);

            //        client.Send(mailMessage);
            //    }
            using (var client = new SmtpClient("localhost", 25))
            {
                client.EnableSsl = false;
                client.UseDefaultCredentials = false;

                // בניית גוף המייל ב-HTML מעוצב
                string htmlBody = $@"
        <div dir='rtl' style='font-family: Arial, sans-serif; border: 2px solid #4CAF50; padding: 20px; border-radius: 10px; max-width: 500px; margin: auto; background-color: #f9f9f9;'>
            <h1 style='color: #4CAF50; text-align: center;'>מזל טוב, זכית! 🎉</h1>
            <hr style='border: 0; border-top: 1px solid #ddd;'>
            <p style='font-size: 18px; color: #333; text-align: center;'>
                שמחים לבשר לך שבתהליך ההגרלה זכית בפרס השווה:
            </p>
            <div style='background-color: #ffffff; border: 1px dashed #4CAF50; padding: 15px; text-align: center; font-size: 24px; font-weight: bold; color: #e91e63; margin: 20px 0;'>
                {prizeName}
            </div>
            <p style='font-size: 14px; color: #777; text-align: center;'>
                נציג מטעמנו יצור איתך קשר בקרוב למימוש הזכייה.
            </p>
            <div style='text-align: center; margin-top: 30px;'>
                <small style='color: #aaa;'>נשלח אוטומטית על ידי מערכת ההגרלות שלנו</small>
            </div>
        </div>";

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("no-reply@lottery-system.com", "מערכת הגרלות"),
                    Subject = "בשורה משמחת! זכית בפרס",
                    Body = htmlBody,
                    IsBodyHtml = true,
                };
                mailMessage.To.Add(toEmail);

                client.Send(mailMessage);
            }
        }
}
}