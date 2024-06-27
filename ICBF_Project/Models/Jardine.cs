using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICBF_Project.Models;

public partial class Jardine
{
    [Key]
    public int PkIdJardin { get; set; }

    [Required(ErrorMessage = "El Nombre es requerido.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "La Dirección es requerida.")]
    public string Direccion { get; set; } = null!;

    [Required(ErrorMessage = "El Estado es requerido.")]
    public string Estado { get; set; } = null!;

    public virtual ICollection<Nino> Ninos { get; set; } = new List<Nino>();
}
