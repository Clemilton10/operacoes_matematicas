using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using scaffold_linha_de_comando_v5.Services.Implementations;

namespace scaffold_linha_de_comando_v5
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc(
					"v1",
					new OpenApiInfo
					{
						Title = "scaffold_linha_de_comando_v5",
						Version = "v1"
					}
				);
			});
			services.AddScoped<IPersonServices, PersonImplementation>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(
					c => c.SwaggerEndpoint(
						"/swagger/v1/swagger.json",
						"scaffold_linha_de_comando_v5 v1"
					)
				);
			}
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
