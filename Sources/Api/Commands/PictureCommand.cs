using System;
using System.Linq;
using Assistant.Application.Helpers;
using Assistant.Commands.Models;
using Assistant.Facade.Commands;
using Assistant.Facade.Messages;
using Assistant.Messages;
using Assistant.Messages.Enums;
using Bing = Assistant.Messages.Builders.Bing;

namespace Api.Commands
{

    public class PictureCommand : ICommand
    {
        public ICommandInfo Info => new CommandInfo
        {
            Priority = 1,
            Keys = new[]
            {
                new [] { "покажи" },
            }
        };

        public IAssistantMessage Execute(IAssistantContext context)
        {
            var key = context.Message.CommandKey.ToList();
            key.Remove("покажи");

            var attachment = new Bing.SearchImagesAttachmentBuilder(context)
                .SetSearchKey(key)
                .SetSafeSearch(SafeSearch.Off)
                .SetImageType(ImageType.Photo)
                .SetOffset(new Random().Next(0, 100))
                .SetCount(3)
                .GetResult();

            var text = attachment.Images.Count() > 0
                ? "Я нашел такие следующие фотографии..."
                : $"Я не смог найти {string.Join(" ", key)}";

            return new AssistantMessage
            {
                Text = text,
                Attachment = attachment,
            };
        }
    }
}
