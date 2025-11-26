using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Empleado")]
    public class Empleado
    {
        [Key] public int idEmpleado { get; set; }
        [Required] public bool Activo { get; set; }
        [Required] public DateOnly Fecha_Ingreso { get; set; }
        [Required] public int Persona_CedulaPersona { get; set; }
        [Required] public int Horario_idHorario { get; set; }
        [Required] public int Puesto_idPuesto { get; set; }
    }

}
