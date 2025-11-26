using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IPlanillaRepository
    {
        Task<Planilla?> ObtenerPlanillaPorIdAsync(int id);
        Task<IEnumerable<Planilla>> ObtenerPlanillaAsync();
        Task AgregarPlanillaAsync(Planilla planilla);
        Task ActualizarPlanillaAsync(Planilla planilla);
        Task EliminarPlanillaAsync(int id);
    }

    public class PlanillaRepository : IPlanillaRepository
    {
        private readonly DBContexto _context;

        public PlanillaRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Planilla?> ObtenerPlanillaPorIdAsync(int id)
        {
            return await _context.Planilla.FirstOrDefaultAsync(p => p.idPlanilla == id);
        }

        public async Task<IEnumerable<Planilla>> ObtenerPlanillaAsync()
        {
            return await _context.Planilla.ToListAsync();
        }

        public async Task AgregarPlanillaAsync(Planilla planilla)
        {
            await _context.Planilla.AddAsync(planilla); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPlanillaAsync(Planilla planilla)
        {
            _context.Planilla.Update(planilla);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPlanillaAsync(int id)
        {
            var planilla = await ObtenerPlanillaPorIdAsync(id);
            if (planilla != null)
            {
                _context.Planilla.Remove(planilla);
                await _context.SaveChangesAsync();
            }
        }
    }
}
