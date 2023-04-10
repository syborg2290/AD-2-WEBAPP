using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AD2_WEB_APP.Services;
using AD2_WEB_APP.Models;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authorization;


namespace AD2_WEB_APP.Pages.Admin;

[Authorize]
public class NewComputersModel : PageModel
{
    private readonly ILogger<NewComputersModel> _logger;

    private ISeriesService _seriesService;

    private IComputerModelService _computerService;

    private IConfigurationService _configurationService;

     private readonly IHostEnvironment _environment;

    public NewComputersModel(ILogger<NewComputersModel> logger, ISeriesService seriesService, IConfigurationService configurationService, IComputerModelService computerService,IHostEnvironment environment)
    {
        _logger = logger;
        _seriesService = seriesService;
        _computerService = computerService;
        _configurationService = configurationService;
        _environment = environment;
    }

    [BindProperty]
    public IFormFile UploadedFile { get; set; }

    [BindProperty]
    public Models.ComputerModel.CreateRequestComputerModel computer { get; set; }

    public SelectList configurations { get; set; }

    public SelectList series { get; set; }

    [TempData]
    public string Message { get; set; }

    [TempData]
    public string Type { get; set; }

    [TempData]
    public string FilePath { get; set; }


    public void OnGet()
    {
        series = _seriesService.GetAll();
        configurations = _configurationService.GetAll();

    }

    public async Task OnPostAsync()
    {
        try
        {
            
            if (UploadedFile == null || UploadedFile.Length == 0)
            {
                return;
            }
            string targetFileName = $"{_environment.ContentRootPath}/wwwroot/images/{UploadedFile.FileName}";

            using (var stream = new FileStream(targetFileName, FileMode.Create))
            {
                await UploadedFile.CopyToAsync(stream);
            }


            var data = computer;

            FilePath = UploadedFile.FileName;
            data.ImagePath = UploadedFile.FileName;

            _computerService.Create(data);
            Type = "success";
            Message = "Computer created !";
            
        }
        catch (System.Exception)
        {

            Type = "error";
            Message = "Operation failed !";
            
        }

    }
}
