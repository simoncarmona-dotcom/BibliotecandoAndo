using System;
using System.Collections.Generic;
using BibliotecandoAndo.Models;
using BibliotecandoAndo.Services;

namespace BibliotecandoAndo {
    class Program {
        // Instancias globales de los servicios para que conserven la memoria
        static LibroService libroService = new LibroService();
        static UsuarioService usuarioService = new UsuarioService();
        static PrestamoService prestamoService = new PrestamoService();

        static void Main(string[] args) {
            ShowMainMenu();
        }

        static void ShowMainMenu() {
            bool exit = false;
            while (!exit) {
                Console.Clear();
                Console.WriteLine("=== SISTEMA BIBLIOTECANDO ANDO ===");
                Console.WriteLine("1. Libros\n2. Usuarios\n3. Préstamos\n4. Búsquedas y reportes\n5. Guardar/Cargar\n6. Pruebas EV08 (Servicios, KPIs)\n7. Salir");
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
            bool back = false;
            while (!back) {
                Console.Clear();
                Console.WriteLine("--- MENÚ LIBROS ---");
                Console.WriteLine("1. Registrar libro (Add)");
                Console.WriteLine("2. Listar libros (Obtener Todos)");
                Console.WriteLine("3. Ver detalle");
                Console.WriteLine("4. Actualizar libro");
                Console.WriteLine("5. Eliminar libro (Remove)");
                Console.WriteLine("6. Volver");
                Console.Write("Opción: ");
                
                switch (Console.ReadLine()) {
                    case "1": 
                        Console.WriteLine("\n--- REGISTRAR NUEVO LIBRO ---");
                        Console.Write("ID del Libro: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        Console.Write("Año de publicación: ");
                        int anio = int.Parse(Console.ReadLine());
                        Console.Write("Categoría: ");
                        string categoria = Console.ReadLine();

                        Libro nuevoLibro = new Libro(id, titulo, autor, anio, categoria);
                        libroService.AgregarLibro(nuevoLibro);
                        Console.WriteLine("\n¡Libro agregado con éxito a la lista!"); 
                        Pause(); 
                        break;
                    case "2": 
                        Console.WriteLine("\n--- LISTA DE LIBROS REGISTRADOS ---");
                        var listaLibros = libroService.ObtenerTodos();
                        if(listaLibros.Count == 0) {
                            Console.WriteLine("No hay libros en el sistema.");
                        } else {
                            foreach(var l in listaLibros) {
                                Console.WriteLine($"- ID: {l.Id} | Título: {l.Titulo} | Autor: {l.Autor} | Disponible: {l.Disponible}");
                            }
                        }
                        Pause(); 
                        break;
                    case "3": Console.WriteLine("Mostrando detalle del libro..."); Pause(); break;
                    case "4": Console.WriteLine("Actualizando datos del libro..."); Pause(); break;
                    case "5": 
                        Console.WriteLine("\n--- ELIMINAR LIBRO ---");
                        Console.Write("Ingrese el ID o Título del libro a eliminar: ");
                        string buscarEliminar = Console.ReadLine();
                        var librosEncontrados = libroService.BuscarLibro(buscarEliminar);
                        
                        if(librosEncontrados.Count > 0) {
                            libroService.EliminarLibro(librosEncontrados[0]);
                            Console.WriteLine($"El libro '{librosEncontrados[0].Titulo}' ha sido eliminado.");
                        } else {
                            Console.WriteLine("No se encontró ningún libro con ese criterio.");
                        }
                        Pause(); 
                        break;
                    case "6": back = true; break;
                    default: ShowError("Opción inválida."); break;
                }
            }
        }

        static void ShowUsersMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ USUARIOS ---");
            Console.WriteLine("1. Registrar usuario\n2. Listar usuarios\n3. Ver detalle\n4. Actualizar usuario\n5. Eliminar usuario\n6. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "6": return;
                default: Console.WriteLine("Funcionalidad en construcción..."); Pause(); break;
            }
        }

        static void ShowLoansMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ PRÉSTAMOS ---");
            Console.WriteLine("1. Crear préstamo\n2. Listar préstamos\n3. Ver detalle\n4. Registrar devolución\n5. Eliminar préstamo\n6. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "6": return;
                default: Console.WriteLine("Funcionalidad en construcción..."); Pause(); break;
            }
        }

        static void ShowSearchReportsMenu() {
            bool back = false;
            while(!back) {
                Console.Clear();
                Console.WriteLine("--- MENÚ BÚSQUEDAS Y REPORTES ---");
                Console.WriteLine("1. Buscar libro por criterio (Search)");
                Console.WriteLine("2. Buscar usuario");
                Console.WriteLine("3. Reportes");
                Console.WriteLine("4. Volver");
                Console.Write("Opción: ");
                switch (Console.ReadLine()) {
                    case "1": 
                        Console.WriteLine("\n--- BUSCAR LIBRO ---");
                        Console.Write("Ingrese título, autor o ID a buscar: ");
                        string criterio = Console.ReadLine();
                        var resultados = libroService.BuscarLibro(criterio);
                        
                        if(resultados.Count == 0) {
                            Console.WriteLine("No se encontraron coincidencias.");
                        } else {
                            Console.WriteLine("\nResultados encontrados:");
                            foreach(var l in resultados) {
                                Console.WriteLine($"- {l.Titulo} (Autor: {l.Autor})");
                            }
                        }
                        Pause(); 
                        break;
                    case "2": Console.WriteLine("Buscando usuario por nombre/documento..."); Pause(); break;
                    case "3": Console.WriteLine("Generando reportes..."); Pause(); break;
                    case "4": back = true; break;
                    default: ShowError("Opción inválida."); break;
                }
            }
        }

        static void ShowPersistenceMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ GUARDAR/CARGAR DATOS ---");
            Console.WriteLine("1. Guardar datos\n2. Cargar datos\n3. Reiniciar datos\n4. Volver");
            Console.Write("Opción: ");
            switch (Console.ReadLine()) {
                case "4": return;
                default: Console.WriteLine("Funcionalidad en construcción..."); Pause(); break;
            }
        }

        static void RunEV08Tests() {
            Console.Clear();
            Console.WriteLine("=== PRUEBA DE KPIs Y ARRAYS VS LIST ===");
            
            string[] arrayLibros = new string[2];
            arrayLibros[0] = "Libro A";
            arrayLibros[1] = "Libro B";
            
            List<string> listLibros = new List<string>();
            listLibros.Add("Libro A");
            listLibros.Add("Libro B");
            listLibros.Add("Libro C");

            Console.WriteLine("Array: Tamaño fijo (2). Si intentas agregar un tercero, falla.");
            Console.WriteLine($"List: Tamaño dinámico. Permite agregar sin límite. Elementos: {listLibros.Count}");
            
            Console.WriteLine($"\nTotal libros en memoria interactiva: {libroService.TotalLibros()}");
            Pause();
        }

        static bool ConfirmExitAndSave() {
            Console.Write("¿Seguro que desea salir? (S/N): ");
            return Console.ReadLine().ToUpper() == "S";
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