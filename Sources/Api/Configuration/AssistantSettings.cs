using System;
using Api.Commands;
using Assistant.Commands.Managers;
using Assistant.Configuration.Options;
using Assistant.Facade.Commands;
using Assistant.Facade.Configuration;

namespace Api.Configuration
{
    public class AssistantSettings : ISettings
    {
        public ICommandsManager Manager { get; set; } = new CommandsManager();
        public IOptions Options { get; set; } = new BaseOptions();

        public AssistantSettings()
        {
            InitOptions();
            InitCommands();
        }

        private void InitOptions()
        {
            Options.Language = "ru";

            Options.BingLink = new Uri("<null>");
            Options.BingToken = "<null>";

            Options.ExecuteAssistantKeys = new []
            {
                new [] { "хватов", },
                new [] { "khvatov", },
                new [] { "khvatov", },
                new [] { "феликс", },
            };
        }

        private void InitCommands()
        {
            Manager.DefaultCommand = new DefaultCommand();

            Manager.Commands.Add(new HelloCommand());
            Manager.Commands.Add(new SearchCommand());
            Manager.Commands.Add(new PictureCommand());
            Manager.Commands.Add(new LabCommand());
        }
    }
}
