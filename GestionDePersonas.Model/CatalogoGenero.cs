using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDePersonas.Model
{
    [Table("CatalogoGenero")]
    public class CatalogoGenero
    {
        [Key] public int idCatalogoGenero {  get; set; }
        [Required] public string Descripcion { get; set; }
        [Required] public bool Activo { get; set; }
    }
}
