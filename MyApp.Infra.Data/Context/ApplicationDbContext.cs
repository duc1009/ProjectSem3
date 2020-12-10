
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyApp.Domain.Models;
using MyApp.Infra.Data.Mappings;
using NetDevPack.Data;
using NetDevPack.Domain;
using NetDevPack.Mediator;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Context
{
    public sealed class ApplicationDbContext : IdentityDbContext, IUnitOfWork
    {
    
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<TodoApp> TodoApps { get; set; }

        public DbSet<MyManager> MyManagers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<StatusPay> StatusPays { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MaterialMapping());
            modelBuilder.ApplyConfiguration(new SizeMapping());
            modelBuilder.ApplyConfiguration(new PriceMapping());
            modelBuilder.ApplyConfiguration(new BillMapping());
            modelBuilder.ApplyConfiguration(new BillDetailMapping());
            modelBuilder.ApplyConfiguration(new PaymentMapping());
            modelBuilder.ApplyConfiguration(new StatusMapping());
            modelBuilder.ApplyConfiguration(new StatusPayMapping());
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;
            return success;
        }
    }

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../MyApp.Web.Ui/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
