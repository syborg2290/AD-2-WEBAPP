namespace AD2_WEB_APP.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AD2_WEB_APP.Models.Customer;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;


public class CustomersController : Controller
{
    private ICustomerService _customerService;

    private ICommonService _commonService;
    private IMapper _mapper;

    public CustomersController(
        ICustomerService customerService,
        ICommonService commonService,
        IMapper mapper)
    {
        _customerService = customerService;
        _commonService = commonService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = _customerService.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _customerService.GetById(id);
        return Ok(customer);
    }


    [HttpPost]
    public IActionResult Create(CreateRequestCustomer model)
    {

        if (!HttpContext.Request.Headers.TryGetValue("Authorization", out var authHeader))
        {
            // Authorization header is not present
            return Unauthorized();
        }
        else
        {
            // Authorization header is present, split the value to remove the "Bearer " prefix
            // e.g. "Bearer token-value" -> "token-value"
            var tokenValue = authHeader.ToString().Split(" ")[1];

            if (_commonService.IsValid(tokenValue))
            {
                _customerService.Create(model);
                return Ok(new { message = "Customer created" });
            }
            else
            {
                return BadRequest(new { message = "Session expired!" });
            }

        }
        //  Console.WriteLine(model);

    }


    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _customerService.Delete(id);
        return Ok(new { message = "Customer deleted" });
    }
}