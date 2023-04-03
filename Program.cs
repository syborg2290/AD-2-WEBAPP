using System.Text.Json.Serialization;
using AD2_WEB_APP.Helpers;
using AD2_WEB_APP.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);


// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;


    services.AddDbContext<DataContext>();
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

    builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; // for development only
    opt.SaveToken = true;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"])),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
