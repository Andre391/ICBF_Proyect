using ICBF_Project.Models;
using ICBF_Project.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ICBF_Project.Controllers
{

    [Authorize(Roles = "Administrador, Madre Comunitaria")]
    public class AsistenciaController : Controller
    {
        private readonly DbIcbfContext _DBContext;

        public AsistenciaController(DbIcbfContext context)
        {
            _DBContext = context;
        }

        
        public IActionResult Index()
        {
            List<Asistencia> lista = _DBContext.Asistencias.Include(n => n.oNino).ToList();
            return View(lista);
        }

        [HttpGet]
        [ServiceFilter(typeof(HorarioRestriccionFilter))]
        public IActionResult Asistencia_Detalle(int pkIdAsistencia)
        {
            AsistenciaVM oAsistenciaVM = new AsistenciaVM()
            {
                oAsistencia = new Asistencia(),
                oListaNino = _DBContext.Ninos.Select(nino => new SelectListItem()
                {
                    Text = nino.PkNuip.ToString(),
                    Value = nino.PkNuip.ToString()
                }).ToList()
            };

            if (pkIdAsistencia != 0)
            {
                oAsistenciaVM.oAsistencia = _DBContext.Asistencias.Find(pkIdAsistencia);
            }
            return View(oAsistenciaVM);
        }

        [HttpPost]
        [ServiceFilter(typeof(HorarioRestriccionFilter))]
        public IActionResult Asistencia_Detalle(AsistenciaVM oAsistenciaVM)
        {
            if (oAsistenciaVM.oAsistencia.PkIdAsistencia == 0)
            {

                _DBContext.Asistencias.Add(oAsistenciaVM.oAsistencia);
            }
            else
            {
                _DBContext.Asistencias.Update(oAsistenciaVM.oAsistencia);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Asistencia");
        }

        [HttpGet]
        [ServiceFilter(typeof(HorarioRestriccionFilter))]
        public IActionResult Eliminar(int pkIdAsistencia)
        {
            Asistencia oAsistencia = _DBContext.Asistencias.Include(n => n.oNino).Where(a => a.PkIdAsistencia == pkIdAsistencia).FirstOrDefault();


            return View(oAsistencia);
        }

        [HttpPost]
        [ServiceFilter(typeof(HorarioRestriccionFilter))]
        public IActionResult Eliminar(Asistencia oAsistencia)
        {
            _DBContext.Asistencias.Remove(oAsistencia);
            _DBContext.SaveChanges();


            return RedirectToAction("Index", "Asistencia");
        }

    }
}
