using AutoMapper;
using CarMeetingManager.BLL;
using CarMeetingManager.BLL.DTO;
using CarMeetingManager.BLL.Interfaces;
using CarMeetingManager.DAL;
using CarMeetingManager.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CarMeetingManager
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
            services.AddDbContext<CarMeetingContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("CarMeetingDatabase")));

            //Add authentication services
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "https://localhost:44398",
            ValidAudience = "https://localhost:44398",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("keycryptstring123"))
        };
    });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options =>
            {
                options.AddPolicy("Localhost",
                    builder => builder.WithOrigins("http://localhost:4200"));
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            
            services.AddScoped<IMeetingRepository, MeetingRepository>();
            services.AddSingleton(mapper);
            services.AddScoped<IClubsBL, ClubsBL>();
            services.AddScoped<IEventsBL, EventsBL>();
            services.AddScoped<IMembersBL, MembersBL>();
            services.AddScoped<IRegistrationsBL, RegistrationsBL>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();

            }
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("Localhost");
            app.UseAuthentication();
        }
    }
}
