using ICBF_Project.Models;
using ICBF_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ICBF_Project.Controllers
{

    [Authorize(Roles ="Administrador")]
    public class UsuariosController : Controller
    {
        private readonly DbIcbfContext _DBContext;

        public UsuariosController(DbIcbfContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Usuario> lista = _DBContext.Usuarios.Include(c => c.oRol).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Usuario_Detalle(int pkIdUsuario)
        {
            UsuarioVM oUsuarioVM = new UsuarioVM()
            {
                oUsuario = new Usuario(),
                oListaRol = _DBContext.Roles.Select(rol => new SelectListItem()
                {
                    Text = rol.NombreRol,
                    Value = rol.PkIdRol.ToString()
                }).ToList()
            };

            if (pkIdUsuario != 0)
            {
                oUsuarioVM.oUsuario = _DBContext.Usuarios.Find(pkIdUsuario);
            }
            return View(oUsuarioVM);
        }

        [HttpPost]
        public IActionResult Usuario_Detalle(UsuarioVM oUsuarioVM)
        {
            /*if (_DBContext.Usuarios.Any(u => u.Email == oUsuarioVM.oUsuario.Email && u.PkIdUsuario != oUsuarioVM.oUsuario.PkIdUsuario))
            {
                ModelState.AddModelError("oUsuario.Email", "El correo electrónico ya está registrado.");
            }

            if (ModelState.IsValid)
            {*/
                if (oUsuarioVM.oUsuario.PkIdUsuario == 0)
                {
                    _DBContext.Usuarios.Add(oUsuarioVM.oUsuario);
                }
                else
                {
                    _DBContext.Usuarios.Update(oUsuarioVM.oUsuario);
                }

                _DBContext.SaveChanges();
                return RedirectToAction("Index", "Usuarios");
            //}

            /*oUsuarioVM.oListaRol = _DBContext.Roles.Select(rol => new SelectListItem()
            {
                Text = rol.NombreRol,
                Value = rol.PkIdRol.ToString()
            }).ToList();

            return View(oUsuarioVM);*/
        }


        [HttpGet]
        public IActionResult Eliminar(int pkIdUsuario)
        {
            Usuario oUsuario = _DBContext.Usuarios.Include(c => c.oRol).Where(u => u.PkIdUsuario == pkIdUsuario).FirstOrDefault();


            return View(oUsuario);
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario oUsuario)
        {
            _DBContext.Usuarios.Remove(oUsuario);
            _DBContext.SaveChanges();


            return RedirectToAction("Index", "Usuarios");
        }

      
    }
}
