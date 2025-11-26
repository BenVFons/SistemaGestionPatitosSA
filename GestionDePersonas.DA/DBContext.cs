using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionDePersonas.DA
{
    public class DBContexto : DbContext
    {
        public DBContexto(DbContextOptions<DBContexto> options) : base(options)
        {
        }
        public DbSet<Model.Persona> Persona { get; set; }
        public DbSet<Model.Asistencia> Asistencia { get; set; }
        public DbSet<Model.Catalogo_TipoCorreo> Catalogo_TipoCorreo { get; set; }
        public DbSet<Model.Catalogo_TipoTelefono> Catalogo_TipoTelefono { get; set; }
        public DbSet<Model.CatalogoGenero> CatalogoGenero { get; set; }
        public DbSet<Model.Correo_Electronico> Correo_Electronico { get; set; }
        public DbSet<Model.Departamento> Departamento { get; set; }
        public DbSet<Model.Detalle_Evaluacion> Detalle_Evaluacion { get; set; }
        public DbSet<Model.Empleado> Empleado { get; set; }
        public DbSet<Model.Evaluacion> Evaluacion { get; set; }
        public DbSet<Model.Reporte_Evaluacion> Reporte_Evaluacion { get; set; }
        public DbSet<Model.Horario> Horario { get; set; }
        public DbSet<Model.Perfil_Ingreso> Perfil_Ingreso { get; set; }
        public DbSet<Model.Planilla> Planilla { get; set; }
        public DbSet<Model.PreguntaEvaluacion> PreguntaEvaluacion { get; set; }
        public DbSet<Model.Puesto> Puesto { get; set; }
        public DbSet<Model.Telefono> Telefono { get; set; }
        public DbSet<Model.Tipo_Marca> Tipo_Marca { get; set; }
        public DbSet<Model.Usuario> Usuario { get; set; }
        public DbSet<Model.msjResp> msjResp { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    if (property.ClrType.IsEnum)
                    {
                        var converterType = typeof(Microsoft.EntityFrameworkCore.Storage.ValueConversion.EnumToNumberConverter<,>)
                            .MakeGenericType(property.ClrType, typeof(int));

                        var converter = (Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter)
                            Activator.CreateInstance(converterType);

                        property.SetValueConverter(converter);
                    }
                }
            }
        }


    }


}
