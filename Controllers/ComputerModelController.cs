using AutoMapper;
using AD2_WEB_APP.Models.ComputerModel;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AD2_WEB_APP.Controllers
{
    public class ComputerModelsController : Controller
    {
        private readonly IComputerModelService _computerModelService;
        private readonly IMapper _mapper;

        public ComputerModelsController(IComputerModelService computerModelService, IMapper mapper)
        {
            _computerModelService = computerModelService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _computerModelService.GetAll();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _computerModelService.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] CreateRequestComputerModel modelDto)
        {
            try
            {
                _computerModelService.Create(modelDto);
                return Ok(new { message = "Computer model created" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while creating the computer model" });
            }
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _computerModelService.Delete(id);
                return Ok(new { message = "Computer model deleted" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the computer model" });
            }
        }
    }
}
