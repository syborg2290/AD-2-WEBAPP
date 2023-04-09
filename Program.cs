using System.Text.Json.Serialization;
using AD2_WEB_APP.Helpers;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;


    services.AddDbContext<DataContext>();

    services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();
    services.ConfigureApplicationCookie(config =>
    {
        config.LoginPath = "/Admin/Auth/Login";
    });

    services.AddScoped<UserManager<ApplicationUser>>();
    services.AddScoped<SignInManager<ApplicationUser>>();

    services.Configure<IdentityOptions>(options =>
    {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = false;

        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // User settings
        options.User.RequireUniqueEmail = true;
    });

    services.ConfigureApplicationCookie(options =>
    {
        // Cookie settings
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });
    services.AddSession(); // After AddMvc()
    services.AddCors();
    services.AddSwaggerGen();
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        // ignore omitted parameters on models to enable optional params (e.g. User update)
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


    // configure DI for application services
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ICategoryService, CategoryService>();
    services.AddScoped<ICustomerService, CustomerService>();
    services.AddScoped<ICommonService, CommonService>();
    services.AddScoped<IAddressService, AddressService>();
    services.AddScoped<IComputerModelService, ComputerModelService>();
    services.AddScoped<IDefaultConfigurationService, DefaultConfigurationService>();
    services.AddScoped<IConfigurationService, ConfigurationService>();
    services.AddScoped<IItemService, ItemService>();
    services.AddScoped<IOrderItemService, OrderItemService>();
    services.AddScoped<IPaymentService, PaymentService>();
    services.AddScoped<ISeriesService, SeriesService>();

}

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseDefaultFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();  // Before UseMvc()
app.MapRazorPages();

app.Run();
