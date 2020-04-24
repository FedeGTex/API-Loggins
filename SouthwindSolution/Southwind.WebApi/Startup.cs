using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Southwind.DataAccess;
using Southwind.UnitOfWork;

namespace Southwind.WebApi
{
    public class Startup
    {
        //No tengo una capa para lógica de negocios, así que la dependencia de IUnitOfWork será sobre los controladores
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //En el caso del AddSingleton
            //Se creará una sola dependencia para todo el ciclo de vida de éste proyecto
            //o hasta que el servidor sea reiniciado
            //lo ideal es que se inicialice con parametros
            //en éste caso el parámetro es la cadena de conexión
            services.AddSingleton<IUnitOfWork>(option => new SouthWindUnitOfWork(
                Configuration.GetConnectionString("SouthWind")
                ));
            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
        }
    }
}
