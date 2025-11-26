using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Evaluacion")]
    public class Evaluacion
    {
        [Key] public int idEvaluacion { get; set; }
        [Required] public DateTime Fecha_Evaluacion { get; set; }
        [Required] public int Empleado_idEmpleado { get; set; }
        [Required] public bool Activo { get; set; }
    }

}
