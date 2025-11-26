using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Reporte_Evaluacion")]
    public class Reporte_Evaluacion
    {
        [Key] public int idReporte_Evaluacion { get; set; }
        [Required] public int Empleado_idEmpleado { get; set; }
        [Required] public int Evaluacion_idEvaluacion { get; set; }
    }

}
