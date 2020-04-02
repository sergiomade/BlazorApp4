using BlazorApp4.Server.Helpers;
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

	public class PersonasController : ControllerBase
	{
		private readonly ApplicationDbContext context;
		private readonly IAlmacenadorDeArchivos almacenadorDeArchivos;
	
		public PersonasController(ApplicationDbContext context, IAlmacenadorDeArchivos almacenadorDeArchivos)
		{
			this.context = context;
			this.almacenadorDeArchivos = almacenadorDeArchivos;
		}

		[HttpGet]
		public async Task<ActionResult<List<Persona>>> Get()
		{
			return await context.Personas.ToListAsync();
		}

		[HttpGet("buscar/{textoBusqueda}")]
		public async Task<ActionResult<List<Persona>>> Get(string textoBusqueda)
		{
			if (string.IsNullOrWhiteSpace(textoBusqueda)) { return new List<Persona>(); }
			textoBusqueda = textoBusqueda.ToLower();
			return await context.Personas.Where(x => x.Nombre.ToLower().Contains(textoBusqueda)).ToListAsync();
		}
		
		
		[HttpPost]
		public async Task<ActionResult<int>> Post(Persona persona)
		{
			if (!string.IsNullOrWhiteSpace(persona.Foto))
			{
				var fotoPersona = Convert.FromBase64String(persona.Foto);
				persona.Foto = await almacenadorDeArchivos.GuardarArchivo(fotoPersona, "jpg", "personas");
			}

			context.Add(persona);
			await context.SaveChangesAsync();
			return persona.Id;
		}
	}
}
