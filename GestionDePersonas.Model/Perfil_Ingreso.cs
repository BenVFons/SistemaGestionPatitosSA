using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Perfil_Ingreso")]
    public class Perfil_Ingreso
    {
        [Key] public int idPerfil_Ingreso { get; set; }
        [Required] public string Nombre_Perfill { get; set; }
        [Required] public bool Activo { get; set; }
    }

}
