using GestionDePersonas.Model;
using GestionDePersonas.DA;
using Microsoft.EntityFrameworkCore;

namespace GestionDePersonas.BL
{
    public class AdministradorDeEmpleados : IAdministradorDeEmpleados
    {
        //private readonly DBContexto _context;
        private readonly ICrearEmpleadoRepository _empleadoRepo;
        private readonly IEmpleadoRepository _empleadoRepository;
        

        public AdministradorDeEmpleados(ICrearEmpleadoRepository empleadoRepository, /*DBContexto context*/
                                        IEmpleadoRepository EmplRepo)
        {
            _empleadoRepo = empleadoRepository;
            //_context = context;
            _empleadoRepository = EmplRepo;
        }

        public async Task<IEnumerable<Empleado>> ObtengaListaEmpleadosAsync()
        {
            return await _empleadoRepo.ObtenerEmpleadoAsync();
        }
        public async Task<Empleado?> ObtengaAlEmpleadoaAsync(int id)
        {
            return await _empleadoRepository.ObtenerEmpleadoPorIdAsync(id);
        }
        public async Task<IEnumerable<Empleado>> EmpleadoOrdenadoxHorario() //EOH = EmpleadoOrdenadoxHorario
        {
            return await _empleadoRepo.EmpleadoOrdenadoxHorario();
        }
        public async Task<IEnumerable<Empleado>> EmpleadoOrdenadoxPuesto() //EOP = EmpleadoOrdenadoxHorario
        {
            return await _empleadoRepo.EmpleadoOrdenadoxPuesto();
        }
        public async Task<IEnumerable<Empleado>> EmpleadoOrdenadoxFechaIngreso() //EOFI = EmpleadoOrdenadoFechaIngreso
        {
            return await _empleadoRepo.EmpleadoOrdenadoxFechaIngreso();
        }
        public async Task<IEnumerable<msjResp>> AgregarEmpleadoSP(CrearEmpleado empleado, string Gestion)
        {
            //PERSONA
            if (empleado.CedulaPersona <= 0 || empleado.CedulaPersona < 10)
            {
                var Mensaje = new msjResp { id = -3, Mensaje = "La cédula no puede ser 0 ni tener más de 9 digitos." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (String.IsNullOrEmpty(empleado.Nombre))
            {
                var Mensaje = new msjResp { id = -4, Mensaje = "El Nombre del empleado no puede ser blanco." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (String.IsNullOrEmpty(empleado.Apellido1))
            {
                var Mensaje = new msjResp { id = -5, Mensaje = "El Primer Apellido del empleado no puede ser blanco." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (String.IsNullOrEmpty(empleado.Apellido2))
            {
                var Mensaje = new msjResp { id = -6, Mensaje = "El Segundo Apellido del empleado no puede ser blanco." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.FechaNacimiento == null)
            {
                var Mensaje = new msjResp { id = -7, Mensaje = "La Fecha de Nacimiento del empleado no puede ser vacia." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.IdGenero <= 0)
            {
                var Mensaje = new msjResp { id = -8, Mensaje = "El genero del empleado no puede ser menor a 0." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            //Telefono
            if (empleado.Telefono <= 0 || empleado.Telefono < 9)
            {
                var Mensaje = new msjResp { id = -9, Mensaje = "El numero del empleado no puede ser 0 ni tener más de 8 digitos." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.activoTel != true && empleado.activoTel != false)
            {
                var Mensaje = new msjResp { id = -10, Mensaje = "El valor de activoTel debe ser Activo o InActivo." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.IdTipoTel <= 0)
            {
                var Mensaje = new msjResp { id = -11, Mensaje = "El tipo del telefono del empleado no puede ser 0." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            //Correo
            if (String.IsNullOrEmpty(empleado.Correo))
            {
                var Mensaje = new msjResp { id = -12, Mensaje = "El correo del empleado no puede ser blanco." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.activoCor != true && empleado.activoCor != false)
            {
                var Mensaje = new msjResp { id = -13, Mensaje = "El valor de activoCor debe ser Activo o InActivo." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.IdTipoCorr < 0)
            {
                var Mensaje = new msjResp { id = -14, Mensaje = "El tipo del correo del empleado no puede ser 0." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            //Empleado
            if (empleado.IdHorario < 0)
            {
                var Mensaje = new msjResp { id = -15, Mensaje = "El horario del empleado no puede ser 0." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.IdPuesto < 0)
            {
                var Mensaje = new msjResp { id = -16, Mensaje = "El puesto del empleado no puede ser 0." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.activoEmpl != true && empleado.activoEmpl != false)
            {
                var Mensaje = new msjResp { id = -17, Mensaje = "El valor de activoEmpl debe ser Activo o InActivo." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.Fecha_Ingreso == null)
            {
                var Mensaje = new msjResp { id = -18, Mensaje = "La fecha de ingreso del empleado no puede ser vacia." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            //Usuario
            if (String.IsNullOrEmpty(empleado.Usuario))
            {
                var Mensaje = new msjResp { id = -19, Mensaje = "El Nombre de Usuario del empleado no puede ser blanco." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (String.IsNullOrEmpty(empleado.Contraseña))
            {
                var Mensaje = new msjResp { id = -20, Mensaje = "La Contraseña del empleado no puede ser blanco." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.Bloqueado != true && empleado.Bloqueado != false)
            {
                var Mensaje = new msjResp { id = -21, Mensaje = "El valor de activoEmpl debe ser Activo o InActivo." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.Primer_Ingreso != true && empleado.Primer_Ingreso != false)
            {
                var Mensaje = new msjResp { id = -22, Mensaje = "El valor de activoEmpl debe ser Activo o InActivo." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            if (empleado.IdPerfil < 0)
            {
                var Mensaje = new msjResp { id = -23, Mensaje = "El tipo del correo del empleado no puede ser 0." };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            //Gestion
            if (Gestion == "M" && (empleado.IdEmple == null || empleado.IdEmple <= 0))
            {
                var Mensaje = new msjResp { id = -24, Mensaje = "ID debe ser positivo" };
                var Mensajes = new List<msjResp>();
                Mensajes.Add(Mensaje);
                return Mensajes;
            }
            return Gestion == "N" ? await _empleadoRepo.AgregarEmpleadoSP(empleado) : await _empleadoRepo.ActualizarEmpleadoSP(empleado);
        }
        public async Task<String> ActualizarEmpleadoAsync(int id, Empleado empleado) //BL
        {
            var EmpleadoAMOdificar = await _empleadoRepo.ObtenerEmpleadoPorIdAsync(id);
            if (EmpleadoAMOdificar == null)
            {
                return $"El empleado con el id {id} no fue encontrado.";
            }
            EmpleadoAMOdificar.Fecha_Ingreso = empleado.Fecha_Ingreso;
            EmpleadoAMOdificar.Persona_CedulaPersona = empleado.Persona_CedulaPersona;
            EmpleadoAMOdificar.Horario_idHorario = empleado.Horario_idHorario;
            EmpleadoAMOdificar.Puesto_idPuesto = empleado.Puesto_idPuesto;
            await _empleadoRepo.ActualizarEmpleadoAsync(EmpleadoAMOdificar);
            return $"El empleado con el id  {id} fue actualizado con éxito.";
        }
        public async Task<String> EliminarEmpleadAsync(int id) //BL
        {
            var EmpleadoAEliminar = await _empleadoRepo.ObtenerEmpleadoPorIdAsync(id);
            if (EmpleadoAEliminar == null)
            {
                return $"El empleado con el id {id} no fue encontrado.";
            }

            await _empleadoRepo.EliminarEmpleadoAsync(id);
            return $"empleado con el id  {id} fue eliminado con éxito.";
        }
        public async Task ActiveEmpleadoAsync(int id)
        {
            await _empleadoRepo.ActivarEmpleadoAsync(id);
        }
        public async Task DesActiveEmpleadoAsync(int id)
        {
            await _empleadoRepo.DesActivarEmpleadoAsync(id);
        }
        public async Task<IEnumerable<Empleado>> ObtengaListaDeActivosAsync()
        {
            return await _empleadoRepo.ObtenerEmpleadoActivosAsync();
        }
        public async Task<IEnumerable<Empleado>> ObtengaListaDeInActivosAsync()
        {
            return await _empleadoRepo.ObtenerEmpleadoInActivosAsync();
        }
    }
}
