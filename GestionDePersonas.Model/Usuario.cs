using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key] public string NombreUsuario { get; set; }
        [Required] public int Empleado_idEmpleado { get; set; }
        [Required] public string Contraseña { get; set; }
        [Required] public bool Bloqueado { get; set; }
        [Required] public bool Primer_Ingreso { get; set; }
        [Required] public int Perfil_Ingreso_idPerfil_Ingreso { get; set; }
    }

}
