using System;
using System.Linq;
using Assistant.Application.Helpers;
using Assistant.Commands.Models;
using Assistant.Facade.Commands;
using Assistant.Facade.Messages;
using Assistant.Messages;
using Assistant.Messages.Builders.Bing;
using Assistant.Messages.Builders.Google;

namespace Api.Commands
{
    public class SearchCommand : ICommand
    {
        public ICommandInfo Info => new CommandInfo
        {
            Priority = 10,
            Keys = new[]
            {
                new [] { "search" },
                new [] { "bing" },
                new [] { "google" },
            }
        };

        public IAssistantMessage Execute(IAssistantContext context)
        {
            var key = context.Message.CommandKey.ToList();
            key.Remove("search");
            key.Remove("bing");
            key.Remove("google");

            return new AssistantMessage
            {
                Text = "I find this...",
                Attachment = context.Message.CommandKey.Contains("bing")
                    ? new BingLinkAttachmentBuilder(context)
                        .SetText("Find result in bing")
                        .SetSearchKey(key)
                        .GetResult()
                    : new GoogleLinkAttachmentBuilder(context)
                        .SetText("Find result in google")
                        .SetSearchKey(key)
                        .GetResult()
            };
        }
    }
}
