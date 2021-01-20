using Bogus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mock.RestApi.Fakers;
using Mock.RestApi.IServices;
using Mock.RestApi.Models;
using Mock.RestApi.Services;
using System.Collections.Generic;
using System.Linq;

namespace Mock.RestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            int customersQuantity = int.Parse(Configuration["Fakers:Customers"]);
            int machineQuantity = int.Parse(Configuration["Fakers:Machines"]);
            var customers = new CustomerFaker().Generate(customersQuantity).ToArray();
            var machines = new MachineFaker(customers).Generate(machineQuantity).ToArray();
            services.AddControllers();
            services.AddSingleton<IMachineService, MachineService>();
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<Faker<Customer>, CustomerFaker>();
            services.AddSingleton<Customer[]>(customers);
            services.AddSingleton<Faker<Machine>, MachineFaker>();
            services.AddSingleton<ICollection<Customer>>(customers.ToList());
            services.AddSingleton<ICollection<Machine>>(machines.ToList());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
