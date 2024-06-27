using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICBF_Project.Models.ViewModels
{
    public class AsistenciaVM
    {
        public Asistencia oAsistencia {  get; set; }

        public List<SelectListItem> oListaNino { get; set; }
    }
}
