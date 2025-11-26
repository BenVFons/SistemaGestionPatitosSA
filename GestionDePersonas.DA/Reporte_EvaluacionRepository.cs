using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IReporte_EvaluacionRepository
    {
        Task<Reporte_Evaluacion?> ObtenerReporte_EvaluacionPorIdAsync(int id);
        Task<IEnumerable<Reporte_Evaluacion>> ObtenerReporte_EvaluacionAsync();
        Task AgregarReporte_EvaluacionAsync(Reporte_Evaluacion reporte);
        Task ActualizarReporte_EvaluacionAsync(Reporte_Evaluacion reporte);
        Task EliminarReporte_EvaluacionAsync(int id);
    }

    public class Reporte_EvaluacionRepository : IReporte_EvaluacionRepository
    {
        private readonly DBContexto _context;

        public Reporte_EvaluacionRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Reporte_Evaluacion?> ObtenerReporte_EvaluacionPorIdAsync(int id)
        {
            return await _context.Reporte_Evaluacion.FirstOrDefaultAsync(p => p.idReporte_Evaluacion == id);
        }

        public async Task<IEnumerable<Reporte_Evaluacion>> ObtenerReporte_EvaluacionAsync()
        {
            return await _context.Reporte_Evaluacion.ToListAsync();
        }

        public async Task AgregarReporte_EvaluacionAsync(Reporte_Evaluacion reporte)
        {
            await _context.Reporte_Evaluacion.AddAsync(reporte);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarReporte_EvaluacionAsync(Reporte_Evaluacion reporte)
        {
            _context.Reporte_Evaluacion.Update(reporte);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarReporte_EvaluacionAsync(int id)
        {
            var reporte = await ObtenerReporte_EvaluacionPorIdAsync(id);
            if (reporte != null)
            {
                _context.Reporte_Evaluacion.Remove(reporte);
                await _context.SaveChangesAsync();
            }
        }
    }
}
