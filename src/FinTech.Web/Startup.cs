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
            services.AddMvc();
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
