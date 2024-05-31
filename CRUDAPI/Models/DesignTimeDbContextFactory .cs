using CRUDAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<Contexto>
{
    public Contexto CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("ConexaoBD");

        var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
        optionsBuilder.UseSqlServer(connectionString);

        return new Contexto(optionsBuilder.Options);
    }
}
