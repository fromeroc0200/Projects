﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PatternDependencyInjection.Services;

namespace PatternDependencyInjection.Pages
{
    public class IndexModel : PageModel
    {
        public IEmailService EmailService { get; }
        public IndexModel(IEmailService emailService)
        {
            EmailService = emailService;
        }

        public string Message { get; set; }

        public void OnGet()
        {
            Message = EmailService.SendEmail();
        }
    }
}
