using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesService.Service.Domain;
using MoviesService.Service.Repository;
using Microsoft.OpenApi.Models;

namespace MoviesService.Service
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            RegisterDependencies(services);

            AddInMemoryDatabase(services);

            RegisterSwagger(services);
        }

        private void RegisterSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie Ratings", Version = "v1" });
            });
        }

        public void RegisterDependencies(IServiceCollection services)
        {
            //register domains and repositories
            services.AddTransient<IMoviesDomain, MoviesDomain>();
            services.AddTransient<IMoviesRepository, MoviesRepository>();
            services.AddTransient<IRatingDomain, RatingDomain>();
            services.AddTransient<IRatingRepository, RatingRepository>();
            services.AddTransient<IUsersDomain, UsersDomain>();
            services.AddTransient<IUsersRepository, UsersRepository>();
        }

        public void AddInMemoryDatabase(IServiceCollection services)
        {
            services.AddDbContext<MovieServiceDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "MovieServiceDatabase"));
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie Ratings V1");
               
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
