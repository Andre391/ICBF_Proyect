using Microsoft.AspNetCore.Mvc.Rendering;

namespace ICBF_Project.Models.ViewModels
{
    public class NinoVM
    {
        public Nino oNino { get; set; }

        public List<SelectListItem> oListaUsuario { get; set; }

        public List<SelectListItem> oListaJardin { get; set; }

        public Dictionary<string, string> DepartamentosConCapitales { get; set; }

        public NinoVM()
        {
            DepartamentosConCapitales = new Dictionary<string, string>
            {
                {"Amazonas", "Leticia"},
                {"Antioquia", "Medellín"},
                {"Arauca", "Arauca"},
                {"Atlántico", "Barranquilla"},
                {"Bolívar", "Cartagena"},
                {"Boyacá", "Tunja"},
                {"Caldas", "Manizales"},
                {"Caquetá", "Florencia"},
                {"Casanare", "Yopal"},
                {"Cauca", "Popayán"},
                {"Cesar", "Valledupar"},
                {"Chocó", "Quibdó"},
                {"Córdoba", "Montería"},
                {"Cundinamarca", "Bogotá"},
                {"Guainía", "Inírida"},
                {"Guaviare", "San José del Guaviare"},
                {"Huila", "Neiva"},
                {"La Guajira", "Riohacha"},
                {"Magdalena", "Santa Marta"},
                {"Meta", "Villavicencio"},
                {"Nariño", "Pasto"},
                {"Norte de Santander", "Cúcuta"},
                {"Putumayo", "Mocoa"},
                {"Quindío", "Armenia"},
                {"Risaralda", "Pereira"},
                {"San Andres y Providencia", "San Andrés"},
                {"Santander", "Bucaramanga"},
                {"Sucre", "Sincelejo"},
                {"Tolima", "Ibagué"},
                {"Valle del Cauca", "Cali"},
                {"Vaupés", "Mitú"},
                {"Vichada", "Puerto Carreño"}
            };
        }
    }
}

