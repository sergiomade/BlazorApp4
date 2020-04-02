using BlazorApp4.Server.Helpers;
using BlazorApp4.Shared.DTOs;
using BlazorApp4.Shared.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class PeliculasController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IAlmacenadorDeArchivos almacenadorDeArchivos;

		public PeliculasController(ApplicationDbContext context, IAlmacenadorDeArchivos almacenadorDeArchivos)
		{
			this.context = context;
			this.almacenadorDeArchivos = almacenadorDeArchivos;
		}

		[HttpGet]
		public async Task<ActionResult<HomePageDTO>> Get()
		{
			var limite = 6;

			var peliculaEnCartelera = await context.Peliculas
				.Where(x => x.EnCartelera).Take(limite)
				.OrderByDescending(x => x.Lanzamiento)
				.ToListAsync();

			var fechaActual = DateTime.Today;

			var proximosExtrenos = await context.Peliculas
				.Where(x => x.Lanzamiento > fechaActual)
				.OrderByDescending(x => x.Lanzamiento).Take(limite)
				.ToListAsync();

			var response = new HomePageDTO()
			{
				PeliculasEnCartelera = peliculaEnCartelera,
				ProximosExtrenos = proximosExtrenos
			};

			return response;
		}

		[HttpPost]
		public async Task<ActionResult<int>> Post(Pelicula pelicula)
		{
			if (!string.IsNullOrWhiteSpace(pelicula.Poster))
			{
				var fotoPersona = Convert.FromBase64String(pelicula.Poster);
				pelicula.Poster = await almacenadorDeArchivos.GuardarArchivo(fotoPersona, "jpg", "peliculas");
			}

			context.Add(pelicula);
			await context.SaveChangesAsync();
			return pelicula.Id;
		}
	}
}
