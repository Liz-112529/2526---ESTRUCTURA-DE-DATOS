using System;

// ---------------------------
// Clase Estudiante
// ---------------------------
class Estudiante
{
    public int ID { get; set; }
    public string Nombres { get; set; }
    public string Apellidos { get; set; }
    public string Direccion { get; set; }
    public string[] Telefonos { get; set; }

    public void MostrarDatos()
    {
        Console.WriteLine();
        Console.WriteLine("----- REGISTRO DEL ESTUDIANTE -----");
        Console.WriteLine($"ID: {ID}");
        Console.WriteLine($"Nombres: {Nombres}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.WriteLine("Teléfonos:");
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.WriteLine($"  Teléfono {i + 1}: {Telefonos[i]}");
        }
    }
}

// ---------------------------
// Clase Program (punto de entrada)
// ---------------------------
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");

        Console.Write("Ingrese el ID del estudiante: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese los nombres: ");
        string nombres = Console.ReadLine() ?? "";

        Console.Write("Ingrese los apellidos: ");
        string apellidos = Console.ReadLine() ?? "";

        Console.Write("Ingrese la dirección: ");
        string direccion = Console.ReadLine() ?? "";

        string[] telefonos = new string[3];

        for (int i = 0; i < telefonos.Length; i++)
        {
            Console.Write($"Ingrese el teléfono {i + 1}: ");
            telefonos[i] = Console.ReadLine() ?? "";
        }

        Estudiante estudiante = new Estudiante
        {
            ID = id,
            Nombres = nombres,
            Apellidos = apellidos,
            Direccion = direccion,
            Telefonos = telefonos
        };

        estudiante.MostrarDatos();

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para finalizar...");
        Console.ReadKey();
    }
}
