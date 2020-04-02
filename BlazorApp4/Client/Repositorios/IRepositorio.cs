using BlazorApp4.Shared.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Client.Repositorios
{
	public interface IRepositorio
	{
		Task<HttpResponseWrapper<object>> Post<T>(string url, T enviar);
		List<Pelicula> ObtenerPeliculas();
		Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T enviar);
		Task<HttpResponseWrapper<T>> Get<T>(string url);
	}
}
