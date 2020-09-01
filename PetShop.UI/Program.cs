using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Impl;
using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Impl;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ServiceCollection = new ServiceCollection();
            ServiceCollection.AddScoped<IPetRepository, PetRepository>();
            ServiceCollection.AddScoped<IValidatorService, ValidatorService>();
            ServiceCollection.AddScoped<IPetService, PetService>();
            ServiceCollection.AddScoped<IPrinter, Printer>();

            var ServiceProvider = ServiceCollection.BuildServiceProvider();
            var Printer = ServiceProvider.GetRequiredService<IPrinter>();
            var Data = new InitData(ServiceProvider.GetRequiredService<IPetRepository>());

            Printer.Start();
        }
    }
}
