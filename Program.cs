using System;
using System.Collections.Generic;
using BibliotecandoAndo.Models;
using BibliotecandoAndo.Services;

namespace BibliotecandoAndo {
    class Program {
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
                Console.WriteLine("3. Ver detalle\n4. Actualizar libro");
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
                        Console.WriteLine("\n¡Libro agregado con éxito!"); 
                        Pause(); 
                        break;
                    case "2": 
                        Console.WriteLine("\n--- LISTA DE LIBROS REGISTRADOS ---");
                        var listaLibros = libroService.ObtenerTodos();
                        if(listaLibros.Count == 0) Console.WriteLine("No hay libros.");
                        else foreach(var l in listaLibros) Console.WriteLine($"- ID: {l.Id} | Título: {l.Titulo} | Autor: {l.Autor}");
                        Pause(); 
                        break;
                    case "3": Console.WriteLine("En construcción..."); Pause(); break;
                    case "4": Console.WriteLine("En construcción..."); Pause(); break;
                    case "5": 
                        Console.WriteLine("\n--- ELIMINAR LIBRO ---");
                        Console.Write("Ingrese Título o ID a eliminar: ");
                        var librosEncontrados = libroService.BuscarLibro(Console.ReadLine());
                        if(librosEncontrados.Count > 0) {
                            libroService.EliminarLibro(librosEncontrados[0]);
                            Console.WriteLine($"Libro '{librosEncontrados[0].Titulo}' eliminado.");
                        } else Console.WriteLine("No encontrado.");
                        Pause(); 
                        break;
                    case "6": back = true; break;
                    default: ShowError("Opción inválida."); break;
                }
            }
        }

        static void ShowUsersMenu() {
            bool back = false;
            while (!back) {
                Console.Clear();
                Console.WriteLine("--- MENÚ USUARIOS ---");
                Console.WriteLine("1. Registrar usuario (Add)");
                Console.WriteLine("2. Listar usuarios (Obtener Todos)");
                Console.WriteLine("3. Ver detalle\n4. Actualizar usuario");
                Console.WriteLine("5. Eliminar usuario (Remove)");
                Console.WriteLine("6. Volver");
                Console.Write("Opción: ");
                
                switch (Console.ReadLine()) {
                    case "1": 
                        Console.WriteLine("\n--- REGISTRAR NUEVO USUARIO ---");
                        Console.Write("ID del Usuario: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Documento: ");
                        string documento = Console.ReadLine();
                        Console.Write("Correo: ");
                        string correo = Console.ReadLine();

                        Usuario nuevoUsuario = new Usuario(id, nombre, documento, correo);
                        usuarioService.AgregarUsuario(nuevoUsuario);
                        Console.WriteLine("\n¡Usuario agregado con éxito!"); 
                        Pause(); 
                        break;
                    case "2": 
                        Console.WriteLine("\n--- LISTA DE USUARIOS REGISTRADOS ---");
                        var listaUsuarios = usuarioService.ObtenerTodos();
                        if(listaUsuarios.Count == 0) Console.WriteLine("No hay usuarios.");
                        else foreach(var u in listaUsuarios) Console.WriteLine($"- ID: {u.Id} | Nombre: {u.Nombre} | Doc: {u.Documento}");
                        Pause(); 
                        break;
                    case "3": Console.WriteLine("En construcción..."); Pause(); break;
                    case "4": Console.WriteLine("En construcción..."); Pause(); break;
                    case "5": 
                        Console.WriteLine("\n--- ELIMINAR USUARIO ---");
                        Console.Write("Ingrese Nombre o Documento a eliminar: ");
                        var usuariosEncontrados = usuarioService.BuscarUsuario(Console.ReadLine());
                        if(usuariosEncontrados.Count > 0) {
                            usuarioService.EliminarUsuario(usuariosEncontrados[0]);
                            Console.WriteLine($"Usuario '{usuariosEncontrados[0].Nombre}' eliminado.");
                        } else Console.WriteLine("No encontrado.");
                        Pause(); 
                        break;
                    case "6": back = true; break;
                    default: ShowError("Opción inválida."); break;
                }
            }
        }

        static void ShowLoansMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ PRÉSTAMOS ---\n6. Volver");
            Console.Write("Opción: ");
            if(Console.ReadLine() == "6") return;
        }

        static void ShowSearchReportsMenu() {
            bool back = false;
            while(!back) {
                Console.Clear();
                Console.WriteLine("--- MENÚ BÚSQUEDAS ---");
                Console.WriteLine("1. Buscar libro");
                Console.WriteLine("2. Buscar usuario");
                Console.WriteLine("3. Volver");
                Console.Write("Opción: ");
                switch (Console.ReadLine()) {
                    case "1": 
                        Console.Write("\nIngrese título, autor o ID: ");
                        var resLibros = libroService.BuscarLibro(Console.ReadLine());
                        if(resLibros.Count == 0) Console.WriteLine("Sin resultados.");
                        else foreach(var l in resLibros) Console.WriteLine($"- {l.Titulo}");
                        Pause(); 
                        break;
                    case "2": 
                        Console.Write("\nIngrese nombre o documento: ");
                        var resUsuarios = usuarioService.BuscarUsuario(Console.ReadLine());
                        if(resUsuarios.Count == 0) Console.WriteLine("Sin resultados.");
                        else foreach(var u in resUsuarios) Console.WriteLine($"- {u.Nombre}");
                        Pause(); 
                        break;
                    case "3": back = true; break;
                    default: ShowError("Opción inválida."); break;
                }
            }
        }

        static void ShowPersistenceMenu() {
            Console.Clear();
            Console.WriteLine("--- MENÚ GUARDAR/CARGAR ---\n4. Volver");
            Console.Write("Opción: ");
            if(Console.ReadLine() == "4") return;
        }

        static void RunEV08Tests() {
            Console.Clear();
            Console.WriteLine("=== PRUEBA DE KPIs Y ARRAYS VS LIST ===");
            Console.WriteLine("Array: Tamaño fijo (2). Si intentas agregar un tercero, falla.");
            Console.WriteLine("List: Tamaño dinámico. Permite agregar sin límite.");
            Console.WriteLine($"\nTotal libros en memoria: {libroService.TotalLibros()}");
            Console.WriteLine($"Total usuarios en memoria: {usuarioService.TotalUsuarios()}");
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