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
                Console.Write("Seleccione una opción: ");
                string input = Console.ReadLine();
                if (input == "6") exit = true;
            }
        }
        static void Pause() { Console.WriteLine("\nPresione Enter para continuar..."); Console.ReadLine(); }
        static void ShowError(string m) { Console.WriteLine($"\n[!] {m}"); Pause(); }
    }
}