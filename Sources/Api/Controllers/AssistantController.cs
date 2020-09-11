using System;
using System.Linq;
using System.Threading.Tasks;
using Assistant.Facade.Configuration;
using Assistant.Facade.Messages;
using Assistant.Messages.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Controllers
{
    public class Model
    {
        public string Text { get; set; }

        public bool IsNullWithoutAssistantKey { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class AssistantController : ControllerBase
    {

        private readonly ILogger<AssistantController> _logger;
        private readonly ISettings _settings;

        public AssistantController(ILogger<AssistantController> logger, ISettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        [HttpPost]
        public async Task<string> Post([FromBody] Model model)
        {
            IAssistantContext context = new AssistantContextBuilder(_settings.Options)
                .SetText(model.Text)
                .GetResult();

            _logger.LogInformation(JsonConvert.SerializeObject(context));

            if (model.IsNullWithoutAssistantKey && context.Message.ExcuteAssistantKey.Count() == 0) return null;

            IAssistantMessage result = await _settings.Manager
                .TryFindAndExecuteCommandsAsync(context);

            return JsonConvert.SerializeObject(result);
        }
    }
}
