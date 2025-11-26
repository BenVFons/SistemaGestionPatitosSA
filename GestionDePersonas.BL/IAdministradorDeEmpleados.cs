using GestionDePersonas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.BL
{
    public interface IAdministradorDeEmpleados
    {
        Task<IEnumerable<msjResp>> AgregarEmpleadoSP(CrearEmpleado empleado, string Gestion);
        Task<IEnumerable<Empleado>> ObtengaListaEmpleadosAsync();
        Task<Empleado?> ObtengaAlEmpleadoaAsync(int id);
        Task<IEnumerable<Empleado>> EmpleadoOrdenadoxFechaIngreso();
        Task<IEnumerable<Empleado>> EmpleadoOrdenadoxHorario();
        Task<IEnumerable<Empleado>> EmpleadoOrdenadoxPuesto();
        Task<String> ActualizarEmpleadoAsync(int id, Empleado empleado);
        Task<String> EliminarEmpleadAsync(int id);
        Task ActiveEmpleadoAsync(int id);
        Task DesActiveEmpleadoAsync(int id);
        Task<IEnumerable<Empleado>> ObtengaListaDeActivosAsync();
        Task<IEnumerable<Empleado>> ObtengaListaDeInActivosAsync();
    }
}
