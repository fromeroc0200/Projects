using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;

namespace PTCApi
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
      // Get JWT Token Settings from JwtSettings.json file
      JwtSettings settings;
      settings = GetJwtSettings();
      // Create singleton of JwtSettings
      services.AddSingleton<JwtSettings>(settings);

      // Register Jwt as the Authentication service
      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = "JwtBearer";
        options.DefaultChallengeScheme = "JwtBearer";
      })
      .AddJwtBearer("JwtBearer", jwtBearerOptions =>
      {
        jwtBearerOptions.TokenValidationParameters =
            new TokenValidationParameters
            {
              ValidateIssuerSigningKey = true,
              IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(settings.Key)),
              ValidateIssuer = true,
              ValidIssuer = settings.Issuer,

              ValidateAudience = true,
              ValidAudience = settings.Audience,

              ValidateLifetime = true,
              ClockSkew = TimeSpan.FromMinutes(
                       settings.MinutesToExpiration)
            };
      });

      services.AddAuthorization(cfg =>
      {
        // NOTE: The claim type and value are case-sensitive
        cfg.AddPolicy("CanAccessProducts", p => p.RequireClaim("CanAccessProducts", "true"));
      });

      services.AddCors();

      services.AddMvc()
      .AddJsonOptions(options =>
        options.SerializerSettings.ContractResolver =
      new CamelCasePropertyNamesContractResolver());
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseCors(
        options => options.WithOrigins(
          "http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
      );

      app.UseAuthentication();

      app.UseMvc();
    }

    public JwtSettings GetJwtSettings()
    {
      JwtSettings settings = new JwtSettings();

      settings.Key = Configuration["JwtSettings:key"];
      settings.Audience = Configuration["JwtSettings:audience"];
      settings.Issuer = Configuration["JwtSettings:issuer"];
      settings.MinutesToExpiration =
       Convert.ToInt32(
          Configuration["JwtSettings:minutesToExpiration"]);

      return settings;
    }
  }
}
