using ExamenDotNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ExamenDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        // GET: UsuarioController

        // GET: UsuarioController/Details/5
        [HttpGet("GetById/{id}")]
        public async Task<UsuarioResponse> GetById(int id)
        {
            using var client = new HttpClient();

            var result = await client.GetAsync($"http://localhost:8080/api/usuarios/{id}");
           var content =await  result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<UsuarioResponse>(content);
        }
        [HttpPost("CrearUsuario")]
        public async Task<ProductoResponse> Crear(ProductoRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://localhost:8080/api/usuarios/crear";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductoResponse>(result);
        }
        [HttpGet("GetUsuarios")]
        public async Task<List<UsuarioResponse>> GetProductos()
        {
            using var client = new HttpClient();

            var result = await client.GetAsync($"http://localhost:8080/api/usuarios/hola");
            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<UsuarioResponse>>(content);
        }
        [HttpDelete("EliminarUsuario/{id}")]
        public async Task<string> EliminarProducto(int id)
        {
            using var client = new HttpClient();

            var result = await client.DeleteAsync($"http://localhost:8080/api/usuarios/eliminar/{id}");
            var content = await result.Content.ReadAsStringAsync();
            return content;
        }
        [HttpPut("ActualizarUsuario/{id}")]
        public async Task<string> ActualizarProducto(int id, UsuarioRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"http://localhost:8080/api/usuarios/actualizar/{id}";
            using var client = new HttpClient();

            var response = await client.PutAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

        // GET: UsuarioController/Create

        // POST: UsuarioController/Create

        // GET: UsuarioController/Edit/5

        // POST: UsuarioController/Edit/5

        // GET: UsuarioController/Delete/5

        // POST: UsuarioController/Delete/5
    }
}
