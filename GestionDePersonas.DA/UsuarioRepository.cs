using GestionDePersonas.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> ObtenerUsuarioPorUsernameAsync(string username);
        Task<IEnumerable<Usuario>> ObtenerUsuarioAsync();
        Task AgregarUsuarioAsync(Usuario username);
        Task ActualizarUsuarioAsync(Usuario username);
        Task EliminarUsuarioAsync(string usermane);
        Task ActivarUsuarioAsync(string usermane);
        Task DesActivarUsuarioAsync(string usermane);
        Task<bool> ValidarUsuarioAsync(string usuario, string password);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DBContexto _context;
        public UsuarioRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Usuario?> ObtenerUsuarioPorUsernameAsync(string usermane)
        {
            return await _context.Usuario.FirstOrDefaultAsync(p => p.NombreUsuario == usermane);
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarioAsync()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task AgregarUsuarioAsync(Usuario usermane)
        {
            await _context.Usuario.AddAsync(usermane); 
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarUsuarioAsync(Usuario usermane)
        {
            _context.Usuario.Update(usermane);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarUsuarioAsync(string usermane)
        {
            var usuario = await ObtenerUsuarioPorUsernameAsync(usermane);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ActivarUsuarioAsync(string usermane)
        {
            var usuario = await ObtenerUsuarioPorUsernameAsync(usermane);
            if (usuario != null)
            {
                usuario.Bloqueado = true;
                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesActivarUsuarioAsync(string usermane)
        {
            var usuario = await ObtenerUsuarioPorUsernameAsync(usermane);
            if (usuario != null)
            {
                usuario.Bloqueado = false;
                _context.Usuario.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ValidarUsuarioAsync(string usuario, string password)
        {
            return await _context.Usuario
            .AnyAsync(u => u.NombreUsuario == usuario && u.Contraseña == password);
            //using (SqlConnection cn = new SqlConnection(_conexion))
            //{
            //    string query = @"SELECT COUNT(*) 
            //                 FROM Usuario 
            //                 WHERE NombreUsuario = @user 
            //                       AND Contraseña = @pass";

            //    SqlCommand cmd = new SqlCommand(query, cn);
            //    cmd.Parameters.AddWithValue("@user", usuario);
            //    cmd.Parameters.AddWithValue("@pass", password);

            //    await cn.OpenAsync();
            //    int result = (int)await cmd.ExecuteScalarAsync();

            //    return result > 0;
            //}
        }


    }
}