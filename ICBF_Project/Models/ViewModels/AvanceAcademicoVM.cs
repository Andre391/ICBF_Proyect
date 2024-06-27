using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICBF_Project.Models.ViewModels
{
    public class AvanceAcademicoVM
    {
        public AvanceAcademico oAvanceAcademico { get; set; }

        public List<SelectListItem> oListaNino { get; set; }
    }
}
