using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICBF_Project.Models.ViewModels
{
    public class UsuarioVM
    {
        public Usuario oUsuario { get; set; }

        public List<SelectListItem> oListaRol { get; set; }

    }
}
