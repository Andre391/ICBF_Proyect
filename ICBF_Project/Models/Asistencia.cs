using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICBF_Project.Models;

public partial class Asistencia
{
    [Key]
    public int PkIdAsistencia { get; set; }

    [Required(ErrorMessage = "El NUIP del niño es requerido.")]
    public int FkNuip { get; set; }

    [Required(ErrorMessage = "La Fecha es requerida.")]
    public DateOnly Fecha { get; set; }

    [Required(ErrorMessage = "El Estado del niño es requerido.")]
    public string EstadoNino { get; set; } = null!;

    public virtual Nino oNino { get; set; } = null!;
}