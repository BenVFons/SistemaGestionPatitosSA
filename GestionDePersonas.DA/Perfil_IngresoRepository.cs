using GestionDePersonas.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IPerfil_IngresoRepository
    {
        Task<Perfil_Ingreso?> ObtenerPerfil_IngresoPorIdAsync(int id);
        Task<IEnumerable<Perfil_Ingreso>> ObtenerPerfil_IngresoAsync();
        Task AgregarPerfil_IngresoAsync(Perfil_Ingreso perfilIngreso);
        Task ActualizarPerfil_IngresoAsync(Perfil_Ingreso perfilIngreso);
        Task EliminarPerfil_IngresoAsync(int id);
        Task ActivarPerfil_IngresoAsync(int id);
        Task DesActivarPerfil_IngresoAsync(int id);
    }

    public class Perfil_IngresoRepository : IPerfil_IngresoRepository
    {
        private readonly DBContexto _context;

        public Perfil_IngresoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Perfil_Ingreso?> ObtenerPerfil_IngresoPorIdAsync(int id)
        {
            return await _context.Perfil_Ingreso.FirstOrDefaultAsync(p => p.idPerfil_Ingreso == id);
        }

        public async Task<IEnumerable<Perfil_Ingreso>> ObtenerPerfil_IngresoAsync()
        {
            return await _context.Perfil_Ingreso.ToListAsync();
        }

        public async Task AgregarPerfil_IngresoAsync(Perfil_Ingreso perfilIngreso)
        {
            await _context.Perfil_Ingreso.AddAsync(perfilIngreso); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarPerfil_IngresoAsync(Perfil_Ingreso perfilIngreso)
        {
            _context.Perfil_Ingreso.Update(perfilIngreso);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarPerfil_IngresoAsync(int id)
        {
            var perfilIngreso = await ObtenerPerfil_IngresoPorIdAsync(id);
            if (perfilIngreso != null)
            {
                _context.Perfil_Ingreso.Remove(perfilIngreso);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarPerfil_IngresoAsync(int id)
        {
            var perfilIngreso = await ObtenerPerfil_IngresoPorIdAsync(id);
            if (perfilIngreso != null)
            {
                perfilIngreso.Activo = true;
                _context.Perfil_Ingreso.Update(perfilIngreso);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarPerfil_IngresoAsync(int id)
        {
            var perfilIngreso = await ObtenerPerfil_IngresoPorIdAsync(id);
            if (perfilIngreso != null)
            {
                perfilIngreso.Activo = false;
                _context.Perfil_Ingreso.Update(perfilIngreso);
                await _context.SaveChangesAsync();
            }
        }
    }
}
