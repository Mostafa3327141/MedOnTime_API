using Core;
using Core.Models.CaretakerNameSpace;
using Core.Models.logSpace;
using Core.Models.MedicationNameSpace;
using Core.Models.PatientSpace;
using Core.Models.PrescriptionSpace;
using Core.Models.SubscriptionSpace;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedOnTime_API
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

            //services.AddSingleton<IMongoClient, MongoClient>(sp =>
            //new MongoClient(Configuration.GetConnectionString("MongoDb")));

            services.AddSingleton<IDBClient, DBClient>();
            services.Configure<MedOnTimeDBConfig>(Configuration);
            services.AddTransient<IMedicationServices, MedicationServices>();
            services.AddTransient<ICaretakerServices, CaretakerServices>();
            services.AddTransient<IPatientServices, PatientServices>();
            services.AddTransient<ILogServices, LogServices>();
            services.AddTransient<ISubscriptionServices, SubscriptionServices>();
            services.AddTransient<IPrescriptionServices, PrescriptionServices>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MedOnTime_API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MedOnTime_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
