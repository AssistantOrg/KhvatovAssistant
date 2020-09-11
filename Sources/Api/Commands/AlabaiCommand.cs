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
    public class AlabaiCommand : ICommand
    {
        public ICommandInfo Info => new CommandInfo
        {
            Priority = -1,
            Keys = new[]
            {
                new [] { "алабай" },
                new [] { "алабаев" },
                new [] { "алабаями" },
                new [] { "алабаи" },
                new [] { "алабая" },
                new [] { "собака" },
                new [] { "собаками" },
                new [] { "собаки" },
                new [] { "собак" },
                new [] { "собачий" },
            }
        };

        public IAssistantMessage Execute(IAssistantContext context)
        {
            return new AssistantMessage
            {
                Text = RandomizerHelper.ChooseRandomFromArray(new[] {
                     "Авбаи блять ну че там с алаВбаями!",
                     "ллабаи блядь  че тОм с алабаями!",
                     "Ctqчас будут вом алобои",
                     "Ага га",
                     "...",
                    }),
                Attachment = new ImagesAttachment()
                {
                    Source = Assistant.Messages.Enums.WebSource.Other,
                    Images = RandomizerHelper.ChooseRandomFromArray(new[] {
                            new []
                            {
                                new ImageModel { ImageLink = new Uri("https://s1.stc.all.kpcdn.net/putevoditel/projectid_103889/images/tild6439-6566-4530-b963-336663643766__en_90043325_0005.jpg") },
                                new ImageModel { ImageLink = new Uri("https://www.animalhouseshelter.com/wp-content/uploads/2018/04/apolloth.jpg") },
                                new ImageModel { ImageLink = new Uri("https://s-media-cache-ak0.pinimg.com/564x/a0/0b/d7/a00bd7e1701998c77770758d6ac90dac.jpg") },
                            },
                            new []
                            {
                                new ImageModel { ImageLink = new Uri("https://live.staticflickr.com/8081/8337759762_bda2d9ab97.jpg") },
                                new ImageModel { ImageLink = new Uri("https://i.pinimg.com/originals/f4/7d/a8/f47da8060092f737d82f4cc4cd1d175e.jpg") },
                                new ImageModel { ImageLink = new Uri("https://i.ytimg.com/vi/3kAaecescUg/maxresdefault.jpg") },
                            },
                            new []
                            {
                                new ImageModel { ImageLink = new Uri("https://s-media-cache-ak0.pinimg.com/736x/e7/7d/16/e77d1657fd558be55a242e765028b540.jpg") },
                                new ImageModel { ImageLink = new Uri("https://www.animalhouseshelter.com/wp-content/uploads/2018/04/apolloth.jpg") },
                                new ImageModel { ImageLink = new Uri("https://thumbs.dreamstime.com/b/alabai-dog-19930113.jpg") },
                            },
                        }),
                },
            };
        }
    }
}