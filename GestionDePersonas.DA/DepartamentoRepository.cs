using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IDepartamentoRepository
    {
        Task<Departamento?> ObtenerDepartamentoPorIdAsync(int id);
        Task<IEnumerable<Departamento>> ObtenerDepartamentoAsync();
        Task AgregarDepartamentoAsync(Departamento departamento);
        Task ActualizarDepartamentoAsync(Departamento departamento);
        Task EliminarDepartamentoAsync(int id);
        Task ActivarDepartamentoAsync(int id);
        Task DesActivarDepartamentoAsync(int id);
    }

    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly DBContexto _context;

        public DepartamentoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Departamento?> ObtenerDepartamentoPorIdAsync(int id)
        {
            return await _context.Departamento.FirstOrDefaultAsync(p => p.idDepartamento == id);
        }

        public async Task<IEnumerable<Departamento>> ObtenerDepartamentoAsync()
        {
            return await _context.Departamento.ToListAsync();
        }

        public async Task AgregarDepartamentoAsync(Departamento departamento)
        {
            await _context.Departamento.AddAsync(departamento); //Empleado es Tabla Empleado
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarDepartamentoAsync(Departamento departamento)
        {
            _context.Departamento.Update(departamento);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarDepartamentoAsync(int id)
        {
            var departamento = await ObtenerDepartamentoPorIdAsync(id);
            if (departamento != null)
            {
                _context.Departamento.Remove(departamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarDepartamentoAsync(int id)
        {
            var departamento = await ObtenerDepartamentoPorIdAsync(id);
            if (departamento != null)
            {
                departamento.Activo = true;
                _context.Departamento.Update(departamento);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarDepartamentoAsync(int id)
        {
            var departamento = await ObtenerDepartamentoPorIdAsync(id);
            if (departamento != null)
            {
                departamento.Activo = false;
                _context.Departamento.Update(departamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}