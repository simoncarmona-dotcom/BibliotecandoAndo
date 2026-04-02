using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecandoAndo.Models;

namespace BibliotecandoAndo.Services {
    public class PrestamoService {
        private List<Prestamo> prestamos = new List<Prestamo>();

        public void AgregarPrestamo(Prestamo prestamo) {
            prestamos.Add(prestamo);
        }

        public void EliminarPrestamo(Prestamo prestamo) {
            prestamos.Remove(prestamo);
        }

        public List<Prestamo> ObtenerTodos() {
            return prestamos;
        }

        public List<Prestamo> BuscarPrestamo(string criterio) {
            return prestamos.Where(p => p.Id.ToString() == criterio || 
                                        p.Estado.ToString().Contains(criterio, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Prestamo> OrdenarPorFechaLimite() {
            return prestamos.OrderBy(p => p.FechaVencimiento).ToList();
        }

        public int TotalPrestamos() {
            return prestamos.Count;
        }

        public int PrestamosActivos() {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
        }

        public int PrestamosVencidos() {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Vencido || p.EstaVencido());
        }

        public int PrestamosDevueltos() {
            return prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
        }

        public double PromedioDiasPrestamo() {
            if (prestamos.Count == 0) return 0;
            return prestamos.Average(p => p.DiasTranscurridos());
        }
    }
}