using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IPuestoRepository
    {
        Task<Puesto?> ObtenerPuestoPorIdAsync(int id);
        Task<IEnumerable<Puesto>> ObtenerPuestoAsync();
        Task AgregarPuestoAsync(Puesto puesto);
        Task ActualizarPuestoAsync(Puesto puesto);
        Task EliminarPuestoAsync(int id);
        Task ActivarPuestoAsync(int id);
        Task DesActivarPuestoAsync(int id);
    }

    public class PuestoRepository : IPuestoRepository
    {
        private readonly DBContexto _context;

        public PuestoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Puesto?> ObtenerPuestoPorIdAsync(int id)
        {
            return await _context.Puesto.FirstOrDefaultAsync(p => p.idPuesto == id);
        }

        public async Task<IEnumerable<Puesto>> ObtenerPuestoAsync()
        {
            return await _context.Puesto.ToListAsync();
        }

        public async Task AgregarPuestoAsync(Puesto puesto)
        {
            await _context.Puesto.AddAsync(puesto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPuestoAsync(Puesto puesto)
        {
            _context.Puesto.Update(puesto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPuestoAsync(int id)
        {
            var puesto = await ObtenerPuestoPorIdAsync(id);
            if (puesto != null)
            {
                _context.Puesto.Remove(puesto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarPuestoAsync(int id)
        {
            var puesto = await ObtenerPuestoPorIdAsync(id);
            if (puesto != null)
            {
                puesto.Activo = true;
                _context.Puesto.Update(puesto);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarPuestoAsync(int id)
        {
            var puesto = await ObtenerPuestoPorIdAsync(id);
            if (puesto != null)
            {
                puesto.Activo = false;
                _context.Puesto.Update(puesto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
