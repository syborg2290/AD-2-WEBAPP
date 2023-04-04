namespace AD2_WEB_APP.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Models.Item;
using AD2_WEB_APP.Services;
using System;
using System.Collections.Generic;


public class ItemController : Controller
{
    private readonly IItemService _itemService;
    private readonly IMapper _mapper;

    public ItemController(IItemService itemService, IMapper mapper)
    {
        _itemService = itemService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var items = _itemService.GetAll();
        return Ok(items);
    }


    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Item item = _itemService.GetById(id);
        return Ok(item);
    }


    [HttpPost]
    public IActionResult Create(CreateRequestItem model)
    {

        _itemService.Create(model);
        return Ok(new { message = "Item created" });
    }



    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Item item = _itemService.GetById(id);
        if (item == null)
        {
            return NotFound();
        }

        _itemService.Delete(id);
        return Ok(new { message = "Item deleted" });
    }



}