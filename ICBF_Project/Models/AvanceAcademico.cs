using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ICBF_Project.Models;

public partial class AvanceAcademico
{
    [Key]
    public int PkIdAvanceAcademico { get; set; }

    [Required(ErrorMessage = "El NUIP es requerido.")]
    public int FkNuip { get; set; }

    [Required(ErrorMessage = "El Nivel es requerido.")]
    public string Nivel { get; set; } = null!;

    [Required(ErrorMessage = "La Nota es requerida.")]
    public string Notas { get; set; } = null!;

    [Required(ErrorMessage = "La Descripción es requerida.")]
    public string Descripcion { get; set; } = null!;

    [Required(ErrorMessage = "La Fecha de Entrega es requerida.")]
    public DateOnly FechaEntrega { get; set; }

    public virtual Nino oNino { get; set; } = null!;
}
