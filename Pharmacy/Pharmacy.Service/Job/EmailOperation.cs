using AutoMapper;
using MailKit.Net.Smtp;
using MimeKit;
using Pharmacy.DB.Entities.DataContext;
using Pharmacy.Model;
using Pharmacy.Model.ModelUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Service.Job
{
    public class EmailOperation :IEmailOperation
    {
        private readonly IMapper mapper; //Mapper çagrildi

        public EmailOperation(IMapper _mapper)
        {
            mapper = _mapper;
        }

        public General<UserViewModel> sendEmail(int id)
        {
            var result = new General<UserViewModel>();
            using (var context = new PharmacyContext())
            {
                var user = context.User.SingleOrDefault(i => i.Id == id);

                if (!user.IsSendEmail)
                {

                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("Pharmacy", "info@pharmacy.com"));
                    message.To.Add(new MailboxAddress("User", user.Email));
                    message.Subject = "Welcome to the pharmacy";
                    message.Body = new TextPart("plain")
                    {
                        Text = "Dear"+user.Name+ ", Welcome To the Pharmacy!"
                    };

                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp@gmail.com", 587, false);
                        client.Authenticate("info@pharmacy.com", "visualstudio");
                        client.Send(message);
                        client.Disconnect(true);
                    }

                    user.IsSendEmail = true;
                    context.SaveChanges();
                    result.Entity = mapper.Map<UserViewModel>(user);

                    result.IsSuccess = true;
                }
            }

            return result;

        }
    }
}
