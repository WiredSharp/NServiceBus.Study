using Messages;
using NServiceBus;
using NServiceBus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientUI.Handlers
{
    public class DoSomethingHandler : IHandleMessages<DoSomething>
    {
        private static ILog Logger = LogManager.GetLogger<DoSomethingHandler>(); 

        public Task Handle(DoSomething message, IMessageHandlerContext context)
        {
            Logger.Info($"Receiving {message}");
            return Task.CompletedTask;
        }
    }
}
