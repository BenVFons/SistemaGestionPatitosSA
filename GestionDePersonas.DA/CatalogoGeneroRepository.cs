using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface ICatalogoGeneroRepository
    {
        Task<CatalogoGenero?> ObtenerCatalogoGeneroPorIdAsync(int id);
        Task<IEnumerable<CatalogoGenero>> ObtenerCatalogoGeneroAsync();
        Task AgregarCatalogoGeneroAsync(CatalogoGenero genero);
        Task ActualizarCatalogoGeneroAsync(CatalogoGenero genero);
        Task EliminarCatalogoGeneroAsync(int id);
        Task ActivarCatalogoGeneroAsync(int id);
        Task DesActivarCatalogoGeneroAsync(int id);
    }

    public class CatalogoGeneroRepository : ICatalogoGeneroRepository
    {
        private readonly DBContexto _context;

        public CatalogoGeneroRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<CatalogoGenero?> ObtenerCatalogoGeneroPorIdAsync(int id)
        {
            return await _context.CatalogoGenero.FirstOrDefaultAsync(p => p.idCatalogoGenero == id);
        }

        public async Task<IEnumerable<CatalogoGenero>> ObtenerCatalogoGeneroAsync()
        {
            return await _context.CatalogoGenero.ToListAsync();
        }

        public async Task AgregarCatalogoGeneroAsync(CatalogoGenero genero)
        {
            await _context.CatalogoGenero.AddAsync(genero);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarCatalogoGeneroAsync(CatalogoGenero genero)
        {
            _context.CatalogoGenero.Update(genero);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarCatalogoGeneroAsync(int id)
        {
            var genero = await ObtenerCatalogoGeneroPorIdAsync(id);
            if (genero != null)
            {
                _context.CatalogoGenero.Remove(genero);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarCatalogoGeneroAsync(int id)
        {
            var genero = await ObtenerCatalogoGeneroPorIdAsync(id);
            if (genero != null)
            {
                genero.Activo = true;
                _context.CatalogoGenero.Update(genero);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarCatalogoGeneroAsync(int id)
        {
            var genero = await ObtenerCatalogoGeneroPorIdAsync(id);
            if (genero != null)
            {
                genero.Activo = false;
                _context.CatalogoGenero.Update(genero);
                await _context.SaveChangesAsync();
            }
        }
    }
}
