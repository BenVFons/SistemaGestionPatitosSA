using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IHorarioRepository
    {
        Task<Horario?> ObtenerHorarioPorIdAsync(int id);
        Task<IEnumerable<Horario>> ObtenerHorarioAsync();
        Task AgregarHorarioAsync(Horario horario);
        Task ActualizarHorarioAsync(Horario horario);
        Task EliminarHorarioAsync(int id);
        Task ActivarHorarioAsync(int id);
        Task DesActivarHorarioAsync(int id);
    }

    public class HorarioRepository : IHorarioRepository
    {
        private readonly DBContexto _context;

        public HorarioRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Horario?> ObtenerHorarioPorIdAsync(int id)
        {
            return await _context.Horario.FirstOrDefaultAsync(p => p.idHorario == id);
        }

        public async Task<IEnumerable<Horario>> ObtenerHorarioAsync()
        {
            return await _context.Horario.ToListAsync();
        }

        public async Task AgregarHorarioAsync(Horario horario)
        {
            await _context.Horario.AddAsync(horario); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarHorarioAsync(Horario horario)
        {
            _context.Horario.Update(horario);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarHorarioAsync(int id)
        {
            var horario = await ObtenerHorarioPorIdAsync(id);
            if (horario != null)
            {
                _context.Horario.Remove(horario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarHorarioAsync(int id)
        {
            var horario = await ObtenerHorarioPorIdAsync(id);
            if (horario != null)
            {
                horario.Activo = true;
                _context.Horario.Update(horario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarHorarioAsync(int id)
        {
            var horario = await ObtenerHorarioPorIdAsync(id);
            if (horario != null)
            {
                horario.Activo = false;
                _context.Horario.Update(horario);
                await _context.SaveChangesAsync();
            }
        }
    }
}