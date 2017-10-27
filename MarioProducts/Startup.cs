using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MarioProducts.Models;

namespace MarioProducts
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; set; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json");
			Configuration = builder.Build();
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddEntityFrameworkMySql()
					.AddDbContext<MarioProductsDbContext>(options =>
											  options
												   .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));
			services.AddIdentity<ApplicationUser, IdentityRole>()
					.AddEntityFrameworkStores<MarioProductsDbContext>()
					.AddDefaultTokenProviders();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
            app.UseIdentity();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});

			loggerFactory.AddConsole();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();

			app.Run(async (context) =>
			{
				await context.Response.WriteAsync("This page is under construction");
			});
		}
	}
}
