using ExamenDotNet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ExamenDotNet.Controllers
{
    public class OrdenController : Controller
    {
        // GET: OrdenController
        [HttpGet("GetById/{id}")]
        public async Task<OrdenResponse> GetById(int id)
        {
            using var client = new HttpClient();

            var result = await client.GetAsync($"http://localhost:8080/api/orden/{id}");
            var content = await result.Content.ReadAsStringAsync();
            if (content == "")
                return null;
            return JsonSerializer.Deserialize<OrdenResponse>(content);
        }
        [HttpPost("CrearOrden")]
        public async Task<OrdenResponseDTO> Crear([FromBody]OrdenRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://localhost:8080/api/orden/crear";
            using var client = new HttpClient();

            var response = await client.PostAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<OrdenResponseDTO>(result);
        }
        [HttpGet("GetOrdenes")]
        public async Task<List<OrdenResponse>> GetProductos()
        {
            using var client = new HttpClient();

            var result = await client.GetAsync($"http://localhost:8080/api/orden/");
            var content = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<OrdenResponse>>(content);
        }
        [HttpDelete("EliminarOrden/{id}")]
        public async Task<string> EliminarOrden(int id)
        {
            using var client = new HttpClient();

            var result = await client.DeleteAsync($"http://localhost:8080/api/orden/eliminar/{id}");
            var content = await result.Content.ReadAsStringAsync();
            return content;
        }
        [HttpPut("ActualizarOrden/{id}")]
        public async Task<string> ActualizarOrden(int id, [FromBody]UpdateOrdenRequest request)
        {
            var json = JsonSerializer.Serialize(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = $"http://localhost:8080/api/orden/actualizar/{id}";
            using var client = new HttpClient();

            var response = await client.PutAsync(url, data);

            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
