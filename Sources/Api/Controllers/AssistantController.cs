using System;
using System.Threading.Tasks;
using Assistant.Facade.Configuration;
using Assistant.Facade.Messages;
using Assistant.Messages.Builders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api.Controllers
{
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

        [HttpGet]
        public async Task<string> Get([FromQuery] string text)
        {
            IAssistantContext context = new AssistantContextBuilder(text)
                .GetResult();

            IAssistantMessage result = await _settings.Manager
                .TryExcuteCommandsAsync(
                    await _settings.Manager.FindCommandsAsync(context));

            return result == null
                ? JsonConvert.SerializeObject("null")
                : JsonConvert.SerializeObject(result);
        }
    }
}
