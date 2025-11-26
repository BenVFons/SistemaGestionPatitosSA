using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface ICatalogo_TipoTelefonoRepository
    {
        Task<Catalogo_TipoTelefono?> ObtenerTipoTelefonoPorIdAsync(int id);
        Task<IEnumerable<Catalogo_TipoTelefono>> ObtenerTipoTelefonoAsync();
        Task AgregarTipoTelefonoAsync(Catalogo_TipoTelefono Telefono);
        Task ActualizarTipoTelefonoAsync(Catalogo_TipoTelefono Telefono);
        Task EliminarTipoTelefonoAsync(int id);
        Task ActivarTipoTelefonoAsync(int id);
        Task DesActivarTipoTelefonoAsync(int id);
    }

    public class Catalogo_TipoTelefonoRepository : ICatalogo_TipoTelefonoRepository
    {
        private readonly DBContexto _context;

        public Catalogo_TipoTelefonoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Catalogo_TipoTelefono?> ObtenerTipoTelefonoPorIdAsync(int id)
        {
            return await _context.Catalogo_TipoTelefono.FirstOrDefaultAsync(p => p.idCatalogo_TipoTelefono == id);
        }

        public async Task<IEnumerable<Catalogo_TipoTelefono>> ObtenerTipoTelefonoAsync()
        {
            return await _context.Catalogo_TipoTelefono.ToListAsync();
        }

        public async Task AgregarTipoTelefonoAsync(Catalogo_TipoTelefono telefono)
        {
            await _context.Catalogo_TipoTelefono.AddAsync(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTipoTelefonoAsync(Catalogo_TipoTelefono telefono)
        {
            _context.Catalogo_TipoTelefono.Update(telefono);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTipoTelefonoAsync(int id)
        {
            var telefono = await ObtenerTipoTelefonoPorIdAsync(id);
            if (telefono != null)
            {
                _context.Catalogo_TipoTelefono.Remove(telefono);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarTipoTelefonoAsync(int id)
        {
            var telefono = await ObtenerTipoTelefonoPorIdAsync(id);
            if (telefono != null)
            {
                telefono.Activo = true;
                _context.Catalogo_TipoTelefono.Update(telefono);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarTipoTelefonoAsync(int id)
        {
            var telefono = await ObtenerTipoTelefonoPorIdAsync(id);
            if (telefono != null)
            {
                telefono.Activo = false;
                _context.Catalogo_TipoTelefono.Update(telefono);
                await _context.SaveChangesAsync();
            }
        }
    }
}
