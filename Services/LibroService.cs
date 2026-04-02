using System.Collections.Generic;
using System.Linq;
using BibliotecandoAndo.Models;

namespace BibliotecandoAndo.Services {
    public class LibroService {
        private List<Libro> libros = new List<Libro>();

        public void AgregarLibro(Libro libro) {
            libros.Add(libro);
        }

        public void EliminarLibro(Libro libro) {
            libros.Remove(libro);
        }

        public List<Libro> ObtenerTodos() {
            return libros;
        }

        public List<Libro> BuscarLibro(string criterio) {
            return libros.Where(l => l.Titulo.Contains(criterio, System.StringComparison.OrdinalIgnoreCase) || 
                                     l.Autor.Contains(criterio, System.StringComparison.OrdinalIgnoreCase) || 
                                     l.Id.ToString() == criterio).ToList();
        }

        public List<Libro> OrdenarPorTitulo() {
            return libros.OrderBy(l => l.Titulo).ToList();
        }

        public List<Libro> OrdenarPorAnio() {
            return libros.OrderBy(l => l.AnioPublicacion).ToList();
        }

        public int TotalLibros() {
            return libros.Count;
        }

        public int LibrosDisponibles() {
            return libros.Count(l => l.Disponible);
        }

        public int LibrosPrestados() {
            return libros.Count(l => !l.Disponible);
        }
    }
}