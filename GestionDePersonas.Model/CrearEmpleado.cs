using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.Model
{
    public class CrearEmpleado
    {
        // Persona
        public int IdCed { get; set; }
        public int CedulaPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdGenero { get; set; }

        // Telefono
        public int idTel {  get; set; }
        public int Telefono { get; set; }
        public bool activoTel { get; set; }
        public int IdTipoTel { get; set; }

        // Correo
        public string IdCor { get; set; }
        public string Correo { get; set; }
        public bool activoCor { get; set; }
        public int IdTipoCorr { get; set; }

        // Empleado
        public int IdEmple { get; set; }
        public int IdHorario { get; set; }
        public int IdPuesto { get; set; }
        public bool activoEmpl { get; set; }
        public DateOnly Fecha_Ingreso { get; set; }

        // Usuario
        public string IdUser {  get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set;}
        public bool Bloqueado { get; set; }
        public bool Primer_Ingreso { get; set;}
        public int IdPerfil {  get; set; }

        // Acción
        //public string Gestion { get; set; }
    }
}



