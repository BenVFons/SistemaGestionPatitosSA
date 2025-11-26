using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Correo_Electronico")]
    public class Correo_Electronico
    {
        [Key] public string Correo { get; set; }
        [Required] public bool Activo { get; set; }
        [Required] public int Catalogo_TipoCorreo_idCatalogo_TipoCorreo { get; set; }
        [Required] public int Persona_CedulaPersona { get; set; }
    }

}
