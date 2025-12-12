// ---------------------------
// Clase Estudiante
// ---------------------------
// Esta clase modela los datos de un estudiante y su comportamiento.
class Estudiante
{
    // Propiedades del estudiante con métodos automáticos de lectura/escritura.
    private int ID { get; set; }
    private string Nombres { get; set; }
    private string Apellidos { get; set; }
    public string Direccion { get; set; }

    // Array que almacenará los tres números de teléfono.
    private string[] Telefonos { get; set; }

    public Estudiante(int ID, string Nombres, string Apellidos, string Direccion, string[] Telefonos)
    {
        this.ID = ID;
        this.Nombres = Nombres;
        this.Apellidos = Apellidos;
        this.Direccion = Direccion;
        this.Telefonos = Telefonos;
    }


    // Método que muestra en pantalla todos los datos del estudiante.
    public void MostrarDatos()
    {
        Console.WriteLine();
        Console.WriteLine("----- REGISTRO DEL ESTUDIANTE -----");

        // Se imprimen los valores almacenados en las propiedades del objeto.
        Console.WriteLine($"ID: {this.ID}");
        Console.WriteLine($"Nombres: {this.Nombres}");
        Console.WriteLine($"Apellidos: {this.Apellidos}");
        Console.WriteLine($"Dirección: {this.Direccion}");
        Console.WriteLine("Teléfonos:");

        // Se recorre el array de teléfonos para imprimirlos uno por uno.
        for (int i = 0; i < this.Telefonos.Length; i++)
        {
            Console.WriteLine($"  Teléfono {i + 1}: {this.Telefonos[i]}");
        }
    }
}

// ---------------------------
// Clase Program (punto de entrada del programa)
// ---------------------------
// Contiene el método Main donde inicia la ejecución del programa.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== REGISTRO DE ESTUDIANTE ===");

        // Solicita al usuario los datos básicos del estudiante.
        Console.Write("Ingrese el ID del estudiante: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Ingrese los nombres: ");
        string nombres = Console.ReadLine() ?? "";

        Console.Write("Ingrese los apellidos: ");
        string apellidos = Console.ReadLine() ?? "";

        Console.Write("Ingrese la dirección: ");
        string direccion = Console.ReadLine() ?? "";

        // Se crea un arreglo de tres posiciones para los teléfonos.
        string[] telefonos = new string[3];

        // Bucle que captura cada teléfono ingresado por el usuario.
        for (int i = 0; i < telefonos.Length; i++)
        {
            Console.Write($"Ingrese el teléfono {i + 1}: ");
            telefonos[i] = Console.ReadLine() ?? "";
        }

        // Se crea un objeto Estudiante con los valores recogidos.
        Estudiante estudiante = new Estudiante(id, nombres, apellidos, direccion, telefonos);

        // Se llama al método para mostrar los datos del estudiante.
        estudiante.MostrarDatos();

        Console.WriteLine();
        Console.WriteLine("Presione una tecla para finalizar...");
        Console.ReadKey();  // Espera para que la ventana no se cierre de inmediato.
    }
}
