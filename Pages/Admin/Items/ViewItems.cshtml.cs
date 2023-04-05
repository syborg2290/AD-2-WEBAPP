using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AD2_WEB_APP.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using AD2_WEB_APP.Services;
using AD2_WEB_APP.Models.Item;
using Microsoft.AspNetCore.Authorization;

namespace AD2_WEB_APP.Pages.Admin;

[Authorize]
public class ViewItemsModel : PageModel
{
    private readonly ILogger<ViewItemsModel> _logger;

    private IItemService _itemService;

    public ViewItemsModel(ILogger<ViewItemsModel> logger, IItemService itemService)
    {
        _logger = logger;
        _itemService = itemService;
    }

    public List<GetRequestItem> itemList { get; set; }

    public void OnGet()
    {
        itemList = _itemService.GetAll();
    }
}
