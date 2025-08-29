using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProviderServices
{
    public interface IMessageSender
    {
        Task<Response> SendAsync(Request request);
    }
}
