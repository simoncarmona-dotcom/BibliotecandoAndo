using System;
using System.Collections.Generic;
using BibliotecandoAndo.Models;
using BibliotecandoAndo.Services;

namespace BibliotecandoAndo {
    class Program {
        static void Main(string[] args) {
            ShowMainMenu();
        }

        static void ShowMainMenu() {
            bool exit = false;
            while (!exit) {
                Console.Clear();
                Console.WriteLine("=== SISTEMA BIBLIOTECANDO ANDO ===");
                Console.WriteLine("1. Libros\n2. Usuarios\n3. Préstamos\n4. Búsquedas y reportes\n5. Guardar/Cargar\n6. Pruebas EV08 (Servicios, KPIs y Arrays vs List)\n7. Salir");
                Console.Write("Seleccione una opción: ");
                
                switch (Console.ReadLine()) {
                    case "1": ShowBooksMenu(); break;
                    case "2": ShowUsersMenu(); break;
                    case "3": ShowLoansMenu(); break;
                    case "4": ShowSearchReportsMenu(); break;
                    case "5": ShowPersistenceMenu(); break;
                    case "6": RunEV08Tests(); break;
                    case "7": exit = ConfirmExitAndSave(); break;
                    default: ShowError("Opción no válida."); break;
                }
            }
        }

        static void ShowBooksMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ LIBROS ---");
            Console.WriteLine("1. Registrar libro\n2. Listar libros (Prueba Objetos)\n3. Ver detalle\n4. Actualizar libro\n5. Eliminar libro\n6. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "1": Console.WriteLine("Registrando nuevo libro..."); Pause(); break;
                case "2": 
                    Console.WriteLine("\n--- PRUEBA DE OBJETOS: LIBROS ---");
                    Libro libro1 = new Libro(1, "Cien años de soledad", "Gabriel García Márquez", 1967, "Realismo mágico");
                    Libro libro2 = new Libro(2, "1984", "George Orwell", 1949, "Ficción distópica");
                    Console.WriteLine(libro1.ResumenCorto());
                    Console.WriteLine(libro1.DetalleCompleto());
                    Console.WriteLine($"Validación Disponible: {libro1.Disponible}\n");
                    Console.WriteLine(libro2.ResumenCorto());
                    Console.WriteLine(libro2.DetalleCompleto());
                    Console.WriteLine($"Validación Disponible: {libro2.Disponible}");
                    Pause(); 
                    break;
                case "3": Console.WriteLine("Mostrando detalle del libro..."); Pause(); break;
                case "4": Console.WriteLine("Actualizando datos del libro..."); Pause(); break;
                case "5": Console.WriteLine("Validar: no permitir si está prestado. Eliminando libro..."); Pause(); break;
                case "6": return;
                default: ShowError("Opción inválida."); break;
            }
        }

        static void ShowUsersMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ USUARIOS ---");
            Console.WriteLine("1. Registrar usuario\n2. Listar usuarios (Prueba Objetos)\n3. Ver detalle\n4. Actualizar usuario\n5. Eliminar usuario\n6. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "1": Console.WriteLine("Registrando nuevo usuario..."); Pause(); break;
                case "2": 
                    Console.WriteLine("\n--- PRUEBA DE OBJETOS: USUARIOS ---");
                    Usuario user1 = new Usuario(1, "Ana Gómez", "10203040", "ana@correo.com");
                    Usuario user2 = new Usuario(2, "Luis Pérez", "50607080", "luis@correo.com");
                    Console.WriteLine(user1.ResumenCorto());
                    Console.WriteLine(user1.DetalleCompleto());
                    Console.WriteLine($"Validación Activo: {user1.Activo}\n");
                    Console.WriteLine(user2.ResumenCorto());
                    Console.WriteLine(user2.DetalleCompleto());
                    Console.WriteLine($"Validación Activo: {user2.Activo}");
                    Pause(); 
                    break;
                case "3": Console.WriteLine("Mostrando detalle del usuario..."); Pause(); break;
                case "4": Console.WriteLine("Actualizando datos del usuario..."); Pause(); break;
                case "5": Console.WriteLine("Validar: no permitir si tiene préstamos activos. Eliminando usuario..."); Pause(); break;
                case "6": return;
                default: ShowError("Opción inválida."); break;
            }
        }

        static void ShowLoansMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ PRÉSTAMOS ---");
            Console.WriteLine("1. Crear préstamo\n2. Listar préstamos (Prueba Objetos)\n3. Ver detalle\n4. Registrar devolución\n5. Eliminar préstamo\n6. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "1": Console.WriteLine("Validaciones: Verificar usuario activo y libro disponible. Creando préstamo..."); Pause(); break;
                case "2": 
                    Console.WriteLine("\n--- PRUEBA DE OBJETOS: PRÉSTAMO ---");
                    Libro libroP = new Libro(3, "El Hobbit", "J.R.R. Tolkien", 1937, "Fantasía");
                    Usuario usuarioP = new Usuario(3, "Carlos López", "90102030", "carlos@correo.com");
                    Prestamo prestamo1 = new Prestamo(1, libroP, usuarioP, DateTime.Now.AddDays(-5), 14);
                    Console.WriteLine(prestamo1.ResumenCorto());
                    Console.WriteLine(prestamo1.DetalleCompleto());
                    Console.WriteLine($"Validación Estado: {prestamo1.Estado}");
                    Console.WriteLine($"Validación EstaVencido(): {prestamo1.EstaVencido()}");
                    Console.WriteLine($"Validación DiasTranscurridos(): {prestamo1.DiasTranscurridos()}");
                    Pause(); 
                    break;
                case "3": Console.WriteLine("Mostrando detalle del préstamo..."); Pause(); break;
                case "4": Console.WriteLine("Préstamo marcado como devuelto. Libro disponible."); Pause(); break;
                case "5": Console.WriteLine("Eliminando registro de préstamo..."); Pause(); break;
                case "6": return;
                default: ShowError("Opción inválida."); break;
            }
        }

        static void ShowSearchReportsMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ BÚSQUEDAS Y REPORTES ---");
            Console.WriteLine("1. Buscar libro\n2. Buscar usuario\n3. Reportes\n4. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "1": Console.WriteLine("Buscando libro por título/autor/categoría..."); Pause(); break;
                case "2": Console.WriteLine("Buscando usuario por nombre/documento..."); Pause(); break;
                case "3": Console.WriteLine("Generando reportes (Vencidos / Por usuario / Por libro)..."); Pause(); break;
                case "4": return;
                default: ShowError("Opción inválida."); break;
            }
        }

        static void ShowPersistenceMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ GUARDAR/CARGAR DATOS ---");
            Console.WriteLine("1. Guardar datos\n2. Cargar datos\n3. Reiniciar datos\n4. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "1": Console.WriteLine("Simulando guardado de datos en disco..."); Pause(); break;
                case "2": Console.WriteLine("Simulando carga de datos desde disco..."); Pause(); break;
                case "3": 
                    Console.Write("¿Seguro que desea reiniciar los datos? (S/N): ");
                    if(Console.ReadLine().ToUpper() == "S") Console.WriteLine("Datos reiniciados.");
                    Pause(); 
                    break;
                case "4": return;
                default: ShowError("Opción inválida."); break;
            }
        }

        static void RunEV08Tests() {
            Console.Clear();
            Console.WriteLine("=== 1. COMPARACION ARRAY VS LIST ===");
            
            string[] arrayLibros = new string[2];
            arrayLibros[0] = "Libro A";
            arrayLibros[1] = "Libro B";
            
            List<string> listLibros = new List<string>();
            listLibros.Add("Libro A");
            listLibros.Add("Libro B");
            listLibros.Add("Libro C");

            Console.WriteLine("Array: Tamaño fijo (2). Si intentas agregar un tercero, el programa falla.");
            Console.WriteLine($"List: Tamaño dinámico. Permite agregar sin límite. Elementos actuales: {listLibros.Count}");
            
            Console.WriteLine("\n=== 2. PRUEBA DE SERVICIOS Y KPIs ===");
            LibroService libroService = new LibroService();
            UsuarioService usuarioService = new UsuarioService();
            PrestamoService prestamoService = new PrestamoService();

            Libro l1 = new Libro(1, "El Quijote", "Cervantes", 1605, "Novela");
            Libro l2 = new Libro(2, "Cien Anos de Soledad", "Garcia Marquez", 1967, "Novela");
            l2.Disponible = false;
            libroService.AgregarLibro(l1);
            libroService.AgregarLibro(l2);

            Usuario u1 = new Usuario(1, "Zendaya", "123", "zen@mail.com");
            Usuario u2 = new Usuario(2, "Alberto", "456", "alberto@mail.com");
            u2.Activo = false;
            usuarioService.AgregarUsuario(u1);
            usuarioService.AgregarUsuario(u2);

            Prestamo p1 = new Prestamo(1, l2, u1, DateTime.Now.AddDays(-5), 14);
            Prestamo p2 = new Prestamo(2, l1, u2, DateTime.Now.AddDays(-20), 14);
            p2.Estado = EstadoPrestamo.Vencido;
            prestamoService.AgregarPrestamo(p1);
            prestamoService.AgregarPrestamo(p2);

            Console.WriteLine("\n--- KPIs Libros ---");
            Console.WriteLine($"Total: {libroService.TotalLibros()} | Disponibles: {libroService.LibrosDisponibles()} | Prestados: {libroService.LibrosPrestados()}");
            
            Console.WriteLine("\n--- KPIs Usuarios ---");
            Console.WriteLine($"Total: {usuarioService.TotalUsuarios()} | Activos: {usuarioService.UsuariosActivos()} | Inactivos: {usuarioService.UsuariosInactivos()}");

            Console.WriteLine("\n--- KPIs Prestamos ---");
            Console.WriteLine($"Total: {prestamoService.TotalPrestamos()} | Activos: {prestamoService.PrestamosActivos()} | Vencidos: {prestamoService.PrestamosVencidos()}");
            
            Console.WriteLine("\n--- Ordenacion Usuarios (Por Nombre) ---");
            foreach(var u in usuarioService.OrdenarPorNombre()) {
                Console.WriteLine($"- {u.Nombre}");
            }

            Console.WriteLine("\n--- Busqueda Libros (Criterio: 'Cien') ---");
            foreach(var l in libroService.BuscarLibro("Cien")) {
                Console.WriteLine($"- {l.Titulo}");
            }

            Pause();
        }

        static bool ConfirmExitAndSave() {
            Console.Write("¿Guardar antes de salir? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S") {
                Console.WriteLine("Simulando guardado de datos...");
                Pause();
            }
            return true;
        }

        static void Pause() { 
            Console.WriteLine("\nPresione Enter para continuar..."); 
            Console.ReadLine(); 
        }

        static void ShowError(string m) { 
            Console.WriteLine($"\n[!] {m}"); 
            Pause(); 
        }
    }
}