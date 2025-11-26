using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;

namespace GestionDePersonas.DA
{
    public interface IEmpleadoRepository
    {
        Task<Empleado?> ObtenerEmpleadoPorIdAsync(int id);
        Task<IEnumerable<Empleado>> ObtenerEmpleadoAsync();
        Task AgregarEmpleadoAsync(Empleado empleado);
        Task ActualizarEmpleadoAsync(Empleado empleado);
        Task EliminarEmpleadoAsync(int id);
        Task ActivarEmpleadoAsync(int id);
        Task DesActivarEmpleadoAsync(int id);
    }

    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly DBContexto _context;

        public EmpleadoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Empleado?> ObtenerEmpleadoPorIdAsync(int id)
        {
            return await _context.Empleado.FirstOrDefaultAsync(p => p.idEmpleado == id);
        }

        public async Task<IEnumerable<Empleado>> ObtenerEmpleadoAsync()
        {
            return await _context.Empleado.ToListAsync();
        }

        public async Task AgregarEmpleadoAsync(Empleado empleado)
        {
            await _context.Empleado.AddAsync(empleado); //Empleado es Tabla Empleado
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarEmpleadoAsync(Empleado empleado)
        {
            _context.Empleado.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEmpleadoAsync(int id)
        {
            var empleado = await ObtenerEmpleadoPorIdAsync(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarEmpleadoAsync(int id)
        {
            var empleado = await ObtenerEmpleadoPorIdAsync(id);
            if (empleado != null)
            {
                empleado.Activo = true;
                _context.Empleado.Update(empleado);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarEmpleadoAsync(int id)
        {
            var empleado = await ObtenerEmpleadoPorIdAsync(id);
            if (empleado != null)
            {
                empleado.Activo = false;
                _context.Empleado.Update(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
