using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatternDependencyInjection.Services
{
    public class EmailServiceDummy : IEmailService
    {
        public string SendEmail()
        {
            return "Mensaje enviado";
        }
    }
}
