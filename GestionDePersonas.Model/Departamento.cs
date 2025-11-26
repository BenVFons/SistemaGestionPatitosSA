using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key] public int idDepartamento { get; set; }
        [Required] public string Nombre_Departamento { get; set; }
        [Required] public bool Activo { get; set; }
    }

}
