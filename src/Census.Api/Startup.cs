using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Census.Api.AppSettings;
using Census.Api.Infrastructure.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Census.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private IContainer _container;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Latest)
                    .AddControllersAsServices()
                ;

            services.Configure<ApiBehaviorOptions>(options =>
                                                   {
                                                       options.SuppressConsumesConstraintForFormFileParameters = true;
                                                       options.SuppressInferBindingSourcesForParameters = true;
                                                       options.SuppressModelStateInvalidFilter = false;
                                                       options.InvalidModelStateResponseFactory = InvalidModelStateResponseFactory.CreateResponse;
                                                   });

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "Hipster Census API", Version = "v1"}); });

            var appSettingsRoot = _configuration.Get<AppSettingsRoot>();
            _container = IoC.LetThereBeIoC(services, appSettingsRoot);
            return new AutofacServiceProvider(_container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var corsSettings = _configuration.Get<AppSettingsRoot>().Hosting.Cors;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                        {
                            builder
                                .WithOrigins(corsSettings.AllowedOrigins)
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .SetPreflightMaxAge(TimeSpan.FromMinutes(1));
                        });

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hipster Census API v1"); });
        }
    }
}