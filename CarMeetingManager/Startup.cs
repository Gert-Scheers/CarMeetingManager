using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using CarMeetingManager.DAL;
using AutoMapper;
using CarMeetingManager.Models;
using CarMeetingManager.BLL;
using CarMeetingManager.BLL.DTO;

namespace CarMeetingManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
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
        }
    }
}
