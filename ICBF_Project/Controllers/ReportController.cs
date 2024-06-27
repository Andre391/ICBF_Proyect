using Microsoft.AspNetCore.Mvc;
using ICBF_Project.Data;
using ICBF_Project.Models;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http.Extensions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace ICBF_Project.Controllers
{
    public class ReportController : Controller
    {
        private readonly IConverter _converter;
        private readonly DbIcbfContext _DBContext;

        public ReportController(IConverter converter, DbIcbfContext context)
        {
            _converter = converter;
            _DBContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> VistaParaPDF()
        {
            var jardinesNoAprobados = await _DBContext.Jardines
                                        .Where(j => j.Estado == "Negado")
                                        .ToListAsync();
            return View(jardinesNoAprobados);
        }

        public async Task<IActionResult> PDFInasistencia()
        {
            var Inasistencias = await _DBContext.Asistencias.Include(n => n.oNino)
                                        .Where(a => a.EstadoNino == "Enfermo")
                                        .ToListAsync();
            return View(Inasistencias);
        }

        private string GenerarUrlAbsoluta(string rutaRelativa)
        {
            return $"{Request.Scheme}://{Request.Host}{rutaRelativa}";
        }

        public async Task<IActionResult> MostrarPDFenPagina(string reporte)
        {
            string url_pagina = string.Empty;

            if (reporte == "Jardines")
            {
                url_pagina = GenerarUrlAbsoluta("/Report/VistaParaPDF");
            }
            else if (reporte == "Inasistencias")
            {
                url_pagina = GenerarUrlAbsoluta("/Report/PDFInasistencia");
            }

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = { new ObjectSettings { Page = url_pagina } }
            };

            var archivoPDF = _converter.Convert(pdf);

            return File(archivoPDF, "application/pdf");
        }

        public async Task<IActionResult> DescargarPDF(string reporte)
        {
            string url_pagina = string.Empty;

            if (reporte == "Jardines")
            {
                url_pagina = GenerarUrlAbsoluta("/Report/VistaParaPDF");
            }
            else if (reporte == "Inasistencias")
            {
                url_pagina = GenerarUrlAbsoluta("/Report/PDFInasistencia");
            }

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = new GlobalSettings()
                {
                    PaperSize = PaperKind.A4,
                    Orientation = Orientation.Portrait
                },
                Objects = { new ObjectSettings { Page = url_pagina } }
            };

            var archivoPDF = _converter.Convert(pdf);
            string nombrePDF = "reporte_" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf";

            return File(archivoPDF, "application/pdf", nombrePDF);
        }
    }
}
