using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IAsistenciaRepository
    {
        Task<Asistencia?> ObtenerAsistenciaPorIdAsync(int id);
        Task<IEnumerable<Asistencia>> ObtenerAsistenciaAsync();
        Task AgregarAsistenciaAsync(Asistencia asistencia);
        Task ActualizarAsistenciaAsync(Asistencia asistencia);
        Task EliminarAsistenciaAsync(int id);
    }

    public class AsistenciaRepository : IAsistenciaRepository
    {
        private readonly DBContexto _context;

        public AsistenciaRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Asistencia?> ObtenerAsistenciaPorIdAsync(int id)
        {
            return await _context.Asistencia.FirstOrDefaultAsync(p => p.idAsistencia == id);
        }

        public async Task<IEnumerable<Asistencia>> ObtenerAsistenciaAsync()
        {
            return await _context.Asistencia.ToListAsync();
        }

        public async Task AgregarAsistenciaAsync(Asistencia asistencia)
        {
            await _context.Asistencia.AddAsync(asistencia); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsistenciaAsync(Asistencia asistencia)
        {
            _context.Asistencia.Update(asistencia);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsistenciaAsync(int id)
        {
            var asistencia = await ObtenerAsistenciaPorIdAsync(id);
            if (asistencia != null)
            {
                _context.Asistencia.Remove(asistencia);
                await _context.SaveChangesAsync();
            }
        }
    }
}