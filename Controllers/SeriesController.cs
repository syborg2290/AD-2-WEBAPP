using AutoMapper;
using AD2_WEB_APP.Models.Series;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AD2_WEB_APP.Controllers
{
  
    public class SeriesController : Controller
    {
        private readonly ISeriesService _seriesService;
        private readonly IMapper _mapper;

        public SeriesController(ISeriesService seriesService, IMapper mapper)
        {
            _seriesService = seriesService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var models = _seriesService.GetAll();
            return Ok(models);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _seriesService.GetById(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateRequestSeries modelDto)
        {
            try
            {
                _seriesService.Create(modelDto);
                return Ok(new { message = "Series created" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while creating the series" });
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _seriesService.Delete(id);
                return Ok(new { message = "Series deleted" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the series" });
            }
        }
    }
}
