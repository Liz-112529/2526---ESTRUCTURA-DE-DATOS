#pragma warning disable CS8604, CS8600, CS8602, CS1593

using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.Clear();
            Console.WriteLine("MENÚ PRINCIPAL");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("1. Ejercicio 1: Asignaturas del curso");
            Console.WriteLine("2. Ejercicio 2: Números ganadores de la lotería");
            Console.WriteLine("3. Ejercicio 3: Eliminar letras en posiciones múltiplos de 3");
            Console.WriteLine("4. Ejercicio 4: Contar vocales de una palabra");
            Console.WriteLine("5. Ejercicio 5: Media y desviación típica");
            Console.WriteLine("6. Salir");
            Console.WriteLine("--------------------------------------------------");
            Console.Write("Elige una opción (1-6): ");

            if (int.TryParse(Console.ReadLine(), out int opcion))
            {
                Console.Clear();
                switch (opcion)
                {
                    case 1: Ejercicio1(); break;
                    case 2: Ejercicio2(); break;
                    case 3: Ejercicio3(); break;
                    case 4: Ejercicio4(); break;
                    case 5: Ejercicio5(); break;
                    case 6: continuar = false; break;
                    default: Console.WriteLine("Opción no válida."); break;
                }
            }
            else
            {
                Console.WriteLine("Entrada inválida.");
            }

            if (continuar)
            {
                Console.WriteLine("\nPresiona cualquier tecla para volver al menú...");
                Console.ReadKey();
            }
        }
    }

    // EJERCICIO 1
    static void Ejercicio1()
    {
        Console.WriteLine("EJERCICIO 1");
        Console.WriteLine("Escribir un programa que almacene las asignaturas de un curso (por ejemplo Matemáticas, Física, Química, Historia y Lengua) en una lista\n");

        List<string> asignaturas = new List<string>
        {
            "Matemáticas", "Física", "Química", "Historia", "Lengua"
        };

        foreach (string asignatura in asignaturas)
        {
            Console.WriteLine(asignatura);
        }
    }

    // EJERCICIO 2
    static void Ejercicio2()
    {
        Console.WriteLine("EJERCICIO 2");
        Console.WriteLine("Escribir un programa que pregunte al usuario los números ganadores de la lotería primitiva, los almacene en una lista\n");

        string input = Console.ReadLine();
        List<int> numeros = input.Split(',').Select(int.Parse).ToList();

        numeros.Sort();

        Console.WriteLine("\nNúmeros ordenados de menor a mayor:");
        foreach (int num in numeros)
        {
            Console.WriteLine(num);
        }
    }

    // EJERCICIO 3
    static void Ejercicio3()
    {
        Console.WriteLine("EJERCICIO 3");
        Console.WriteLine("Escribir un programa que almacene el abecedario en una lista, elimine de la lista las letras que ocupen posiciones múltiplos de 3,\n");

        List<char> abecedario = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToList();

        for (int i = abecedario.Count - 1; i >= 0; i--)
        {
            if ((i + 1) % 3 == 0)
            {
                abecedario.RemoveAt(i);
            }
        }

        Console.WriteLine("Resultado:");
        Console.WriteLine(new string(abecedario.ToArray()));
    }

    // EJERCICIO 4 (NUEVO)
    static void Ejercicio4()
    {
        Console.WriteLine("EJERCICIO 4");
        Console.WriteLine("Escribir un programa que pida al usuario una palabra y muestre por pantalla el número de veces que contiene cada vocal.\n");

        Console.Write("Introduce una palabra: ");
        string palabra = Console.ReadLine().ToLower();

        int a = palabra.Count(c => c == 'a');
        int e = palabra.Count(c => c == 'e');
        int i = palabra.Count(c => c == 'i');
        int o = palabra.Count(c => c == 'o');
        int u = palabra.Count(c => c == 'u');

        Console.WriteLine("\nNúmero de vocales:");
        Console.WriteLine($"A: {a}");
        Console.WriteLine($"E: {e}");
        Console.WriteLine($"I: {i}");
        Console.WriteLine($"O: {o}");
        Console.WriteLine($"U: {u}");
    }

    // EJERCICIO 5
    static void Ejercicio5()
    {
        Console.WriteLine("EJERCICIO 5");
        Console.WriteLine("Escribir un programa que pregunte por una muestra de números, separados por comas, los guarde en una lista y muestre por pantalla su media y desviación típica.\n");

        Console.Write("Introduce números separados por comas: ");
        string input = Console.ReadLine();

        List<double> numeros = input.Split(',').Select(double.Parse).ToList();

        double media = numeros.Average();
        double desviacion = Math.Sqrt(numeros.Select(n => Math.Pow(n - media, 2)).Average());

        Console.WriteLine($"\nMedia: {media:F2}");
        Console.WriteLine($"Desviación típica: {desviacion:F2}");
    }
}
