using AutoMapper;
using CarMeetingManager.BLL.DTO;
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
            //Initialize mapper for the DTO <> Model mapping
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Club, ClubDTO>();
                cfg.CreateMap<Club, ClubDTO>();
                cfg.CreateMap<ClubDTO, Club>();
                cfg.CreateMap<Event, EventDTO>();
                cfg.CreateMap<EventDTO, Event>();
                cfg.CreateMap<Member, MemberDTO>();
                cfg.CreateMap<MemberDTO, Member>();
                cfg.CreateMap<Registration, RegistrationDTO>();
                cfg.CreateMap<RegistrationDTO, Registration>();
            });
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
