using System;
using Assistant.Commands.Models;
using Assistant.Facade.Commands;
using Assistant.Facade.Messages;
using Assistant.Messages;

namespace Api.Commands
{
    public class DefaultCommand : ICommand
    {
        public ICommandInfo Info => new CommandInfo { };

        public IAssistantMessage Excute(IAssistantContext context)
        {
            return new AssistantMessage
            {
                Text = "Я не понимаю"
            };
        }
    }
}
