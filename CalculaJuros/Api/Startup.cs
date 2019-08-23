using Aplicacao;
using Aplicacao.Configuracao;
using Aplicacao.Configuracao.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Servico.Implementacao;
using Servico.Interfaces;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace Api
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
            services.BuildServiceProvider();
            var informacoesProjeto = new InformacoesProjeto();
            new ConfigureFromConfigurationOptions<InformacoesProjeto>(Configuration.GetSection("InformacoesProjeto")).Configure(informacoesProjeto);

            services.AddSingleton(informacoesProjeto);
            services.AddScoped<ICalculoServico, CalculoServico>();
            services.AddScoped<IInformacoesProjetoServico, InformacoesProjetoServico>();
            services.AddScoped<IMensagens, Mensagens>();
            services.AddMvcCore().AddJsonFormatters().AddApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                   new Info
                   {
                       Title = "APICalculaJuros",
                       Version = "v1",
                       Description = "API para calculo de juros."
                   });

                string caminhoAplicacao =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao =
                    PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc =
                    Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                c.IncludeXmlComments(caminhoXmlDoc);
            });

            // Configura��o do CORS
            services.AddCors(o => o.AddPolicy("CorsConfig", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            AdapterDtoDomain.MapperRegister();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider provider)
        {
            //Adicionado a configuração do cors ao Config.
            app.UseCors("CorsConfig");

            app.UseDeveloperExceptionPage();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Calcula Juros");
            });
        }
    }
}
