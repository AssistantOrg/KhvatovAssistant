using System;
using System.Linq;
using Assistant.Application.Helpers;
using Assistant.Commands.Models;
using Assistant.Facade.Commands;
using Assistant.Facade.Messages;
using Assistant.Messages;
using Assistant.Messages.Attachments;
using Assistant.Messages.Builders.Bing;
using Assistant.Messages.Builders.Google;
using Assistant.Messages.Models;

namespace Api.Commands
{
    public class CatsCommand : ICommand
    {
        public ICommandInfo Info => new CommandInfo
        {
            Keys = new[]
            {
                new [] { "cat" },
                new [] { "cats" },
            }
        };

        public IAssistantMessage Execute(IAssistantContext context)
        {
            return new AssistantMessage
            {
                Text = "Meow..",
                Attachment = new ImagesAttachment()
                {
                   Source = Assistant.Messages.Enums.WebSource.Bing,
                   Images = new []
                   {
                       new ImageModel { ImageLink = new Uri("http://i0.kym-cdn.com/photos/images/facebook/001/139/108/92f.png") },
                       new ImageModel { ImageLink = new Uri("http://2.bp.blogspot.com/-WtdFq_e6eKo/TV5W5s-hS-I/AAAAAAAAAvM/gmCUYOx3bX8/s1600/Animals_Cats_Small_cat_005241_.jpg") },
                       new ImageModel { ImageLink = new Uri("https://i.ytimg.com/vi/ltYxFlMlYqI/maxresdefault.jpg") },
                       new ImageModel { ImageLink = new Uri("https://i.ytimg.com/vi/et4xUWhz0X0/maxresdefault.jpg") },
                       new ImageModel { ImageLink = new Uri("https://i.ytimg.com/vi/Nrxb23VN_pM/maxresdefault.jpg") },
                       new ImageModel { ImageLink = new Uri("http://i.ytimg.com/vi/5VBriRtl_aM/maxresdefault.jpg") },
                   },
                },
            };
        }
    }
}