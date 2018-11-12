using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KBVB.API.Entities;
using KBVB.API.Interfaces;
using KBVB.API.Models;
using KBVB.API.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace KBVB.API
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
			services.AddMvc(setupAction =>
            {
                // Returns 406 Not Acceptable if the Accept Header is not supported
                setupAction.ReturnHttpNotAcceptable = true;
                // Adds the XML Output Formatter, making it possible to request application/xml data,
                // If the accept header is empty, the first OutputFormatter in the list is used
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            })
                .AddJsonOptions(
                    o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddDbContext<KbvbContext>(o =>
                o.UseSqlServer("Server=tcp:kbvb-ar.database.windows.net,1433;Initial Catalog=kbvb-ar-dev;Persist Security Info=False;User ID=kbvbardev;Password=T34mBadass;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IPlayerRepository, PlayerRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            KbvbContext kbvbContext)
        {
            if (env.IsDevelopment())
            {
                KbvbContextExtensions.EnsureSeeded(kbvbContext);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

			AutoMapper.Mapper.Initialize(cfg =>
			{
				cfg.CreateMap<Player, PlayerDto>();
				cfg.CreateMap<User, UserDto>();
				cfg.CreateMap<User, UserForCreationDto>()
				    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
				    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
			} );

            app.UseMvc();
        }

        
    }
}
