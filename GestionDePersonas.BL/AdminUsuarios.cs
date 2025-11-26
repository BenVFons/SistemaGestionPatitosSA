using GestionDePersonas.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.BL
{
    public class AdminUsuarios : IAdminUsuarios
    {
        //private readonly DBContexto _context;
        private readonly IUsuarioRepository _userRepo;

        public AdminUsuarios(/*DBContexto context*/ IUsuarioRepository userRepo)
        {
            //_context = context;
            _userRepo = userRepo;
        }

        public async Task<bool> LoginAsync(string usuario, string password)
        {
            return await _userRepo.ValidarUsuarioAsync(usuario, password);
        }

    }
}
