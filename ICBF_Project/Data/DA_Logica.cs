using ICBF_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace ICBF_Project.Data
{
    public class DA_Logica
    {
        private readonly DbIcbfContext _context;

        public DA_Logica(DbIcbfContext context)
        {
            _context = context;
        }

        public List<Usuario> ListaUsuario()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario ValidarUsuario(string _correo, string _clave)
        {
            return _context.Usuarios.Include(u => u.oRol).FirstOrDefault(item => item.Email == _correo && item.Contrasena == _clave);
        }
    }
}
