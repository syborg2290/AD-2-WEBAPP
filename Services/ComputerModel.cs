namespace AD2_WEB_APP.Services;

using AutoMapper;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Helpers;
using AD2_WEB_APP.Models.ComputerModel;
using AD2_WEB_APP.Services;


public interface IComputerModelService
{

    List<GetRequestComputerModel> GetAll();
    ComputerModel GetById(int id);
    GetRequestComputerModel GetComputerById(int id);
    ComputerModel Create(CreateRequestComputerModel model);
    void Delete(int id);
}

public class ComputerModelService : IComputerModelService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;
    public Series series { get; set; }
    public ComputerModelService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }


    public List<GetRequestComputerModel> GetAll()
    {
        try
        {
            List<GetRequestComputerModel> computers = new List<GetRequestComputerModel>();

            List<GetRequestWithoutCategoryComputerModel> computersListWi = _context.ComputerModel
                .Select(p => new GetRequestWithoutCategoryComputerModel
                {
                    Id = p.Id,
                    Model_Name = p.Model_Name,
                    Configuration = _context.ItemConfiguration.Where(t => t.Id == p.Default_Configuration_ID).ToList(),
                    Series = _context.Series.Where(t => t.Id == p.SeriesId).ToList(),
                }).ToList();

            computersListWi.ForEach((each) =>
       {
           computers.Add(new GetRequestComputerModel
           {
               Id = each.Id,
               Model_Name = each.Model_Name,
               Configuration = each.Configuration,
               Series = each.Series,
               Category = _context.Category.Where(t => t.Id == each.Configuration[0].CategoryId).ToList()
           });
       });
            return computers;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public ComputerModel GetById(int id)
    {
        try
        {
            return GetComputerModel(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public GetRequestComputerModel GetComputerById(int id)
    {
        try
        {
            GetRequestComputerModel computer = new GetRequestComputerModel();
            var com = GetComputerModel(id);

            if (com == null)
            {
                throw new KeyNotFoundException("Model not found");

            }

            computer.Id = com.Id;
            computer.Model_Name = com.Model_Name;
            return computer;

        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public ComputerModel Create(CreateRequestComputerModel model)
    {
        try
        {

            // map model to new category object
            var computermodel = _mapper.Map<ComputerModel>(model);


            // save category
            _context.ComputerModel.Add(computermodel);
            _context.SaveChanges();
            return computermodel;
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
            var model = GetComputerModel(id);
            _context.ComputerModel.Remove(model);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private ComputerModel GetComputerModel(int id)
    {
        try
        {
            var model = _context.ComputerModel.Find(id);
            if (model == null) throw new KeyNotFoundException("Model not found");
            return model;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}