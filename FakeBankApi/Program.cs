using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeBankModel.Implementations;
using FakeBankModel.Interfaces;
using FakeBankService.Implementations;
using FakeBankService.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FakeBankApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddSingleton<ICustomerModel, CustomerModel>();
                    services.AddSingleton<ITransactionModel, TransactionModel>();
                    services.AddSingleton<IBankAccountTransferModel, BankAccountTransferModel>();
                    services.AddSingleton<IBankAccountModel, BankAccountModel>();

                    services.AddScoped<ICustomerService, CustomerService>();
                    services.AddScoped<ITransactionService, TransactionService>();
                    services.AddScoped<IBankAccountTransactionService, BankAccountTransactionService>();
                    services.AddScoped<IBankAccountTransferTransactionService, BankAccountTransferTransactionService>();
                    services.AddScoped<IBankAccountTransferService, BankAccountTransferService>();
                    services.AddScoped<IBankAccountService, BankAccountService>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
