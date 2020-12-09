using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SolutionShop.Data.EF
{//phuong thuc ket noi sqlserver de update tu migration
    public class SolutionShopdbcontextfactory : IDesignTimeDbContextFactory<Shopdbcontext>
    {
        public Shopdbcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.
                GetCurrentDirectory()).AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("SolutionShopDatabase");
            var optionsBuilder = new DbContextOptionsBuilder<Shopdbcontext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new Shopdbcontext(optionsBuilder.Options);
        }
    }
}
