namespace AD2_WEB_APP.Services;

using AutoMapper;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Helpers;
using AD2_WEB_APP.Models.Customer;
using AD2_WEB_APP.Models.Users;
using AD2_WEB_APP.Models.Address;
using BCrypt.Net;
using AD2_WEB_APP.Models.Common;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;


public interface ICustomerService
{
    public string Authenticate(CustomerLogin model);

    IEnumerable<Customer> GetAll();
    Customer GetById(int id);
    void Create(CreateRequestCustomer model);
    void Delete(int id);
}

public class CustomerService : ICustomerService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    private IAddressService _addressService;

    private ICommonService _commonService;

    public CustomerService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper,
        IAddressService addressService,
        ICommonService commonService
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
        _addressService = addressService;
        _commonService = commonService;
    }


    public IEnumerable<Customer> GetAll()
    {
        try
        {
            return _context.Customers;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public Customer GetById(int id)
    {
        try
        {
            return getCustomer(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }



    public string Authenticate(CustomerLogin model)
    {
        try
        {
            var user = _context.Customers.SingleOrDefault(x => x.Email == model.Email);

            // validate
            if (user == null || !BCrypt.Verify(model.Password, user.Password))
                throw new AppException("Email or password is incorrect !");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim("UserId", user.Id.ToString()),
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token.ToString();
        }
        catch (System.Exception e)
        {

             throw new AppException(e.Message);
        }
    }


    public void Create(CreateRequestCustomer model)
    {
        try
        {
            // validate
            if (_context.Customers.Any(x => x.Email == model.Email))
                throw new AppException("Customer with the email '" + model.Email + "' already exists");


            // create billing address record
            CreateRequestAddress billingModel = new CreateRequestAddress();
            billingModel.Street_Address = model.Street_Address_billing;
            billingModel.City = model.City_billing;
            billingModel.State = model.State_billing;
            billingModel.Zip_Code = model.Zip_Code_billing;
            billingModel.Country = model.Country_billing;

            Address _address_billing = _addressService.Create(billingModel);

            // create shipping address record
            CreateRequestAddress shippingModel = new CreateRequestAddress(); ;
            shippingModel.Street_Address = model.Street_Address_shipping;
            shippingModel.City = model.City_shipping;
            shippingModel.State = model.State_shipping;
            shippingModel.Zip_Code = model.Zip_Code_shipping;
            shippingModel.Country = model.Country_shipping;

            Address _address_shipping = _addressService.Create(shippingModel);

            // map model to new customer object
            CreateCustomer customerModel = new CreateCustomer();

            customerModel.FirstName = model.FirstName;
            customerModel.LastName = model.LastName; // Set LastName instead of FirstName
            customerModel.Email = model.Email;
            customerModel.Phone_Number = model.Phone_Number;
            customerModel.Billing_Address_ID = _address_billing.Id;
            customerModel.Shipping_Address_ID = _address_shipping.Id;

            // hash password
            customerModel.Password = BCrypt.HashPassword(model.Password);

            var customer = _mapper.Map<Customer>(customerModel);


            // save customer
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
        catch (System.Exception e)
        {

            throw new AppException(e.Message);
        }

    }



    public void Delete(int id)
    {
        try
        {
            var customer = getCustomer(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private Customer getCustomer(int id)
    {
        try
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) throw new KeyNotFoundException("Customer not found");
            return customer;
        }
        catch (System.Exception)
        {

            throw;
        }

    }


}