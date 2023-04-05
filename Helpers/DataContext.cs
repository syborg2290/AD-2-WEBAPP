namespace AD2_WEB_APP.Helpers;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using AD2_WEB_APP.Entities;


public class DataContext : IdentityDbContext<ApplicationUser>
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options) : base(options)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>(entity =>
        {
            // Add custom configuration for ApplicationUser entity
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to mysql with connection string from app settings
        var connectionString = Configuration.GetConnectionString("WebApiDatabase");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<ComputerModel> ComputerModel { get; set; }
    public DbSet<Configuration> ItemConfiguration { get; set; }
    public DbSet<DefaultConfiguration> DefaultConfiguration { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Payment> Payment { get; set; }
    public DbSet<Series> Series { get; set; }


}

public class ApplicationUser : IdentityUser
{
    // You can add custom properties here


}