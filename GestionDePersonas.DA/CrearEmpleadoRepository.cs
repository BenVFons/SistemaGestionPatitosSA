using GestionDePersonas.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Collections.Specialized.BitVector32;


namespace GestionDePersonas.DA
{
    public interface ICrearEmpleadoRepository
    {
        Task<Empleado?> ObtenerEmpleadoPorIdAsync(int id);
        Task<IEnumerable<Empleado>> ObtenerEmpleadoAsync();
        Task<IEnumerable<msjResp>> AgregarEmpleadoSP(CrearEmpleado empleado);
        Task<IEnumerable<msjResp>> ActualizarEmpleadoSP(CrearEmpleado empleado);
        Task EliminarEmpleadoAsync(int id);
        Task ActualizarEmpleadoAsync(Empleado empleado);
        Task ActivarEmpleadoAsync(int id);
        Task DesActivarEmpleadoAsync(int id);
        Task<IEnumerable<Empleado>> ObtenerEmpleadoActivosAsync();
        Task<IEnumerable<Empleado>> ObtenerEmpleadoInActivosAsync();
        Task<IEnumerable<Empleado>> EmpleadoOrdenadoxFechaIngreso();
        Task<IEnumerable<Empleado>> EmpleadoOrdenadoxHorario();
        Task<IEnumerable<Empleado>> EmpleadoOrdenadoxPuesto();
    }

    public class CrearEmpleadoRepository : ICrearEmpleadoRepository
    {
        private readonly DBContexto _context;

        public CrearEmpleadoRepository(DBContexto context)
        {
            _context = context;
        }

        public async Task<Empleado?> ObtenerEmpleadoPorIdAsync(int id)
        {
            return await _context.Empleado.FirstOrDefaultAsync(p => p.idEmpleado == id);
        }
        public async Task<IEnumerable<Empleado>> ObtenerEmpleadoAsync()
        {
            return await _context.Empleado.ToListAsync();
        }
        public async Task<IEnumerable<msjResp>> AgregarEmpleadoSP(CrearEmpleado empleado)
        {
            var CedulaPersona = new SqlParameter("@CedulaPersona", empleado.CedulaPersona);
            var Nombre = new SqlParameter("@Nombre", empleado.Nombre);
            var Apellido1 = new SqlParameter("@Apellido1", empleado.Apellido1);
            var Apellido2 = new SqlParameter("@Apellido2", empleado.Apellido2);
            var FechaNacimiento = new SqlParameter("@FechaNacimiento", empleado.FechaNacimiento );
            var IdGenero = new SqlParameter("@IdGenero", empleado.IdGenero);
            var Telefono = new SqlParameter("@Telefono", empleado.Telefono);
            var activoTel = new SqlParameter("@activoTel",empleado.activoTel);
            var IdTipoTel = new SqlParameter("@IdTipoTel", empleado.IdTipoTel);
            var Correo = new SqlParameter("@Correo", empleado.Correo);
            var activoCor = new SqlParameter("@activoCor", empleado.activoCor);
            var IdTipoCorr = new SqlParameter("@IdTipoCorr", empleado.IdTipoCorr);
            var activoEmpl = new SqlParameter("@activoEmpl", empleado.activoEmpl);
            var Fecha_Ingreso = new SqlParameter("@Fecha_Ingreso", empleado.Fecha_Ingreso);
            var IdHorario = new SqlParameter("@IdHorario", empleado.IdHorario);
            var IdPuesto = new SqlParameter("@IdPuesto", empleado.IdPuesto);
            var Usuario = new SqlParameter("@Usuario", empleado.Usuario);
            var Contraseña = new SqlParameter("@Contraseña", empleado.Contraseña);
            var Bloqueado = new SqlParameter("@Bloqueado", empleado.Bloqueado);
            var Primer_Ingreso = new SqlParameter("@Primer_Ingreso", empleado.Primer_Ingreso);
            var IdPerfilIngreso = new SqlParameter("@IdPerfil", empleado.IdPerfil);
            var Gestion = new SqlParameter("@Gestion", 'N');
            var IdEmple = new SqlParameter("@IdEmplel", DBNull.Value);
            var IdCed = new SqlParameter("@IdCed", DBNull.Value);
            var IdTel = new SqlParameter("@IdTel", DBNull.Value);
            var IdCor = new SqlParameter("@IdCor", DBNull.Value);
            var IdUser = new SqlParameter("@IdUser", DBNull.Value);
            return await _context.msjResp.
                FromSqlRaw("exec SP_CrearEmpleado @IdEmple, @IdCed @IdTel @IdCor, @IdUser " +
                "@CedulaPersona, @Nombre, @Apellido1, @Apellido2,@FechaNacimiento, @IdGenero,"+
                "@Telefono, @activoTel, @IdTipoTel," +
                "@Correo, @activoCor, @IdTipoCorr," +
                "@activoEmpl, @Fecha_Ingreso, @IdHorario int, @IdPuesto,"+
                "@Usuario, @Contraseña, @Bloqueado, @Primer_Ingreso, @IdPerfil,"+
                "@Gestion," +
                IdEmple, IdCed, IdTel, IdCor,IdUser,
                CedulaPersona, Nombre, Apellido1, Apellido2, FechaNacimiento, IdGenero,
                Telefono, activoTel, IdTipoTel,
                Correo, activoCor, IdTipoCorr,
                activoEmpl, Fecha_Ingreso, IdHorario, IdPuesto,
                Usuario, Contraseña, Bloqueado, Primer_Ingreso, IdPerfilIngreso,
                Gestion).ToListAsync();

        }
        public async Task<IEnumerable<msjResp>> ActualizarEmpleadoSP(CrearEmpleado empleado)
        {
            var CedulaPersona = new SqlParameter("@CedulaPersona", empleado.CedulaPersona);
            var Nombre = new SqlParameter("@Nombre", empleado.Nombre);
            var Apellido1 = new SqlParameter("@Apellido1", empleado.Apellido1);
            var Apellido2 = new SqlParameter("@Apellido2", empleado.Apellido2);
            var FechaNacimiento = new SqlParameter("@FechaNacimiento", empleado.FechaNacimiento);
            var IdGenero = new SqlParameter("@IdGenero", empleado.IdGenero);
            var Telefono = new SqlParameter("@Telefono", empleado.Telefono);
            var activoTel = new SqlParameter("@activoTel", empleado.activoTel);
            var IdTipoTel = new SqlParameter("@IdTipoTel", empleado.IdTipoTel);
            var Correo = new SqlParameter("@Correo", empleado.Correo);
            var activoCor = new SqlParameter("@activoCor", empleado.activoCor);
            var IdTipoCorr = new SqlParameter("@IdTipoCorr", empleado.IdTipoCorr);
            var activoEmpl = new SqlParameter("@activoEmpl", empleado.activoEmpl);
            var Fecha_Ingreso = new SqlParameter("@Fecha_Ingreso", empleado.Fecha_Ingreso);
            var IdHorario = new SqlParameter("@IdHorario", empleado.IdHorario);
            var IdPuesto = new SqlParameter("@IdPuesto", empleado.IdPuesto);
            var Usuario = new SqlParameter("@Usuario", empleado.Usuario);
            var Contraseña = new SqlParameter("@Contraseña", empleado.Contraseña);
            var Bloqueado = new SqlParameter("@Bloqueado", empleado.Bloqueado);
            var Primer_Ingreso = new SqlParameter("@Primer_Ingreso", empleado.Primer_Ingreso);
            var IdPerfilIngreso = new SqlParameter("@IdPerfil", empleado.IdPerfil);
            var Gestion = new SqlParameter("@Gestion", 'N');
            var IdEmple = new SqlParameter("@IdAul", empleado.IdEmple);
            var IdCed = new SqlParameter("@IdAul", empleado.IdCed);
            var IdTel = new SqlParameter("@IdAul", empleado.idTel);
            var IdCor = new SqlParameter("@IdAul", empleado.IdCor);
            var IdUser = new SqlParameter("@IdUser", empleado.IdUser);
            return await _context.msjResp.
                FromSqlRaw("exec SP_CrearEmpleado @IdEmple, @IdCed @IdTel @IdCor, @IdUser " +
                "@CedulaPersona, @Nombre, @Apellido1, @Apellido2,@FechaNacimiento, @IdGenero," +
                "@Telefono, @activoTel, @IdTipoTel," +
                "@Correo, @activoCor, @IdTipoCorr," +
                "@activoEmpl, @Fecha_Ingreso, @IdHorario int, @IdPuesto," +
                "@Usuario, @Contraseña, @Bloqueado, @Primer_Ingreso, @IdPerfil," +
                "@Gestion," +
                IdEmple, IdCed, IdTel, IdCor, IdUser,
                CedulaPersona, Nombre, Apellido1, Apellido2, FechaNacimiento, IdGenero,
                Telefono, activoTel, IdTipoTel,
                Correo, activoCor, IdTipoCorr,
                activoEmpl, Fecha_Ingreso, IdHorario, IdPuesto,
                Usuario, Contraseña, Bloqueado, Primer_Ingreso, IdPerfilIngreso,
                Gestion).ToListAsync();
        }
        public async Task EliminarEmpleadoAsync(int id)
        {
            var empleado = await ObtenerEmpleadoPorIdAsync(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
        public async Task ActualizarEmpleadoAsync(Empleado empleado) //DA
        {
            _context.Empleado.Update(empleado);
            await _context.SaveChangesAsync();
        }
        public async Task ActivarEmpleadoAsync(int id)
        {
            var empleado = await ObtenerEmpleadoPorIdAsync(id);
            if (empleado != null)
            {
                empleado.Activo = true;
                _context.Empleado.Update(empleado);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DesActivarEmpleadoAsync(int id)
        {
            var empleado = await ObtenerEmpleadoPorIdAsync(id);
            if (empleado != null)
            {
                empleado.Activo = false;
                _context.Empleado.Update(empleado);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Empleado>> ObtenerEmpleadoActivosAsync()
        {
            return await _context.Empleado.Where(p => p.Activo == true).ToListAsync();
        }
        public async Task<IEnumerable<Empleado>> ObtenerEmpleadoInActivosAsync()
        {
            return await _context.Empleado.Where(p => p.Activo == false).ToListAsync();
        }
        public async Task<IEnumerable<Empleado>> EmpleadoOrdenadoxHorario() //EOH = EmpleadoOrdenadoxHorario
        {
            var EOH = _context.Empleado.OrderBy(d => d.Horario_idHorario).ToListAsync();
            return await EOH;
        }
        public async Task<IEnumerable<Empleado>> EmpleadoOrdenadoxPuesto() //EOP = EmpleadoOrdenadoxHorario
        {
            var EOP = _context.Empleado.OrderBy(d => d.Puesto_idPuesto).ToListAsync();
            return await EOP;
        }
        public async Task<IEnumerable<Empleado>> EmpleadoOrdenadoxFechaIngreso() //EOFI = EmpleadoOrdenadoFechaIngreso
        {
            var EOFI = _context.Empleado.OrderBy(b => b.Fecha_Ingreso).ToListAsync();
            return await EOFI;
        }
    }
}
