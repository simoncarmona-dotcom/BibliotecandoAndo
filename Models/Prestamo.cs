using System;

namespace BibliotecandoAndo.Models {
    public class Prestamo {
        public int Id { get; set; }
        public Libro LibroPrestado { get; set; }
        public Usuario UsuarioPrestatario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public DateTime? FechaDevolucion { get; set; } = null;
        public EstadoPrestamo Estado { get; set; } = EstadoPrestamo.Activo;

        public Prestamo() {
        }

        public Prestamo(int id, Libro libro, Usuario usuario, DateTime fechaPrestamo, int diasPrestamo) {
            Id = id;
            LibroPrestado = libro;
            UsuarioPrestatario = usuario;
            FechaPrestamo = fechaPrestamo;
            FechaVencimiento = fechaPrestamo.AddDays(diasPrestamo);
            FechaDevolucion = null;
            Estado = EstadoPrestamo.Activo;
        }

        public bool EstaVencido() {
            if (Estado == EstadoPrestamo.Devuelto) return false;
            return DateTime.Now > FechaVencimiento;
        }

        public int DiasTranscurridos() {
            if (FechaDevolucion.HasValue) {
                return (FechaDevolucion.Value - FechaPrestamo).Days;
            }
            return (DateTime.Now - FechaPrestamo).Days;
        }

        public string ResumenCorto() {
            return $"Préstamo {Id} - Libro: {LibroPrestado.Titulo} - Usuario: {UsuarioPrestatario.Nombre}";
        }

        public string DetalleCompleto() {
            string devuelto = FechaDevolucion.HasValue ? FechaDevolucion.Value.ToShortDateString() : "Pendiente";
            return $"ID: {Id} | Libro: {LibroPrestado.Titulo} | Usuario: {UsuarioPrestatario.Nombre} | Préstamo: {FechaPrestamo.ToShortDateString()} | Vence: {FechaVencimiento.ToShortDateString()} | Devolución: {devuelto} | Estado: {Estado} | Vencido: {EstaVencido()} | Días transcurridos: {DiasTranscurridos()}";
        }

        public override string ToString() {
            return ResumenCorto();
        }
    }
}