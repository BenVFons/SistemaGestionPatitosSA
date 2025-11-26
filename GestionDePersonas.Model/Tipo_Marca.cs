using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Tipo_Marca")]
    public class Tipo_Marca
    {
        [Key] public int idTipo_Marca { get; set; }
        [Required] public string Nombre_Marca { get; set; }
        [Required] public bool Activo { get; set; }
    }

}
