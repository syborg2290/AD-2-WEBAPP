namespace AD2_WEB_APP.Services;

using AutoMapper;
using BCrypt.Net;
using AD2_WEB_APP.Entities;
using AD2_WEB_APP.Helpers;
using AD2_WEB_APP.Models.Users;
using AD2_WEB_APP.Models.Common;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

public interface IUserService
{
    public Task<Tokens> Login(string email, string password);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class UserService : IUserService
{
    private DataContext _context;
    private readonly IMapper _mapper;
    public readonly IConfiguration configuration;

    public UserService(
        DataContext context,
        IConfiguration Configuration,
        IMapper mapper
        )
    {
        _context = context;
        _mapper = mapper;
        configuration = Configuration;
    }

    public async Task<Tokens> Login(string email, string password)
    {
        try
        {
            int id = _context.Users.Where(m => m.Email == email).Select(m => m.Id).SingleOrDefault();

            User? user = getUser(id);

            if (user == null || BCrypt.Verify(password, user.PasswordHash) == false)
            {
                return null; //returning null intentionally to show that login was unsuccessful
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim("UserId", user.Id.ToString()),
                    new Claim("Roles", user.Role.ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new Tokens { Token = tokenHandler.WriteToken(token) };
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public IEnumerable<User> GetAll()
    {
        try
        {
            return _context.Users;
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public User GetById(int id)
    {
        try
        {
            return getUser(id);
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public void Create(CreateRequest model)
    {
        try
        {
            // validate
            if (_context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // map model to new user object
            var user = _mapper.Map<User>(model);

            // hash password
            user.PasswordHash = BCrypt.HashPassword(model.Password);

            // save user
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    public void Update(int id, UpdateRequest model)
    {
        try
        {
            var user = getUser(id);

            // validate
            if (model.Email != user.Email && _context.Users.Any(x => x.Email == model.Email))
                throw new AppException("User with the email '" + model.Email + "' already exists");

            // hash password if it was entered
            if (!string.IsNullOrEmpty(model.Password))
                user.PasswordHash = BCrypt.HashPassword(model.Password);

            // copy model to user and save
            _mapper.Map(model, user);
            _context.Users.Update(user);
            _context.SaveChanges();
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
            var user = getUser(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        catch (System.Exception)
        {

            throw;
        }

    }

    // helper methods

    private User getUser(int id)
    {
        try
        {
            var user = _context.Users.Find(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }
        catch (System.Exception)
        {

            throw;
        }

    }
}