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
    public class LabCommand : ICommand
    {
        public ICommandInfo Info => new CommandInfo
        {
            Priority = -1,
            Keys = new[]
            {
                new [] { "лаб" },
                new [] { "лабы" },
                new [] { "лабов" },
                new [] { "лабу" },
            },
        };

        private int _count = -1;

        private string[] _values = new [] {
            "лаба",
            "Добллаба",
            "Трипллаба",
            "Vyjuj kf,f",
            "МУлтишлаб",
            "БОЖЖЕСТВНЕНО",
            "СУПАР БОЖЖЕСТВНЕНО",
        };

        public IAssistantMessage Execute(IAssistantContext context)
        {
            ++_count;
            if (_count > _values.Length - 1)
                _count = 0;

            return new AssistantMessage
            {
                Text = _values[_count]
            };
        }
    }
}
