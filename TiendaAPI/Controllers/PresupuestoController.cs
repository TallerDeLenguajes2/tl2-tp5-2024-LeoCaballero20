using Microsoft.AspNetCore.Mvc;

namespace TiendaAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class PresupuestoController : ControllerBase {

    private PresupuestoRepository repositorio;

    public PresupuestoController() {
        repositorio = new();
    }

    [HttpPost]

    public ActionResult<List<Presupuesto>> crearPresupuesto(Presupuesto Presupuesto) {
        repositorio.CrearPresupuesto(Presupuesto);
        return Ok(repositorio.ListarPresupuestos());
    }

    [HttpGet]

    public ActionResult<List<Presupuesto>> listarPresupuestos() {
        return Ok(repositorio.ListarPresupuestos());
    }

    [HttpPost("PresupuestoDetalle/{id}")]

    public ActionResult agregarDetallePresupuesto(int id, Producto producto, int cantidad) {
        repositorio.AgregarDetallePresupuesto(id, producto, cantidad);
        return Ok();
    }
}