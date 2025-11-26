using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IEvaluacionRepository
    {
        Task<Evaluacion?> ObtenerEvaluacionPorIdAsync(int id);
        Task<IEnumerable<Evaluacion>> ObtenerEvaluacionAsync();
        Task AgregarEvaluacionAsync(Evaluacion evaluacion);
        Task ActualizarEvaluacionAsync(Evaluacion evaluacion);
        Task EliminarEvaluacionAsync(int id);
        Task ActivarEvaluacionAsync(int id);
        Task DesActivarEvaluacionAsync(int id);
    }

    public class EvaluacionRepository : IEvaluacionRepository
    {
        private readonly DBContexto _context;

        public EvaluacionRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Evaluacion?> ObtenerEvaluacionPorIdAsync(int id)
        {
            return await _context.Evaluacion.FirstOrDefaultAsync(p => p.idEvaluacion == id);
        }

        public async Task<IEnumerable<Evaluacion>> ObtenerEvaluacionAsync()
        {
            return await _context.Evaluacion.ToListAsync();
        }

        public async Task AgregarEvaluacionAsync(Evaluacion evaluacion)
        {
            await _context.Evaluacion.AddAsync(evaluacion); //Empleado es Tabla Empleado
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarEvaluacionAsync(Evaluacion evaluacion)
        {
            _context.Evaluacion.Update(evaluacion);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarEvaluacionAsync(int id)
        {
            var evaluacion = await ObtenerEvaluacionPorIdAsync(id);
            if (evaluacion != null)
            {
                _context.Evaluacion.Remove(evaluacion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarEvaluacionAsync(int id)
        {
            var evaluacion = await ObtenerEvaluacionPorIdAsync(id);
            if (evaluacion != null)
            {
                evaluacion.Activo = true;
                _context.Evaluacion.Update(evaluacion);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarEvaluacionAsync(int id)
        {
            var evaluacion = await ObtenerEvaluacionPorIdAsync(id);
            if (evaluacion != null)
            {
                evaluacion.Activo = false;
                _context.Evaluacion.Update(evaluacion);
                await _context.SaveChangesAsync();
            }
        }
    }
}
