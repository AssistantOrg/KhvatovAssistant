using System;
using System.Linq;
using Assistant.Application.Helpers;
using Assistant.Commands.Models;
using Assistant.Facade.Commands;
using Assistant.Facade.Messages;
using Assistant.Messages;
using Bing = Assistant.Messages.Builders.Bing;
using DuckDuckGo = Assistant.Messages.Builders.DuckDuckGo;

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
                new [] { "найди" },
                new [] { "загугли" },
                new [] { "гугл" },
                new [] { "бинг" },
            }
        };

        public IAssistantMessage Execute(IAssistantContext context)
        {
            var key = context.Message.CommandKey.ToList();
            key.Remove("search");
            key.Remove("bing");
            key.Remove("google");
            key.Remove("найди");
            key.Remove("загугли");
            key.Remove("гугл");
            key.Remove("бинг");

            return new AssistantMessage
            {
                Text = "I find this...",
                Attachment = context.Message.CommandKey.Contains("bing")
                    ? new Bing.SearchLinkAttachmentBuilder(context)
                        .SetText("Find result in bing")
                        .SetSearchKey(key)
                        .GetResult()
                    : new DuckDuckGo.SearchLinkAttachmentBuilder(context)
                        .SetText("Найденные результаты на DuckDuckGo")
                        .SetSearchKey(key)
                        .GetResult()
            };
        }
    }
}
