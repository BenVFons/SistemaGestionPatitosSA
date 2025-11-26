using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    [Table("Catalogo_TipoTelefono")]
    public class Catalogo_TipoTelefono
    {
        [Key] public int idCatalogo_TipoTelefono {  get; set; }
        [Required] public string Descripcion { get; set; }
        [Required] public bool Activo { get; set; }
    }
}
