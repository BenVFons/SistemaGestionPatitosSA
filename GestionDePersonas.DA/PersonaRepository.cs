using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IPersonaRepository
    {
        Task<Persona?> ObtenerPersonaPorIdAsync(int id);
        Task<IEnumerable<Persona>> ObtenerPersonaAsync();
        Task AgregarPersonaAsync(Persona persona);
        Task ActualizarPersonaAsync(Persona persona);
        Task EliminarPersonaAsync(int id);
    }

    public class PersonaRepository : IPersonaRepository
    {
        private readonly DBContexto _context;

        public PersonaRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Persona?> ObtenerPersonaPorIdAsync(int id)
        {
            return await _context.Persona.FirstOrDefaultAsync(p => p.CedulaPersona == id);
        }

        public async Task<IEnumerable<Persona>> ObtenerPersonaAsync()
        {
            return await _context.Persona.ToListAsync();
        }

        public async Task AgregarPersonaAsync(Persona persona)
        {
            await _context.Persona.AddAsync(persona); //Empleado es Tabla Empleado
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPersonaAsync(Persona persona)
        {
            _context.Persona.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPersonaAsync(int id)
        {
            var persona = await ObtenerPersonaPorIdAsync(id);
            if (persona != null)
            {
                _context.Persona.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }
    }
}