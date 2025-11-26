using GestionDePersonas.BL;
using GestionDePersonas.DA;
using GestionDePersonas.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;

namespace SistemaGestionPatitosSA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicioDePersonasController : ControllerBase
    {
        private readonly IAdministradorDeEmpleados _admin;
        private readonly IEmpleadoRepository _empl;

        public ServicioDePersonasController(IAdministradorDeEmpleados admin, IEmpleadoRepository empl)
        {
            _admin = admin;
            _empl = empl;
        }

        [HttpPost("Agregue un empleado nuevo")] //post = subir 
        public async Task<IActionResult> AgregarEmpleadoSP([FromBody] CrearEmpleado CE, string Gestion) //FromBody = del cuerpo de la solicitud
        {
            try
            {
                var EmpleadoGuardado = await _admin.AgregarEmpleadoSP(CE, Gestion);
                return Ok(EmpleadoGuardado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //message detalle error

            }
        }

        [HttpPut("Modifique a un empleado/{id}")]
        public async Task<IActionResult> ActualizarEmpleadoAsync(int id, [FromBody] Empleado CE)
        {
            try
            {
                var EmpleadoAct = await _admin.ActualizarEmpleadoAsync(id, CE); // Icurso o el servicio relacionado
                return Ok(EmpleadoAct);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("Active a un empleado/{id}")]
        public async Task<IActionResult> ActiveEmpleadoAsync(int id)
        {
            await _admin.ActiveEmpleadoAsync(id);
            return Ok();
        }

        [HttpPut("Desactive a un empleado/{id}")]
        public async Task<IActionResult> DesActive(int id)
        {
            await _admin.ActiveEmpleadoAsync(id);
            return Ok();
        }

        [HttpDelete("Elimine a un empleado/{id}")]
        public async Task<IActionResult> EliminarAsync(int id)
        {
            try
            {
                var EmpleadoBorrada = await _admin.EliminarEmpleadAsync(id); 
                return Ok(EmpleadoBorrada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("Ver lista de Empleados")]
        public async Task<ActionResult<IEnumerable<CrearEmpleado>>> ObtengaListaEmpleadosAsync()
        {
            try
            {
                var ListaEmpl = await _admin.ObtengaListaEmpleadosAsync();
                return Ok(ListaEmpl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //message detalle error
            }
        }

        [HttpGet("Vea a un empleado")]
        public async Task<ActionResult<Empleado>> ObtengaAlEmpleado(int id)
        {
            try
            {
                var empleado = await _empl.ObtenerEmpleadoPorIdAsync(id);
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //message detalle error
            }

            //var persona = await _empl.ObtenerEmpleadoPorIdAsync(id);
            //if (persona == null)
            //    return NotFound();
            //return Ok(persona);
        }
        
        [HttpGet("Ver lista de Empleados ordenada por Fecha de Ingreso")]
        public async Task<ActionResult<IEnumerable<CrearEmpleado>>> EmpleadoOrdenadoxFechaIngreso()
        {
            try
            {
                var ListaEmpl = await _admin.EmpleadoOrdenadoxFechaIngreso();
                return Ok(ListaEmpl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //message detalle error
            }
        }

        [HttpGet("Ver lista de Empleados ordenada por Horario")]
        public async Task<ActionResult<IEnumerable<CrearEmpleado>>> EmpleadoOrdenadoxHorario()
        {
            try
            {
                var ListaEmpl = await _admin.EmpleadoOrdenadoxHorario();
                return Ok(ListaEmpl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //message detalle error
            }
        }

        [HttpGet("Ver lista de Empleados ordenada por Puesto")]
        public async Task<ActionResult<IEnumerable<CrearEmpleado>>> EmpleadoOrdenadoxPuesto()
        {
            try
            {
                var ListaEmpl = await _admin.EmpleadoOrdenadoxPuesto();
                return Ok(ListaEmpl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); //message detalle error
            }
        }

        [HttpGet("ObtengaLaListaDeActivos")]
        public async Task<ActionResult<IEnumerable<CrearEmpleado>>> ObtengaListaDeActivosAsync()
        {
            var lista = await _admin.ObtengaListaDeActivosAsync();
            return Ok(lista);
        }

        [HttpGet("ObtengaLaListaDeInActivos")]
        public async Task<ActionResult<IEnumerable<CrearEmpleado>>> ObtengaListaDeInActivosAsync()
        {
            var lista = await _admin.ObtengaListaDeInActivosAsync();
            return Ok(lista);
        }
    }
}
