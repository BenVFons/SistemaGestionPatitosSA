using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface ICorreo_ElectronicoRepository
    {
        Task<Correo_Electronico?> ObtenerCorreoPorCorreoAsync(string correo);
        Task<IEnumerable<Correo_Electronico>> ObtenerCorreoAsync();
        Task AgregarCorreoAsync(Correo_Electronico correo);
        Task ActualizarCorreoAsync(Correo_Electronico correo);
        Task EliminarCorreoAsync(string mail);
        Task ActivarCorreoAsync(string mail);
        Task DesActivarCorreoAsync(string mail);
    }

    public class Correo_ElectronicoRepository : ICorreo_ElectronicoRepository
    {
        private readonly DBContexto _context;

        public Correo_ElectronicoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Correo_Electronico?> ObtenerCorreoPorCorreoAsync(string correo)
        {
            return await _context.Correo_Electronico.FirstOrDefaultAsync(p => p.Correo == correo);
        }

        public async Task<IEnumerable<Correo_Electronico>> ObtenerCorreoAsync()
        {
            return await _context.Correo_Electronico.ToListAsync();
        }

        public async Task AgregarCorreoAsync(Correo_Electronico correo)
        {
            await _context.Correo_Electronico.AddAsync(correo); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarCorreoAsync(Correo_Electronico correo)
        {
            _context.Correo_Electronico.Update(correo);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarCorreoAsync(string mail)
        {
            var correo = await ObtenerCorreoPorCorreoAsync(mail);
            if (correo != null)
            {
                _context.Correo_Electronico.Remove(correo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarCorreoAsync(string mail)
        {
            var correo = await ObtenerCorreoPorCorreoAsync(mail);
            if (correo != null)
            {
                correo.Activo = true;
                _context.Correo_Electronico.Update(correo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarCorreoAsync(string mail)
        {
            var correo = await ObtenerCorreoPorCorreoAsync(mail);
            if (correo != null)
            {
                correo.Activo = false;
                _context.Correo_Electronico.Update(correo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
