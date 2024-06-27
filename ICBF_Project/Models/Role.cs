using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICBF_Project.Models;

public partial class Role
{
    [Key]
    public int PkIdRol { get; set; }

    [Required(ErrorMessage = "El Nombre del Rol es requerido.")]
    public string NombreRol { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
