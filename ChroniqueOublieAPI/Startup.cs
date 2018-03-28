using AutoMapper;
using ChroniqueOublieAPI.Contexts;
using ChroniqueOublieAPI.Models.Interface;
using ChroniqueOublieAPI.Models.Maitrise;
using ChroniqueOublieAPI.Models.Maitrise.Type;
using ChroniqueOublieAPI.Models.Voie;
using ChroniqueOublieAPI.Models.Voie.Profil;
using ChroniqueOublieAPI.Models.Voie.Type;
using ChroniqueOublieAPI.Service.Interface;
using ChroniqueOublieAPI.Service.Maitrise;
using ChroniqueOublieAPI.Service.Maitrise.Interface;
using ChroniqueOublieAPI.Service.Voie;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace ChroniqueOublieAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment @Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            ConfigureAutoMapper();
            ConfigureModel(services);
            ConfigureService(services);
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<ChroniqueOublieContext>(options =>
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
        }

        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProfilEntity, ProfilDTO>();
                cfg.CreateMap<VoieTypeEntity, VoieTypeDTO>();
                cfg.CreateMap<VoieEntity, VoieDTO>()
                .ForMember(dest => dest.Profils, opt => opt.Ignore());
                cfg.CreateMap<MaitriseTypeEntity, MaitriseTypeDTO>();
                cfg.CreateMap<MaitriseEntity, MaitriseDTO>()
                .ForMember(dest => dest.Types, opt => opt.Ignore());
            });
        }

        private void ConfigureModel(IServiceCollection services)
        {
            services.AddTransient<IProfilDAOInterface, ProfilDAO>();
            services.AddTransient<IVoieTypeDAOInterface, VoieTypeDAO>();
            services.AddTransient<IVoieDAOInterface, VoieDAO>();
            services.AddTransient<IMaitriseTypeDAOInterface, MaitriseTypeDAO>();
            services.AddTransient<IMaitriseDAOInterface, MaitriseDAO>();
        }

        private void ConfigureService(IServiceCollection services)
        {
            services.AddTransient<IProfilServiceInterface, ProfilService>();
            services.AddTransient<IMaitriseTypeServiceInterface, MaitriseTypeService>();
            services.AddTransient<IVoieTypeServiceInterface, VoieTypeService>();
            services.AddTransient<IMaitriseServiceInterface, MaitriseService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc()
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                }
                );
        }
    }
}