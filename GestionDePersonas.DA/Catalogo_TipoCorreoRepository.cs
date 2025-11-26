using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface ICatalogo_TipoCorreoRepository
    {
        Task<Catalogo_TipoCorreo?> ObtenerTipoCorreoPorIdAsync(int id);
        Task<IEnumerable<Catalogo_TipoCorreo>> ObtenerTipoCorreoAsync();
        Task AgregarTipoCorreoAsync(Catalogo_TipoCorreo correo);
        Task ActualizarTipoCorreoAsync(Catalogo_TipoCorreo correo);
        Task EliminarTipoCorreoAsync(int id);
        Task ActivarTipoCorreoAsync(int id);
        Task DesActivarTipoCorreoAsync(int id);
    }

    public class Catalogo_TipoCorreoRepository : ICatalogo_TipoCorreoRepository
    {
        private readonly DBContexto _context;

        public Catalogo_TipoCorreoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Catalogo_TipoCorreo?> ObtenerTipoCorreoPorIdAsync(int id)
        {
            return await _context.Catalogo_TipoCorreo.FirstOrDefaultAsync(p => p.idCatalogo_TipoCorreo == id);
        }

        public async Task<IEnumerable<Catalogo_TipoCorreo>> ObtenerTipoCorreoAsync()
        {
            return await _context.Catalogo_TipoCorreo.ToListAsync();
        }

        public async Task AgregarTipoCorreoAsync(Catalogo_TipoCorreo correo)
        {
            await _context.Catalogo_TipoCorreo.AddAsync(correo);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTipoCorreoAsync(Catalogo_TipoCorreo correo)
        {
            _context.Catalogo_TipoCorreo.Update(correo);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTipoCorreoAsync(int id)
        {
            var correo = await ObtenerTipoCorreoPorIdAsync(id);
            if (correo != null)
            {
                _context.Catalogo_TipoCorreo.Remove(correo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarTipoCorreoAsync(int id)
        {
            var correo = await ObtenerTipoCorreoPorIdAsync(id);
            if (correo != null)
            {
                correo.Activo = true;
                _context.Catalogo_TipoCorreo.Update(correo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarTipoCorreoAsync(int id)
        {
            var correo = await ObtenerTipoCorreoPorIdAsync(id);
            if (correo != null)
            {
                correo.Activo = false;
                _context.Catalogo_TipoCorreo.Update(correo);
                await _context.SaveChangesAsync();
            }
        }
    }
}