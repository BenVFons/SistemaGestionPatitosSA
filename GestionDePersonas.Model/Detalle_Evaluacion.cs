using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Detalle_Evaluacion")]
    public class Detalle_Evaluacion
    {
        [Key] public int idDetalle_Evaluacion { get; set; }
        [Required] public int Calificacion { get; set; }
        [Required] public int Evaluacion_idEvaluacion { get; set; }
        [Required] public int PreguntaEvaluacion_idPreguntaEvaluacion { get; set; }
    }

}
