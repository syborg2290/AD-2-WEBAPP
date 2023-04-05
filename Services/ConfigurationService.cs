namespace AD2_WEB_APP.Services;

using AutoMapper;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Helpers;
using AD2_WEB_APP.Models.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;


public interface IConfigurationService
{

    SelectList GetAll();
    Configuration GetById(int id);
    Configuration Create(CreateRequestConfiguration model);
    void Delete(int id);
}

public class ConfigurationService : IConfigurationService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public ConfigurationService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public SelectList GetAll()
    {
        try
        {
            return new SelectList(_context.ItemConfiguration.ToList(), "Id", "Name");
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Configuration GetById(int id)
    {
        try
        {
            return GetConfiguration(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Configuration Create(CreateRequestConfiguration model)
    {
        try
        {
            var configuration = _mapper.Map<Configuration>(model);


            _context.ItemConfiguration.Add(configuration);
            _context.SaveChanges();
            return configuration;
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
            var configuration = GetConfiguration(id);
            _context.ItemConfiguration.Remove(configuration);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Configuration GetConfiguration(int id)
    {
        try
        {
            var configuration = _context.ItemConfiguration.Find(id);
            if (configuration == null) throw new KeyNotFoundException("Config not found");
            return configuration;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}