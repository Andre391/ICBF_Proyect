using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICBF_Project.Models;

public partial class Usuario
{
    [Key]
    public int PkIdUsuario { get; set; }

    [Required(ErrorMessage = "El Nombre de Usuario es requerido.")]
    public string NombreUsuario { get; set; } = null!;

    [Required(ErrorMessage = "La Contraseña es requerida.")]

    public string Contrasena { get; set; } = null!;

    [Required(ErrorMessage = "El Nombre es requerido.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "El Apellido es requerido.")]
    public string Apellido { get; set; } = null!;

    [Required(ErrorMessage = "La Cedula es requerida.")]
    public string Cedula { get; set; } = null!;

    [Required(ErrorMessage = "El Telefono es requerido.")]
    public string Telefono { get; set; } = null!;

    [Required(ErrorMessage = "La Dirección es requerida.")]
    public string Direccion { get; set; } = null!;

    [Required(ErrorMessage = "El Email es requerido.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "La Fecha de Nacimiento es requerida.")]
    public DateOnly FechaNacimiento { get; set; }

    [Required(ErrorMessage = "El Rol es requerido.")]
    public int FkIdRol { get; set; }

    public virtual Role oRol { get; set; } = null!;

    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();
}
