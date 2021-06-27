using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EarSense_Welcome.Interfaces
{
    public interface IMessageService
    {
        object Reset();
        string Message { get; set; }
        bool Read { get; set; }
        bool Modal { get; set; }
    }
}
