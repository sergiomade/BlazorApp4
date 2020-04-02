using System;
using Blazor.FileReader;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BlazorApp4.Client.Repositorios;
using BlazorApp4.Client.Helpers;
using static BlazorApp4.Client.Servicios;

namespace BlazorApp4.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.RootComponents.Add<App>("app");
			ConfigureServices(builder.Services);
			await builder.Build().RunAsync();
		}

		private static void ConfigureServices(IServiceCollection services)
		{
			services.AddOptions();
			services.AddSingleton<ServicioSingleton>();
			services.AddTransient<ServicioTransient>();
			services.AddScoped<IRepositorio, Repositorio>();
			services.AddScoped<IMostrarMensajes, MostrarMensajes>();
			services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
		}
	
	}
}


