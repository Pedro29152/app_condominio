﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCondominio.Repository;
using AppCondominio.Repository.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppCondominio
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<CondominioContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("SqliteConnection"))
            );

            services.AddTransient<IGastosRepo,          GastosRepo>();
            services.AddTransient<IContatoRepo,         ContatoRepo>();
            services.AddTransient<IClienteRepo,         ClienteRepo>();
            services.AddTransient<ILocadorRepo,         LocadorRepo>();
            services.AddTransient<IMaterialRepo,        MaterialRepo>();
            services.AddTransient<IContratoRepo,        ContratoRepo>();
            services.AddTransient<IEnderecoRepo,        EnderecoRepo>();
            services.AddTransient<ILocatarioRepo,       LocatarioRepo>();
            services.AddTransient<IFornecedorRepo,      FornecedorRepo>();
            services.AddTransient<IControleInOutRepo,   ControleInOutRepo>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
