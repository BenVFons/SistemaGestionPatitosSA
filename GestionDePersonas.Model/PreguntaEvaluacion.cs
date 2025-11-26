using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("PreguntaEvaluacion")]
    public class PreguntaEvaluacion
    {
        [Key] public int idPreguntaEvaluacion { get; set; }
        [Required] public string Pregunta { get; set; }
        [Required] public bool Activo { get; set; }
    }

}
