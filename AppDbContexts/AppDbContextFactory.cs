using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_02_EFC_.AppDbContexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();


            optionsBuilder.UseSqlServer(
                "Server=.; Database=EventHubDb; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=true"
            );

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
