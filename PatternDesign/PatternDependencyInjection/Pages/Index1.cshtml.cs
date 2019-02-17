using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatternDependencyInjection.Services;

namespace PatternDependencyInjection.Pages
{
    public class Index1Model : PageModel
    {
        public string Message { get; set; }

        public void OnGet([FromServices] IEmailService emailSercice)
        {
            Message = emailSercice.SendEmail();
        }
    }
}