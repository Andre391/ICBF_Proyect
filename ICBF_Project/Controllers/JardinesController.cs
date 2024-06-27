using ICBF_Project.Models.ViewModels;
using ICBF_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ICBF_Project.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class JardinesController : Controller
    {
        private readonly DbIcbfContext _DBContext;

        public JardinesController(DbIcbfContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Jardine> lista = _DBContext.Jardines.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Jardin_Detalle(int pkIdJardin)
        {
            JardinVM oJardinVM = new JardinVM()
            {
                oJardin = new Jardine()
            };

            if (pkIdJardin != 0)
            {
                oJardinVM.oJardin = _DBContext.Jardines.Find(pkIdJardin);
            }
            return View(oJardinVM);
        }

        [HttpPost]
        public IActionResult Jardin_Detalle(JardinVM oJardinVM)
        {
            if (_DBContext.Jardines.Any(j => j.Nombre == oJardinVM.oJardin.Nombre && j.PkIdJardin != oJardinVM.oJardin.PkIdJardin))
            {
                ModelState.AddModelError("oJardin.Nombre", "El Jardin ya está registrado.");
            }

            if (ModelState.IsValid)
            {
                if (oJardinVM.oJardin.PkIdJardin == 0)
                {
                    _DBContext.Jardines.Add(oJardinVM.oJardin);
                }
                else
                {
                    _DBContext.Jardines.Update(oJardinVM.oJardin);
                }

                _DBContext.SaveChanges();

                return RedirectToAction("Index", "Jardines");
            }
            return View(oJardinVM);
        }

        [HttpGet]
        public IActionResult Eliminar(int pkIdJardin)
        {
            Jardine oJardin = _DBContext.Jardines.Where(j => j.PkIdJardin == pkIdJardin).FirstOrDefault();
            return View(oJardin);
        }

        [HttpPost]
        public IActionResult Eliminar(Jardine oJardin)
        {
            try
            {
                _DBContext.Jardines.Remove(oJardin);
                _DBContext.SaveChanges();
                return RedirectToAction("Index", "Jardines");
            }
            catch (DbUpdateException ex)
            {
                TempData["ErrorMessage"] = "No se puede eliminar este jardín porque tiene niños asociados. Por favor, elimine los niños primero.";
                return RedirectToAction("Index", "Jardines");
            }
        }
    }
}
