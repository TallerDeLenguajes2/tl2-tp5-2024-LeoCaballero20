using Microsoft.AspNetCore.Mvc;

namespace TiendaAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class ProductoController : ControllerBase {

    private ProductoRepository repositorio;

    public ProductoController() {
        repositorio = new();
    }

    [HttpPost]

    public ActionResult<List<Producto>> crearProducto(Producto producto) {
        repositorio.CrearProducto(producto);
        return Ok(repositorio.ListarProductos());
    }

    [HttpGet]

    public ActionResult<List<Producto>> listarProductos() {
        return Ok(repositorio.ListarProductos());
    }

    [HttpPut("{id}")]

    public ActionResult<Producto> modificarNombreProducto(int id, string nuevoNombre) {
        Producto prod = repositorio.ObtenerProducto(id);
        prod.Descripcion = nuevoNombre;
        repositorio.ModificarProducto(id, prod);
        return Ok(repositorio.ObtenerProducto(id));
    }
}