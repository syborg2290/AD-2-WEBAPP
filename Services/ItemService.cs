namespace AD2_WEB_APP.Services;

using AutoMapper;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Helpers;
using AD2_WEB_APP.Models.Item;
using Microsoft.AspNetCore.Mvc.Rendering;


public interface IItemService
{

    List<GetRequestItem> GetAll();
    Item GetById(int id);
    Item Create(CreateRequestItem model);
    void Delete(int id);
}

public class ItemService : IItemService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public ItemService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public List<GetRequestItem> GetAll()
    {
        try
        {
            List<GetRequestItem> itemsAll = new List<GetRequestItem>();

            List<GetWithoutCatRequestItem> items = _context.Item
                .Select(p => new GetWithoutCatRequestItem
                {
                    Id = p.Id,
                    Name = p.Name,
                    Configuration = _context.ItemConfiguration.Where(t => t.Id == p.ConfigurationID).ToList(),
                }).ToList();

            items.ForEach((each) =>
            {
                itemsAll.Add(new GetRequestItem
                {
                    Id = each.Id,
                    Name = each.Name,
                    Configuration = each.Configuration,
                    Category = _context.Category.Where(t => t.Id == each.Configuration[0].CategoryId).ToList()
                });
            });

            // Console.WriteLine(items[0].Configuration[0].CategoryId);

            return itemsAll;

        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Item GetById(int id)
    {
        try
        {
            return GetItem(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Item Create(CreateRequestItem model)
    {
        try
        {
            // map model to new item object
            var item = _mapper.Map<Item>(model);


            // save item
            _context.Item.Add(item);
            _context.SaveChanges();
            return item;
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
            var item = GetItem(id);
            _context.Item.Remove(item);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Item GetItem(int id)
    {
        try
        {
            var item = _context.Item.Find(id);
            if (item == null) throw new KeyNotFoundException("Item not found");
            return item;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}