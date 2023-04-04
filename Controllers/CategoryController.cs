namespace AD2_WEB_APP.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AD2_WEB_APP.Models.Category;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;


public class CategoriesController : Controller
{
    private ICategoryService _categoryService;

    private ICommonService _commonService;
    private IMapper _mapper;

    public CategoriesController(
        ICategoryService categoryService,
        ICommonService commonService,
        IMapper mapper)
    {
        _categoryService = categoryService;
        _commonService = commonService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var categories = _categoryService.GetAll();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var category = _categoryService.GetById(id);
        return Ok(category);
    }


    [HttpPost]
    public IActionResult Create(CreateRequestCategory model)
    {

        if (!HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            // Authorization header is not present
            TempData["msg"] = "Unauthorized!";
            return View(model);
        }
        else
        {
            // Authorization header is present, split the value to remove the "Bearer " prefix
            // e.g. "Bearer token-value" -> "token-value"
            var tokenValue = authHeader.ToString().Split(" ")[1];

            if (_commonService.IsValid(tokenValue))
            {
                _categoryService.Create(model);
                TempData["msg"] = "Category created!";
                return View(model);
            }
            else
            {
                TempData["msg"] = "Session expired!";
                return View(model);
            }

        }
        //  Console.WriteLine(model);

    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _categoryService.Delete(id);
        return Ok(new { message = "Category deleted" });
    }
}
