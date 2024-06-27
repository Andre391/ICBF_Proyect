using ICBF_Project.Models;
using ICBF_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ICBF_Project.Controllers
{
    public class AvanceAcademicoController : Controller
    {
        private readonly DbIcbfContext _DBContext;

        public AvanceAcademicoController(DbIcbfContext context)
        {
            _DBContext = context;
        }

        [Authorize(Roles = "Administrador, Acudiente")]
        public IActionResult Index()
        {
            List<AvanceAcademico>lista = _DBContext.AvanceAcademicos.Include(n => n.oNino).ToList();    
            return View(lista);
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult AvanceAcademico_Detalle(int pkIdAvanceAcademico)
        {
            AvanceAcademicoVM oAvanceAcademicoVM = new AvanceAcademicoVM()
            {
                oAvanceAcademico = new AvanceAcademico(),
                oListaNino = _DBContext.Ninos.Select(nino => new SelectListItem()
                {
                    Text = nino.PkNuip.ToString(),
                    Value = nino.PkNuip.ToString()
                }).ToList()
            };

            if (pkIdAvanceAcademico != 0)
            {
                oAvanceAcademicoVM.oAvanceAcademico = _DBContext.AvanceAcademicos.Find(pkIdAvanceAcademico);
            }
            return View(oAvanceAcademicoVM);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult AvanceAcademico_Detalle(AvanceAcademicoVM oAvanceAcademicoVM)
        {
            if (oAvanceAcademicoVM.oAvanceAcademico.PkIdAvanceAcademico == 0)
            {

                _DBContext.AvanceAcademicos.Add(oAvanceAcademicoVM.oAvanceAcademico);
            }
            else
            {
                _DBContext.AvanceAcademicos.Update(oAvanceAcademicoVM.oAvanceAcademico);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "AvanceAcademico");

        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Eliminar(int pkIdAvanceAcademico)
        {
            AvanceAcademico oAvanceAcademico = _DBContext.AvanceAcademicos.Include(n => n.oNino).Where(a => a.PkIdAvanceAcademico == pkIdAvanceAcademico).FirstOrDefault();


            return View(oAvanceAcademico);
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Eliminar(AvanceAcademico oAvanceAcademico)
        {
            _DBContext.AvanceAcademicos.Remove(oAvanceAcademico);
            _DBContext.SaveChanges();


            return RedirectToAction("Index", "AvanceAcademico");
        }
    }
}
