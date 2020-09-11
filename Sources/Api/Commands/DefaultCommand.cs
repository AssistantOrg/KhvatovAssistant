using System;
using Assistant.Application.Helpers;
using Assistant.Commands.Models;
using Assistant.Facade.Commands;
using Assistant.Facade.Messages;
using Assistant.Messages;
using Assistant.Messages.Attachments;
using Assistant.Messages.Builders.Google;

namespace Api.Commands
{
    public class DefaultCommand : ICommand
    {
        public ICommandInfo Info => new CommandInfo { };

        public IAssistantMessage Execute(IAssistantContext context)
        {
            return new AssistantMessage
            {
                Text = RandomizerHelper
                    .ChooseRandomFromArray(new[] {
                        "I do not understand",
                        "Can you repeat",
                        "Can you repeat, please",
                        "Please, can you repeat",
                        "I did not hear"
                    }),
            };
        }
    }
}
