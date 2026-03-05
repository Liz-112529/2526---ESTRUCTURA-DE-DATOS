using System;
using System.Collections.Generic;

class Libro
{
    public string ISBN;
    public string Titulo;
    public string Autor;
    public int Anio;

    public Libro(string isbn, string titulo, string autor, int anio)
    {
        ISBN = isbn;
        Titulo = titulo;
        Autor = autor;
        Anio = anio;
    }
}

class Program
{
    static Dictionary<string, Libro> biblioteca = new Dictionary<string, Libro>();
    static HashSet<string> conjuntoISBN = new HashSet<string>();

    static void Main(string[] args)
    {
        int opcion;

        do
        {
            Console.WriteLine("\n===== SISTEMA DE REGISTRO DE LIBROS =====");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Consultar libro por ISBN");
            Console.WriteLine("3. Mostrar todos los libros (Reportería)");
            Console.WriteLine("4. Eliminar libro");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarLibro();
                    break;

                case 2:
                    ConsultarLibro();
                    break;

                case 3:
                    Reporteria();
                    break;

                case 4:
                    EliminarLibro();
                    break;

                case 5:
                    Console.WriteLine("Saliendo del sistema by Liz :)...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 5);
    }

    static void RegistrarLibro()
    {
        Console.Write("Ingrese ISBN: ");
        string isbn = Console.ReadLine();

        if (conjuntoISBN.Contains(isbn))
        {
            Console.WriteLine("El libro ya está registrado.");
            return;
        }

        Console.Write("Ingrese título: ");
        string titulo = Console.ReadLine();

        Console.Write("Ingrese autor: ");
        string autor = Console.ReadLine();

        Console.Write("Ingrese año de publicación: ");
        int anio = Convert.ToInt32(Console.ReadLine());

        Libro nuevoLibro = new Libro(isbn, titulo, autor, anio);

        biblioteca.Add(isbn, nuevoLibro);
        conjuntoISBN.Add(isbn);

        Console.WriteLine("Libro registrado correctamente.");
    }

    static void ConsultarLibro()
    {
        Console.Write("Ingrese el ISBN del libro: ");
        string isbn = Console.ReadLine();

        if (biblioteca.ContainsKey(isbn))
        {
            Libro libro = biblioteca[isbn];

            Console.WriteLine("\nLibro encontrado:");
            Console.WriteLine("ISBN: " + libro.ISBN);
            Console.WriteLine("Título: " + libro.Titulo);
            Console.WriteLine("Autor: " + libro.Autor);
            Console.WriteLine("Año: " + libro.Anio);
        }
        else
        {
            Console.WriteLine("El libro no se encuentra registrado.");
        }
    }

    static void Reporteria()
    {
        Console.WriteLine("\n===== REPORTERÍA DE LIBROS =====");

        if (biblioteca.Count == 0)
        {
            Console.WriteLine("No hay libros registrados.");
            return;
        }

        foreach (var item in biblioteca)
        {
            Libro libro = item.Value;

            Console.WriteLine("-----------------------------");
            Console.WriteLine("ISBN: " + libro.ISBN);
            Console.WriteLine("Título: " + libro.Titulo);
            Console.WriteLine("Autor: " + libro.Autor);
            Console.WriteLine("Año: " + libro.Anio);
        }
    }

    static void EliminarLibro()
    {
        Console.Write("Ingrese ISBN del libro a eliminar: ");
        string isbn = Console.ReadLine();

        if (biblioteca.ContainsKey(isbn))
        {
            biblioteca.Remove(isbn);
            conjuntoISBN.Remove(isbn);

            Console.WriteLine("Libro eliminado correctamente.");
        }
        else
        {
            Console.WriteLine("El libro no existe.");
        }
    }
}