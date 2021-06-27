using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarSense_Welcome.Interfaces;
using EarSense_Welcome.Services;
using Microsoft.Extensions.Configuration;
using EarSense_Welcome.Data;
using System.IO;

namespace EarSense_Welcome.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _config;
        public IMessageService _messenger;

        [BindProperty]
        public ContactForm Form { get; set; }

        public IndexModel(ILogger<IndexModel> logger,
            IEmailService emailService,
            IConfiguration config,
            IMessageService messenger)
        {
            _logger = logger;
            _emailService = emailService;
            _config = config;
            _messenger = messenger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostContact()
        {
            if (ModelState.IsValid)
            {
                //Build message body
                string body = System.IO.File.ReadAllText(@".\wwwroot\htmlTemplates\emailTemplate.html");
                body = string.Format(body, Form.Name, Form.Message, Form.Address, Form.Phone, Form.Email);
                await _emailService.sendMessageGmail(_config.GetValue<string>("EmailService:BusinessAddress"), Form.Subject, body);
                _messenger.Modal = true;
                _messenger.Read = true;
                _messenger.Message = "Your feedback has been submitted. Thank you!";
                return RedirectToPage("/Index");
            }
            return Page();

        }
    }
}
