using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Pharmacy.Service.Job;
using System.Globalization;
using System.Threading.Tasks;

namespace Pharmacy.API.Controllers
{
    public class EmailController : Controller   
    {
        private readonly IEmailOperation emailOperation; //Email service i çağırıyoruz.
        private readonly IMapper mapper;

        public EmailController(IEmailOperation _emailOperation, IMapper _mapper)
        {
            emailOperation = _emailOperation;
            mapper = _mapper;
        }

        public IActionResult sendEmail()
        {
            
                return View();
        }


    }
}
