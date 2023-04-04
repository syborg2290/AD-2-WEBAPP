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

namespace AD2_WEB_APP.Pages.Admin;

public class NewItemsModel : PageModel
{
    private readonly ILogger<NewItemsModel> _logger;

    private readonly IHostEnvironment _environment;

    private IConfigurationService _configurationService;

    private IItemService _itemService;

    public NewItemsModel(ILogger<NewItemsModel> logger, IConfigurationService configurationService, IItemService itemService, IHostEnvironment environment)
    {
        _logger = logger;
        _configurationService = configurationService;
        _itemService = itemService;
        _environment = environment;
    }

    [BindProperty]
    public IFormFile UploadedFile { get; set; }

    [BindProperty]
    public Models.Item.CreateRequestItem item { get; set; }

    public SelectList configurations { get; set; }

    [TempData]
    public string Message { get; set; }

    [TempData]
    public string Type { get; set; }

    [TempData]
    public string FilePath { get; set; }



    public void OnGet()
    {
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

            var data = item;
            FilePath = targetFileName;
            data.ImagePath = targetFileName;

            _itemService.Create(data);
            
            Type = "success";
            Message = "Item created !";
            
        }
        catch (System.Exception)
        {

            Type = "error";
            Message = "Operation failed !";
        }


    }


}
