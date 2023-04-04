namespace AD2_WEB_APP.Services;

using AutoMapper;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Helpers;
using AD2_WEB_APP.Models.Series;
using Microsoft.AspNetCore.Mvc.Rendering;


public interface ISeriesService
{

    SelectList GetAll();
    Series GetById(int id);
    Series Create(CreateRequestSeries model);
    void Delete(int id);
}

public class SeriesService : ISeriesService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public SeriesService(
        DataContext context,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
    }


    public SelectList GetAll()
    {
        try
        {
            return new SelectList(_context.Series.ToList(), "Id", "Name");
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Series GetById(int id)
    {
        try
        {
            return GetSeries(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Series Create(CreateRequestSeries model)
    {
        try
        {
            // map model to new series object
            var series = _mapper.Map<Series>(model);


            // save series
            _context.Series.Add(series);
            _context.SaveChanges();
            return series;
        }
        catch (System.Exception)
        {

            throw;
        }


    }


    public void Delete(int id)
    {
        try
        {
            var series = GetSeries(id);
            _context.Series.Remove(series);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Series GetSeries(int id)
    {
        try
        {
            var series = _context.Series.Find(id);
            if (series == null) throw new KeyNotFoundException("Series not found");
            return series;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}