namespace ExamenDotNet.Models
{
    public record UsuarioRequest(string nombre);
    public record UsuarioResponse(int id, string nombre,List<OrdenResponse> ordenes);
    public record ProductoRequest(string nombre,int stock,decimal precio);
    public record UpdateProductoRequest(string? nombre, int? stock, decimal? precio);

    public record ProductoResponse(int id,decimal? precio,string? nombre,int? stock);
    public record OrdenRequest(int usuario_id,List<OrdenProductoDTO> productos);
    public record UpdateOrdenRequest(int? usuario_id, List<OrdenProductoDTO>? productos);
   public record OrdenResponseDTO(string message,OrdenResponse orden);
    public record OrdenResponse(int id, string fecha_creacion, int usuario_id, decimal total,List<OrdenProducto> productos);
    public record OrdenProducto(int id,string fecha_creacion,int orden_Id,int producto_id,int cantidad);
    public record OrdenProductoDTO(int producto_id,int cantidad);
}
