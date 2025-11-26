using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Asistencia")]
    public class Asistencia
    {
        [Key] public int idAsistencia { get; set; }
        [Required] public DateTime Hora_Ingreso { get; set; }
        [Required] public DateTime Hora_Salida { get; set; }
        [Required] public int Empleado_idEmpleado { get; set; }
        [Required] public int Tipo_Marca_idTipo_Marca { get; set; }
    }

}
