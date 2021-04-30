using AuthenticationExemple.Interfaces;
using AuthenticationExemple.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationExemple
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthenticationExemple", Version = "v1" });
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme,new OpenApiSecurityScheme() { Name="Authorization", In = ParameterLocation.Header, Type=SecuritySchemeType.ApiKey, Scheme = JwtBearerDefaults.AuthenticationScheme});
            });
            services.AddTransient<ITokenGenerator, JwtService>();
            services.AddScoped<IAuthorizationHandler, RoleAuthorizationHandler>();

            //Ajouter la configuration du service authentification
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Hello world from our api token")),
                    ValidateIssuer = true,
                    ValidIssuer = "utopios",
                    ValidateAudience = true,
                    ValidAudience = "utopios"
                };
            });
            //Ajouter la configuration du service authorisation
            services.AddAuthorization(options => {
                options.AddPolicy("customer", police =>
                {
                    police.AddRequirements(new RoleRequirement() { Role = new List<string>() { Models.Role.customer.ToString()} });
                });
                options.AddPolicy("admin", police =>
                {
                    police.AddRequirements(new RoleRequirement() { Role = new List<string>() { Models.Role.admin.ToString(), Models.Role.customer.ToString() } });
                });
            });
            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            //app.UseHttpsRedirection();
            
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthenticationExemple v1"));
            }
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
