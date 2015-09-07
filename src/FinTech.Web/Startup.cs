using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using FinTech.Core;
using FinTech.Core.Interfaces;
using Microsoft.Dnx.Runtime;
using System.IO;
using Microsoft.Framework.Configuration;
using FinTech.Core.Services;
using Microsoft.AspNet.Mvc;
using FinTech.Web.Helpers;
using Microsoft.Net.Http.Headers;

namespace FinTech.Web
{
    public class Startup
    {
        private IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var configPath = Path.Combine(appEnv.ApplicationBasePath, "..", "..");
            Configuration = new ConfigurationBuilder(configPath).AddJsonFile("config.json").Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.OutputFormatters.Clear();
                options.OutputFormatters.Add(JsonHelper.GetConfiguredOutputFormatter());

                options.InputFormatters.Clear();
                options.InputFormatters.Add(JsonHelper.GetConfiguredInputFormatter());                
            });

            services.AddWebEncoders();
            services.AddScoped<ITransactionService,TransactionService>();
            services.AddScoped<BtcService>();
            services.AddInstance(Configuration);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
