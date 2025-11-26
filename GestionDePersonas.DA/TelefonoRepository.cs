using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface ITelefonoRepository
    {
        Task<Telefono?> ObtenerTelefonoPorIdAsync(int id);
        Task<IEnumerable<Telefono>> ObtenerTelefonoAsync();
        Task AgregarTelefonoAsync(Telefono telefono);
        Task ActualizarTelefonoAsync(Telefono telefono);
        Task EliminarTelefonoAsync(int id);
        Task ActivarTelefonoAsync(int id);
        Task DesActivarTelefonoAsync(int id);
    }

    public class TelefonoRepository : ITelefonoRepository
    {
        private readonly DBContexto _context;

        public TelefonoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Telefono?> ObtenerTelefonoPorIdAsync(int id)
        {
            return await _context.Telefono.FirstOrDefaultAsync(p => p.idTelefono == id);
        }

        public async Task<IEnumerable<Telefono>> ObtenerTelefonoAsync()
        {
            return await _context.Telefono.ToListAsync();
        }

        public async Task AgregarTelefonoAsync(Telefono telefono)
        {
            await _context.Telefono.AddAsync(telefono); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTelefonoAsync(Telefono telefono)
        {
            _context.Telefono.Update(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTelefonoAsync(int id)
        {
            var telefono = await ObtenerTelefonoPorIdAsync(id);
            if (telefono != null)
            {
                _context.Telefono.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarTelefonoAsync(int id)
        {
            var telefono = await ObtenerTelefonoPorIdAsync(id);
            if (telefono != null)
            {
                telefono.Activo = true;
                _context.Telefono.Update(telefono);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarTelefonoAsync(int id)
        {
            var telefono = await ObtenerTelefonoPorIdAsync(id);
            if (telefono != null)
            {
                telefono.Activo = false;
                _context.Telefono.Update(telefono);
                await _context.SaveChangesAsync();
            }
        }
    }
}