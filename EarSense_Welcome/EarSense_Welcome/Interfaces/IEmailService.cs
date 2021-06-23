using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarSense_Welcome.Interfaces
{
    public interface IEmailService
    {
        Task sendMessageGmail(string toAddress, string subject, string body);
    }
}
