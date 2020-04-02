using System.Threading.Tasks;

namespace BlazorApp4.Server.Helpers
{
	public interface IAlmacenadorDeArchivos
	{
		Task<string> EditarArchivo(byte[] contenido, string extension, string nombreContenedor, string rutaArchivo);
		Task EliminarArchivo(string ruta, string nombreContenedor);
		Task<string> GuardarArchivo(byte[] contenido, string extension, string nombreContenedor);
	}
}