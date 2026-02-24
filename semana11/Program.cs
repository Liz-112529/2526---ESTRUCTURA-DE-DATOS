using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Diccionario con palabras iniciales (español a inglés)
        Dictionary<string, string> diccionario = new Dictionary<string, string>()
        {
            { "tiempo", "Time" },
            { "persona", "Person" },
            { "año", "Year" },
            { "camino", "Way" },
            { "día", "Day" },
            { "hombre", "Man" },
            { "vida", "Life" },
            { "mujer", "Woman" },
            { "lugar", "Place" },
            { "trabajo", "Work" },
            { "semana", "Week" },
        };

        while (true)
        {
            // Mostrar el menú principal
            Console.WriteLine("\n========MENU PRINCIPAL==========");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Traducir una frase
                    TraducirFrase(diccionario);
                    break;

                case "2":
                    // Agregar palabras al diccionario
                    AgregarPalabra(diccionario);
                    break;

                case "0":
                    // Salir
                    Console.WriteLine("¡Buen trabajo Liz :)!");
                    return;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    // Función para traducir una frase
    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la frase en español: ");
        string frase = Console.ReadLine();
        string[] palabras = frase.Split(' ');

        Console.Write("Traducción esperada (parcial): ");
        foreach (string palabra in palabras)
        {
            // Eliminar signos de puntuación y convertir a minúsculas para normalizar
            string palabraLimpia = palabra.TrimEnd(',', '.', ';', ':', '!', '?').ToLower();

            // Traducir solo si la palabra está en el diccionario
            if (diccionario.ContainsKey(palabraLimpia))
            {
                Console.Write(diccionario[palabraLimpia] + " ");
            }
            else
            {
                // Si la palabra no está en el diccionario, se deja tal cual
                Console.Write(palabra + " ");
            }
        }
        Console.WriteLine(); // Salto de línea
    }

    // Función para agregar palabras al diccionario
    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en español: ");
        string palabraEspanol = Console.ReadLine();

        Console.Write("Ingrese la traducción al inglés: ");
        string palabraIngles = Console.ReadLine();

        // Agregar la palabra al diccionario
        if (!diccionario.ContainsKey(palabraEspanol.ToLower()))
        {
            diccionario.Add(palabraEspanol.ToLower(), palabraIngles);
            Console.WriteLine("Palabra agregada con éxito.");
        }
        else
        {
            Console.WriteLine("La palabra ya existe en el diccionario.");
        }
    }
}