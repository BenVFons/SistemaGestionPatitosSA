using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Planilla")]
    public class Planilla
    {
        [Key] public int idPlanilla { get; set; }
        [Required] public int Empleado_idEmpleado { get; set; }
        [Required] public DateTime Fecha_Generada { get; set; }
        [Required] public decimal Pago_CCSS { get; set; }
        [Required] public decimal Exoneraciones { get; set; }
        [Required] public decimal Deducciones { get; set; }
        [Required] public decimal Salario_Neto { get; set; }
    }

}
