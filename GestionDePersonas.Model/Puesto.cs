using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Puesto")]
    public class Puesto
    {
        [Key] public int idPuesto { get; set; }
        [Required] public int Departamento_idDepartamento { get; set; }
        [Required] public string Nombre_Puesto { get; set; }
        [Required] public bool Activo { get; set; }
        [Required] public decimal Salario_Puesto { get; set; }
    }

}
