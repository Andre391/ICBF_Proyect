using ICBF_Project.Models;
using ICBF_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ICBF_Project.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class NinosController : Controller
    {
        private readonly DbIcbfContext _DBContext;

        public NinosController(DbIcbfContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Nino> lista = _DBContext.Ninos.Include(j => j.oJardin).Include(u => u.oUsuario).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nino_Detalle(int pkNuip)
        {
            NinoVM oNinoVM = new NinoVM()
            {
                oNino = new Nino(),
                oListaUsuario = _DBContext.Usuarios
                    .Where(usuario => usuario.FkIdRol == 3)
                    .Select(usuario => new SelectListItem()
                    {
                        Text = usuario.Nombre,
                        Value = usuario.PkIdUsuario.ToString()
                    }).ToList(),

                oListaJardin = _DBContext.Jardines.Select(jardin => new SelectListItem()
                {
                    Text = jardin.Nombre,
                    Value = jardin.PkIdJardin.ToString()
                }).ToList()
            };

            if (pkNuip != 0)
            {
                oNinoVM.oNino = _DBContext.Ninos.Find(pkNuip);
            }

            return View(oNinoVM);
        }

        [HttpPost]
        public IActionResult Nino_Detalle(NinoVM oNinoVM)
        {
            if (!ModelState.IsValid)
            {
                // Si el modelo no es válido, retornar la vista con los errores
                return View(oNinoVM);
            }

            if (_DBContext.Ninos.Any(nino => nino.PkNuip == oNinoVM.oNino.PkNuip))
            {
                // Actualizar el registro existente
                _DBContext.Ninos.Update(oNinoVM.oNino);
            }
            else
            {
                // Agregar un nuevo registro
                _DBContext.Ninos.Add(oNinoVM.oNino);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Ninos");
        }

        [HttpGet]
        public IActionResult Eliminar(int pkNuip)
        {
            var oNino = _DBContext.Ninos.Include(j => j.oJardin).Include(u => u.oUsuario).FirstOrDefault(n => n.PkNuip == pkNuip);

            if (oNino == null)
            {
                return NotFound();
            }

            return View(oNino);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmed(int pkNuip)
        {
            var oNino = _DBContext.Ninos.Find(pkNuip);

            if (oNino != null)
            {
                try
                {
                    _DBContext.Ninos.Remove(oNino);
                    _DBContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {

                    TempData["ErrorMessage"] = "No se puede eliminar este niño porque tiene avances académicos asociados. Por favor, elimine los avances académicos primero.";
                    return RedirectToAction("Index", "Ninos");
                }
            }
            else
            {
                // Manejar el caso donde el objeto no se encuentra
                return NotFound();
            }

            return RedirectToAction("Index", "Ninos");
        }
    }
}
