using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Telefono")]
    public class Telefono
    {
        [Key] public int idTelefono { get; set; }
        [Required] public bool Activo { get; set; }
        [Required] public int Catalogo_TipoTelefono_idCatalogo_TipoTelefono { get; set; }
        [Required] public int Persona_CedulaPersona { get; set; }
    }

}
