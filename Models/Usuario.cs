using System;

namespace BibliotecandoAndo.Models {
    public class Usuario {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public string Contacto { get; set; }
        public bool Activo { get; set; } = true;

        public Usuario() {
        }

        public Usuario(int id, string nombre, string documento, string contacto) {
            Id = id;
            Nombre = nombre;
            Documento = documento;
            Contacto = contacto;
            Activo = true;
        }

        public string ResumenCorto() {
            return $"{Nombre} - Doc: {Documento}";
        }

        public string DetalleCompleto() {
            return $"ID: {Id} | Nombre: {Nombre} | Documento: {Documento} | Contacto: {Contacto} | Activo: {Activo}";
        }

        public override string ToString() {
            return ResumenCorto();
        }
    }
}