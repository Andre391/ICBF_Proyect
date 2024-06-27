using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICBF_Project.Models
{
    public partial class Nino
    {
        [Key]
        public int PkNuip { get; set; }

        [Required(ErrorMessage = "El Nombre es requerido.")]
        public string Nombre { get; set; } = null!;

        [Required(ErrorMessage = "El Apellido es requerido.")]
        public string Apellido { get; set; } = null!;

        [Required(ErrorMessage = "La Fecha de Nacimiento es requerida.")]
        [ValidateFechaNacimiento(ErrorMessage = "La fecha de nacimiento debe estar entre 2 y 6 años y no puede ser una fecha futura.")]
        public DateOnly FechaNacimiento { get; set; }

        [Required(ErrorMessage = "El Tipo de Sangre requerido.")]
        public string TipoSangre { get; set; } = null!;

        [Required(ErrorMessage = "El Departamento es requerido.")]
        public string Departamento { get; set; } = null!;

        [Required(ErrorMessage = "La Ciudad es requerida.")]
        public string Ciudad { get; set; } = null!;

        [Required(ErrorMessage = "La Identificación del Acudiente es requerida.")]
        public int FkIdUsuario { get; set; }

        [Required(ErrorMessage = "El Telefono es requerido.")]
        public string Telefono { get; set; } = null!;

        [Required(ErrorMessage = "La Dirección es requerida.")]
        public string Direccion { get; set; } = null!;

        [Required(ErrorMessage = "La EPS es requerida.")]
        public string Eps { get; set; } = null!;

        [Required(ErrorMessage = "El Jardin es requerido.")]
        public int FkIdJardin { get; set; }

        public virtual ICollection<Asistencia> Asistencia { get; set; } = new List<Asistencia>();

        public virtual ICollection<AvanceAcademico> AvanceAcademicos { get; set; } = new List<AvanceAcademico>();

        public virtual Jardine oJardin { get; set; } = null!;

        public virtual Usuario oUsuario { get; set; } = null!;

        public class ValidateFechaNacimientoAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is not DateOnly fechaNacimiento)
                {
                    return new ValidationResult("La fecha de nacimiento no es válida.", new[] { validationContext.MemberName });
                }

                if (fechaNacimiento > DateOnly.FromDateTime(DateTime.Today))
                {
                    return new ValidationResult("La fecha de nacimiento no puede ser una fecha futura.", new[] { validationContext.MemberName });
                }

                var edadMinima = DateOnly.FromDateTime(DateTime.Today.AddYears(-6));
                var edadMaxima = DateOnly.FromDateTime(DateTime.Today.AddYears(-2));

                if (fechaNacimiento < edadMaxima || fechaNacimiento > edadMinima)
                {
                    return new ValidationResult("La edad debe estar entre 2 y 6 años.", new[] { validationContext.MemberName });
                }

                return ValidationResult.Success;
            }
        }

    }
}
