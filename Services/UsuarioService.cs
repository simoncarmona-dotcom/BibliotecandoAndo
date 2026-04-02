using System.Collections.Generic;
using System.Linq;
using BibliotecandoAndo.Models;

namespace BibliotecandoAndo.Services {
    public class UsuarioService {
        private List<Usuario> usuarios = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario) {
            usuarios.Add(usuario);
        }

        public void EliminarUsuario(Usuario usuario) {
            usuarios.Remove(usuario);
        }

        public List<Usuario> ObtenerTodos() {
            return usuarios;
        }

        public List<Usuario> BuscarUsuario(string criterio) {
            return usuarios.Where(u => u.Nombre.Contains(criterio, System.StringComparison.OrdinalIgnoreCase) || 
                                       u.Documento == criterio).ToList();
        }

        public List<Usuario> OrdenarPorNombre() {
            return usuarios.OrderBy(u => u.Nombre).ToList();
        }

        public int TotalUsuarios() {
            return usuarios.Count;
        }

        public int UsuariosActivos() {
            return usuarios.Count(u => u.Activo);
        }

        public int UsuariosInactivos() {
            return usuarios.Count(u => !u.Activo);
        }
    }
}