using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IDetalle_EvaluacionRepository
    {
        Task<Detalle_Evaluacion?> ObtenerDetalle_EvaluacionPorIdAsync(int id);
        Task<IEnumerable<Detalle_Evaluacion>> ObtenerDetalle_EvaluacionAsync();
        Task AgregarDetalle_EvaluacionAsync(Detalle_Evaluacion detailEval);
        Task ActualizarDetalle_EvaluacionAsync(Detalle_Evaluacion detailEval);
        Task EliminarDetalle_EvaluacionAsync(int id);
    }

    public class Detalle_EvaluacionRepository : IDetalle_EvaluacionRepository
    {
        private readonly DBContexto _context;

        public Detalle_EvaluacionRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Detalle_Evaluacion?> ObtenerDetalle_EvaluacionPorIdAsync(int id)
        {
            return await _context.Detalle_Evaluacion.FirstOrDefaultAsync(p => p.idDetalle_Evaluacion == id);
        }

        public async Task<IEnumerable<Detalle_Evaluacion>> ObtenerDetalle_EvaluacionAsync()
        {
            return await _context.Detalle_Evaluacion.ToListAsync();
        }

        public async Task AgregarDetalle_EvaluacionAsync(Detalle_Evaluacion detailEval)
        {
            await _context.Detalle_Evaluacion.AddAsync(detailEval); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarDetalle_EvaluacionAsync(Detalle_Evaluacion detailEval)
        {
            _context.Detalle_Evaluacion.Update(detailEval);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarDetalle_EvaluacionAsync(int id)
        {
            var detailEval = await ObtenerDetalle_EvaluacionPorIdAsync(id);
            if (detailEval != null)
            {
                _context.Detalle_Evaluacion.Remove(detailEval);
                await _context.SaveChangesAsync();
            }
        }
    }
}