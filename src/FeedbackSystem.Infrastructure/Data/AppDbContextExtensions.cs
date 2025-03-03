﻿using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
  public AppDbContext CreateDbContext(string[] args)
  {
    var configuration = new ConfigurationBuilder()
      .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../FeedbackSystem.Web"))
      .AddJsonFile("appsettings.json")
      .Build();


    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
    optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

    return new AppDbContext(optionsBuilder.Options, null);
  }
}
