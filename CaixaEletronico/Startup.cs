using caixaEletronico.DAO;
using caixaEletronico.DAO.Repositories;
using caixaEletronico.Domain.Interfaces;
using CaixaEletronico.GraphQl.GraphQLSchema;
using CaixaEletronico.GraphQl.Queries;
using CaixaEletronico.Helper;
using CaixaEletronico.InputTypes;
using CaixaEletronico.Queries;
using CaixaEletronico.Types;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using DocumentExecuter = GraphQL.DocumentExecuter;

namespace CaixaEletronico
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
            services.AddMvc();
            services.AddRazorPages();
            services.AddSingleton<ContextServiceLocator>();
            services.AddDbContext<CaixaEletronicoContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:CaixaEletronicoDatabase"]));
            
            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<CaixaEletronicoQuery>();
            services.AddSingleton<CaixaEletronicoMutation>();
            services.AddSingleton<ContaInputType>();
            services.AddSingleton<ContaType>();
            services.AddSingleton<ISchema, CaixaEletronicoSchema>();

            services.AddControllers();
            services.AddLogging(builder => builder.AddConsole());
            services.AddHttpContextAccessor();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphiQl();
            app.UseRouting();
            app.UseMvc();
        }
    }
}
