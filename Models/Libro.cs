using System;

namespace BibliotecandoAndo.Models {
    public class Libro {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }
        public string Categoria { get; set; }
        public bool Disponible { get; set; } = true;

        public Libro() {
        }

        public Libro(int id, string titulo, string autor, int anioPublicacion, string categoria) {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            AnioPublicacion = anioPublicacion;
            Categoria = categoria;
            Disponible = true;
        }

        public string ResumenCorto() {
            return $"{Titulo} - {Autor}";
        }

        public string DetalleCompleto() {
            return $"ID: {Id} | Título: {Titulo} | Autor: {Autor} | Año: {AnioPublicacion} | Categoría: {Categoria} | Disponible: {Disponible}";
        }

        public override string ToString() {
            return ResumenCorto();
        }
    }
}