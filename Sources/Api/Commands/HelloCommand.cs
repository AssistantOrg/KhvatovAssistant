using System;
using System.Linq;
using Assistant.Application.Helpers;
using Assistant.Commands.Models;
using Assistant.Facade.Commands;
using Assistant.Facade.Messages;
using Assistant.Messages;
using Assistant.Messages.Builders.Google;

namespace Api.Commands
{
    public class HelloCommand : ICommand
    {
        public ICommandInfo Info => new CommandInfo {
            Priority = -1,
            Keys = new []
            {
                new [] { "hi" },
                new [] { "hello" },
                new [] { "good", "morning" },
            }
        };

        public IAssistantMessage Execute(IAssistantContext context)
        {
            if (Enumerable.SequenceEqual(context.Message.ExcuteCommandKey, new[] { "good", "morning" }))
            {
                return new AssistantMessage
                {
                    Text = "Toooooooooooo nooob"
                };
            }

            return new AssistantMessage
            {
                Text = RandomizerHelper
                    .ChooseRandomFromArray(new [] {
                        "Hi",
                        "Hi too",
                        "Hello",
                    })
            };
        }
    }
}
