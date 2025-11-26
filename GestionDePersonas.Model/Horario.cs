using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Horario")]
    public class Horario
    {
        [Key] public int idHorario { get; set; }
        [Required] public TimeOnly Hora_inicio { get; set; }
        [Required] public TimeOnly Hora_fin { get; set; }
        [Required] public bool Activo { get; set; }
    }

}
