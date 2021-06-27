using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EarSense_Welcome.Interfaces;

namespace EarSense_Welcome.Services
{
    public class MessageService : IMessageService
    {
        public MessageService() { }

        public string Message { get; set; }
        public bool Read { get; set; }
        public bool Modal { get; set; }

        public object Reset()
        {
            Read = false;
            Modal = false;
            Message = "";
            // Console.WriteLine("RESET");
            return new object();
        }
    }
}
