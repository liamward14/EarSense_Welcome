using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EarSense_Welcome.Data
{
    public class ContactForm
    {
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
