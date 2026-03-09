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
                    case "6": exit = true; break;
                }
            }
        }

        static void ShowBooksMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ LIBROS ---");
            Console.WriteLine("1. Registrar libro\n2. Listar libros\n3. Ver detalle\n4. Actualizar libro\n5. Eliminar libro\n6. Volver");
            Pause();
        }
        static void ShowUsersMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ USUARIOS ---");
            Console.WriteLine("1. Registrar usuario\n2. Listar usuarios\n3. Ver detalle\n4. Actualizar usuario\n5. Eliminar usuario\n6. Volver");
            Pause();
        }
        static void ShowLoansMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ PRÉSTAMOS ---");
            Console.WriteLine("1. Crear préstamo\n2. Listar préstamos\n3. Ver detalle\n4. Registrar devolución\n5. Eliminar préstamo\n6. Volver");
            Pause();
        }
        static void ShowSearchReportsMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ BÚSQUEDAS Y REPORTES ---");
            Console.WriteLine("1. Buscar libro\n2. Buscar usuario\n3. Reportes\n4. Volver");
            Pause();
        }

        static void Pause() { Console.WriteLine("\nPresione Enter para continuar..."); Console.ReadLine(); }
        static void ShowError(string m) { Console.WriteLine($"\n[!] {m}"); Pause(); }
    }
}