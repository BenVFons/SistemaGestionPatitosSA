using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Persona")]
    public class Persona
    {
        [Key] public int CedulaPersona { get; set; }
        [Required] public string Nombre { get; set; }
        [Required] public string Apellido1 { get; set; }
        [Required] public string Apellido2 { get; set; }
        [Required] public DateOnly Fecha_Nacimiento { get; set; }
        [Required] public int Catalago_Genero_idCatalago_Genero { get; set; }
    }
}
