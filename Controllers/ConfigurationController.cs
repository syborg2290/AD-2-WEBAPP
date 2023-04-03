namespace AD2_WEB_APP.Controllers;

using Microsoft.AspNetCore.Mvc;
using AD2_WEB_APP.Models.Configuration;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authorization;


public class ConfigurationController : Controller
{
    private readonly IConfigurationService _configurationService;

    public ConfigurationController(IConfigurationService configurationService)
    {
        _configurationService = configurationService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var configurations = _configurationService.GetAll();
        return Ok(configurations);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var configuration = _configurationService.GetById(id);
        return Ok(configuration);
    }

    [HttpPost]
    public IActionResult Create(CreateRequestConfiguration model)
    {
        var configuration = _configurationService.Create(model);
        return Ok(configuration);
    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _configurationService.Delete(id);
        return Ok(new { message = "Configuration deleted" });
    }
}
