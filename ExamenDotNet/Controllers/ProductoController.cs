using ExamenDotNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ExamenDotNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        // GET: ProductoController

        // GET: ProductoController/Details/5

        // POST: ProductoController/Create
        [HttpGet("GetProductoById/{id}")]
        public async Task<ProductoResponse> GetById(int id)
        {
            using var client = new HttpClient();

            var result = await client.GetAsync($"http://localhost:8080/api/producto/{id}");
            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductoResponse>(content);
        }
        [HttpPost("CrearProducto")]
        public async Task<ProductoResponse> Crear(ProductoRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://localhost:8080/api/producto/crear";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductoResponse>(result);
        }
        [HttpGet("GetProductos")]
        public async Task<List<ProductoResponse>> GetProductos()
        {
            using var client = new HttpClient();

            var result = await client.GetAsync($"http://localhost:8080/api/producto/");
            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<ProductoResponse>>(content);
        }
        [HttpDelete("EliminarProducto/{id}")]
        public async Task<string> EliminarProducto(int id)
        {
            using var client = new HttpClient();

            var result = await client.DeleteAsync($"http://localhost:8080/api/producto/eliminar/{id}");
            var content = await result.Content.ReadAsStringAsync();
            return content;
        }
        [HttpPut("ActualizarProducto/{id}")]
        public async Task<string> ActualizarProducto(int id,UpdateProductoRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"http://localhost:8080/api/producto/actualizar/{id}";
            using var client = new HttpClient();

            var response = await client.PutAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }

    }
}
