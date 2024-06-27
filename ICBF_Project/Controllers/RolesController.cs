using ICBF_Project.Models;
using ICBF_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ICBF_Project.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class RolesController : Controller
    {
        private readonly DbIcbfContext _DBContext;

        public RolesController(DbIcbfContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Role> lista = _DBContext.Roles.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Rol_Detalle(int pkIdRol)
        {
            RolVM oRolVM = new RolVM()
            {
                oRol = new Role()
            };

            if (pkIdRol != 0)
            {
                oRolVM.oRol = _DBContext.Roles.Find(pkIdRol);
            }
            return View(oRolVM);
        }

        [HttpPost]
        public IActionResult Rol_Detalle(RolVM oRolVM)
        {
            if (_DBContext.Roles.Any(r => r.NombreRol == oRolVM.oRol.NombreRol && r.PkIdRol != oRolVM.oRol.PkIdRol))
            {
                ModelState.AddModelError("oRol.NombreRol", "El Rol ya está registrado.");
            }

            if (ModelState.IsValid)
            {
                if (oRolVM.oRol.PkIdRol == 0)
                {
                    _DBContext.Roles.Add(oRolVM.oRol);
                }
                else
                {
                    _DBContext.Roles.Update(oRolVM.oRol);
                }

                _DBContext.SaveChanges();

                return RedirectToAction("Index", "Roles");
            }
            return View(oRolVM);
        }

        [HttpGet]
        public IActionResult Eliminar(int pkIdRol)
        {
            Role oRol = _DBContext.Roles.Find(pkIdRol);
            return View(oRol);
        }

        [HttpPost]
        public IActionResult Eliminar(Role oRol)
        {
            _DBContext.Roles.Remove(oRol);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Roles");
        }
    }
}
