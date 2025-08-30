using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionApp1;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("Hello")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req,
        string name)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var message = string.IsNullOrEmpty(name)
            ? "Welcome to Azure Functions!"
            : $"Hello, {name}! Welcome to Azure Functions!";
        return new OkObjectResult(message);
    }
}