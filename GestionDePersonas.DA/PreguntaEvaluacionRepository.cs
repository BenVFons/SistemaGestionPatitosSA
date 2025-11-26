using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IPreguntaEvaluacionRepository
    {
        Task<PreguntaEvaluacion?> ObtenerPreguntaEvaluacionPorIdAsync(int id);
        Task<IEnumerable<PreguntaEvaluacion>> ObtenerPreguntaEvaluacionAsync();
        Task AgregarPreguntaEvaluacionAsync(PreguntaEvaluacion pregunta);
        Task ActualizarPreguntaEvaluacionAsync(PreguntaEvaluacion pregunta);
        Task EliminarPreguntaEvaluacionAsync(int id);
        Task ActivarPreguntaEvaluacionAsync(int id);
        Task DesActivarPreguntaEvaluacionAsync(int id);
    }

    public class PreguntaEvaluacionRepository : IPreguntaEvaluacionRepository
    {
        private readonly DBContexto _context;

        public PreguntaEvaluacionRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<PreguntaEvaluacion?> ObtenerPreguntaEvaluacionPorIdAsync(int id)
        {
            return await _context.PreguntaEvaluacion.FirstOrDefaultAsync(p => p.idPreguntaEvaluacion == id);
        }

        public async Task<IEnumerable<PreguntaEvaluacion>> ObtenerPreguntaEvaluacionAsync()
        {
            return await _context.PreguntaEvaluacion.ToListAsync();
        }

        public async Task AgregarPreguntaEvaluacionAsync(PreguntaEvaluacion pregunta)
        {
            await _context.PreguntaEvaluacion.AddAsync(pregunta); //Empleado es Tabla Empleado
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPreguntaEvaluacionAsync(PreguntaEvaluacion pregunta)
        {
            _context.PreguntaEvaluacion.Update(pregunta);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPreguntaEvaluacionAsync(int id)
        {
            var pregunta = await ObtenerPreguntaEvaluacionPorIdAsync(id);
            if (pregunta != null)
            {
                _context.PreguntaEvaluacion.Remove(pregunta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarPreguntaEvaluacionAsync(int id)
        {
            var pregunta = await ObtenerPreguntaEvaluacionPorIdAsync(id);
            if (pregunta != null)
            {
                pregunta.Activo = true;
                _context.PreguntaEvaluacion.Update(pregunta);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarPreguntaEvaluacionAsync(int id)
        {
            var pregunta = await ObtenerPreguntaEvaluacionPorIdAsync(id);
            if (pregunta != null)
            {
                pregunta.Activo = false;
                _context.PreguntaEvaluacion.Update(pregunta);
                await _context.SaveChangesAsync();
            }
        }
    }
}