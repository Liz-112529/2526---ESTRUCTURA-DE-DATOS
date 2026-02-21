using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        // Paso 1: Crear los conjuntos ficticios de ciudadanos
        HashSet<int> todosCiudadanos = new HashSet<int>();
        HashSet<int> vacunadosPfizer = new HashSet<int>();
        HashSet<int> vacunadosAstraZeneca = new HashSet<int>();
        HashSet<int> vacunadosAmbasDosis = new HashSet<int>();

        // Generamos los 500 ciudadanos numerados del 1 al 500
        for (int i = 1; i <= 500; i++)
        {
            todosCiudadanos.Add(i);
        }

        // Asignar las vacunas aleatoriamente
        AsignarVacunasAleatorias(todosCiudadanos, vacunadosPfizer, vacunadosAstraZeneca, vacunadosAmbasDosis);

        // Mostrar resultados de vacunación
        MostrarResultados(vacunadosPfizer, vacunadosAstraZeneca, vacunadosAmbasDosis, todosCiudadanos);
    }

    // Función para asignar vacunas aleatoriamente
    static void AsignarVacunasAleatorias(HashSet<int> todosCiudadanos, HashSet<int> vacunadosPfizer, HashSet<int> vacunadosAstraZeneca, HashSet<int> vacunadosAmbasDosis)
    {
        // Limpiar los conjuntos de vacunados
        vacunadosPfizer.Clear();
        vacunadosAstraZeneca.Clear();
        vacunadosAmbasDosis.Clear();

        // Convertir el conjunto a lista para poder ordenarlo aleatoriamente
        var listaCiudadanos = todosCiudadanos.ToList();

        // Asignar 45 ciudadanos a ambas dosis
        var vacunadosAmbasDosisAleatorios = listaCiudadanos.OrderBy(x => random.Next()).Take(45).ToList();
        foreach (var ciudadano in vacunadosAmbasDosisAleatorios)
        {
            vacunadosAmbasDosis.Add(ciudadano);
        }

        // Asignar 75 ciudadanos a Pfizer y AstraZeneca (excluyendo a los que ya tienen ambas dosis)
        var vacunadosPfizerAleatorios = listaCiudadanos.OrderBy(x => random.Next()).Except(vacunadosAmbasDosis).Take(75).ToList();
        foreach (var ciudadano in vacunadosPfizerAleatorios)
        {
            vacunadosPfizer.Add(ciudadano);
        }

        var vacunadosAstraZenecaAleatorios = listaCiudadanos.OrderBy(x => random.Next()).Except(vacunadosAmbasDosis).Except(vacunadosPfizer).Take(75).ToList();
        foreach (var ciudadano in vacunadosAstraZenecaAleatorios)
        {
            vacunadosAstraZeneca.Add(ciudadano);
        }
    }

    // Función para mostrar los resultados de la vacunación
    static void MostrarResultados(HashSet<int> vacunadosPfizer, HashSet<int> vacunadosAstraZeneca, HashSet<int> vacunadosAmbasDosis, HashSet<int> todosCiudadanos)
    {
        // Operaciones de teoría de conjuntos
        var vacunados = vacunadosPfizer.Union(vacunadosAstraZeneca).Union(vacunadosAmbasDosis).ToList();
        var noVacunados = todosCiudadanos.Except(vacunados).ToList();

        // Mostrar resultados
        Console.Clear();
        Console.WriteLine("=== VACUNACIÓN A CIUDADANOS COVID-19 ===");
        Console.WriteLine($"Total ciudadanos: {todosCiudadanos.Count}");
        Console.WriteLine($"Vacunados con Pfizer: {vacunadosPfizer.Count}");
        Console.WriteLine($"Vacunados con AstraZeneca: {vacunadosAstraZeneca.Count}");
        Console.WriteLine($"Vacunados con ambas dosis: {vacunadosAmbasDosis.Count}");
        Console.WriteLine($"Vacunados: {vacunados.Count}");
        Console.WriteLine($"No vacunados: {noVacunados.Count}");

        // Mostrar sección de vacunados con Pfizer
        Console.WriteLine("\n=== Ciudadanos Vacunados con Pfizer ===");
        MostrarLista(vacunadosPfizer);

        // Mostrar sección de vacunados con AstraZeneca
        Console.WriteLine("\n=== Ciudadanos Vacunados con AstraZeneca ===");
        MostrarLista(vacunadosAstraZeneca);

        // Mostrar sección de vacunados con ambas dosis
        Console.WriteLine("\n=== Ciudadanos Vacunados con Ambas Dosis ===");
        MostrarLista(vacunadosAmbasDosis);

        // Mostrar sección de no vacunados
        Console.WriteLine("\n=== Ciudadanos No Vacunados ===");
        MostrarLista(noVacunados);
    }

    // Función para mostrar las listas de ciudadanos en columna de manera aleatoria
    static void MostrarLista(IEnumerable<int> lista)
    {
        // Mostrar cada ciudadano en una línea nueva, aleatorio
        foreach (var ciudadano in lista.OrderBy(x => random.Next()))
        {
            Console.WriteLine($"Ciudadano {ciudadano:000}");
        }
    }
}