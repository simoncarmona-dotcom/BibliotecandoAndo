using System;
namespace BibliotecandoAndo {
    class Program {
        static void Main(string[] args) { ShowMainMenu(); }

        static void ShowMainMenu() {
            bool exit = false;
            while (!exit) {
                Console.Clear();
                Console.WriteLine("=== SISTEMA BIBLIOTECANDO ANDO ===");
                Console.WriteLine("1. Libros\n2. Usuarios\n3. Préstamos\n4. Búsquedas y reportes\n5. Guardar/Cargar\n6. Salir");
                Console.Write("Opción: ");
                switch (Console.ReadLine()) {
                    case "1": ShowBooksMenu(); break;
                    case "2": ShowUsersMenu(); break;
                    case "3": ShowLoansMenu(); break;
                    case "4": ShowSearchReportsMenu(); break;
                    case "5": ShowPersistenceMenu(); break;
                    case "6": exit = ConfirmExitAndSave(); break;
                }
            }
        }

       static void ShowBooksMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ LIBROS ---");
            Console.WriteLine("1. Registrar libro\n2. Listar libros\n3. Ver detalle\n4. Actualizar libro\n5. Eliminar libro\n6. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "1": Console.WriteLine("Registrando nuevo libro..."); Pause(); break;
                case "2": Console.WriteLine("Listando libros (Todos / Disponibles / Prestados)..."); Pause(); break;
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
            Console.WriteLine("1. Registrar usuario\n2. Listar usuarios\n3. Ver detalle\n4. Actualizar usuario\n5. Eliminar usuario\n6. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "1": Console.WriteLine("Registrando nuevo usuario..."); Pause(); break;
                case "2": Console.WriteLine("Listando todos los usuarios..."); Pause(); break;
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
            Console.WriteLine("1. Crear préstamo\n2. Listar préstamos\n3. Ver detalle\n4. Registrar devolución\n5. Eliminar préstamo\n6. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "1": Console.WriteLine("Validaciones: Verificar usuario activo y libro disponible. Creando préstamo..."); Pause(); break;
                case "2": Console.WriteLine("Listando préstamos (Todos / Activos / Cerrados)..."); Pause(); break;
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

        static void Pause() { Console.WriteLine("\nPresione Enter para continuar..."); Console.ReadLine(); }
        static void ShowError(string m) { Console.WriteLine($"\n[!] {m}"); Pause(); }

        static bool ConfirmExitAndSave() {
            Console.Write("¿Guardar antes de salir? (S/N): ");
            if (Console.ReadLine().ToUpper() == "S") {
                Console.WriteLine("Simulando guardado de datos...");
                Pause();
            }
            return true;
        }
    }
}