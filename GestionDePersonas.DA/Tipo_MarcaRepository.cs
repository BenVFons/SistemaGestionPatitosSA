using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface ITipo_MarcaRepository
    {
        Task<Tipo_Marca?> ObtenerTipo_MarcaPorIdAsync(int id);
        Task<IEnumerable<Tipo_Marca>> ObtenerTipo_MarcaAsync();
        Task AgregarTipo_MarcaAsync(Tipo_Marca marca);
        Task ActualizarTipo_MarcaAsync(Tipo_Marca marca);
        Task EliminarTipo_MarcaAsync(int id);
        Task ActivarTipo_MarcaAsync(int id);
        Task DesActivarTipo_MarcaAsync(int id);
    }

    public class Tipo_MarcaRepository : ITipo_MarcaRepository
    {
        private readonly DBContexto _context;

        public Tipo_MarcaRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Tipo_Marca?> ObtenerTipo_MarcaPorIdAsync(int id)
        {
            return await _context.Tipo_Marca.FirstOrDefaultAsync(p => p.idTipo_Marca == id);
        }

        public async Task<IEnumerable<Tipo_Marca>> ObtenerTipo_MarcaAsync()
        {
            return await _context.Tipo_Marca.ToListAsync();
        }

        public async Task AgregarTipo_MarcaAsync(Tipo_Marca marca)
        {
            await _context.Tipo_Marca.AddAsync(marca); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarTipo_MarcaAsync(Tipo_Marca marca)
        {
            _context.Tipo_Marca.Update(marca);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarTipo_MarcaAsync(int id)
        {
            var marca = await ObtenerTipo_MarcaPorIdAsync(id);
            if (marca != null)
            {
                _context.Tipo_Marca.Remove(marca);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarTipo_MarcaAsync(int id)
        {
            var marca = await ObtenerTipo_MarcaPorIdAsync(id);
            if (marca != null)
            {
                marca.Activo = true;
                _context.Tipo_Marca.Update(marca);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarTipo_MarcaAsync(int id)
        {
            var marca = await ObtenerTipo_MarcaPorIdAsync(id);
            if (marca != null)
            {
                marca.Activo = false;
                _context.Tipo_Marca.Update(marca);
                await _context.SaveChangesAsync();
            }
        }
    }
}
