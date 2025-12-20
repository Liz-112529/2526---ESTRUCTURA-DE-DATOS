using System;

public class AgendaTurnos
{
    private Paciente[] pacientes;
    private int contador;

    private readonly string[] dias = { "Lunes", "Martes", "Miercoles", "Jueves", "Viernes" };
    private readonly string[] horas = { "07:00", "09:00", "11:00", "13:00", "15:00" };

    // MATRIZ: true = libre, false = ocupado
    private bool[,] disponibilidad;

    public AgendaTurnos(int capacidad)
    {
        pacientes = new Paciente[capacidad];
        contador = 0;

        disponibilidad = new bool[dias.Length, horas.Length];
        for (int i = 0; i < dias.Length; i++)
            for (int j = 0; j < horas.Length; j++)
                disponibilidad[i, j] = true;
    }

    public void MostrarCatalogoTurnos()
    {
        Console.WriteLine("\nTURNOS DISPONIBLES (Días y Horas válidas):");
        Console.WriteLine("Días:  " + string.Join(", ", dias));
        Console.WriteLine("Horas: " + string.Join(", ", horas));
    }

    private int IndexDia(string dia) => Array.IndexOf(dias, dia);
    private int IndexHora(string hora) => Array.IndexOf(horas, hora);

    public bool AgregarTurno(string nombre, string cedula, string dia, string hora, string especialidad, string observacion)
    {
        if (contador >= pacientes.Length)
        {
            Console.WriteLine("Agenda llena.");
            return false;
        }

        if (ExisteCedula(cedula))
        {
            Console.WriteLine("Ya existe un paciente registrado con esa cédula.");
            return false;
        }

        int d = IndexDia(dia);
        int h = IndexHora(hora);

        if (d == -1 || h == -1)
        {
            Console.WriteLine("Día u hora inválidos. Verifica el catálogo.");
            return false;
        }

        if (!disponibilidad[d, h])
        {
            Console.WriteLine("Ese turno ya está ocupado. Elige otro.");
            return false;
        }

        // Reservar el slot
        disponibilidad[d, h] = false;

        Turno t = new Turno(dia, hora, especialidad, observacion);
        Paciente p = new Paciente(nombre, cedula, t);

        pacientes[contador++] = p;
        Console.WriteLine("Turno ingresado con éxito.");
        return true;
    }

    public void ListarPacientes()
    {
        Console.WriteLine("\nLISTADO DE PACIENTES AGENDADOS:");
        Console.WriteLine($"{"Nombre",-22}| {"Cédula",-10}| {"Turno",-17}| {"Especialidad",-18}| Observación");
        Console.WriteLine(new string('-', 85));

        if (contador == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        for (int i = 0; i < contador; i++)
            pacientes[i].Mostrar();
    }

    public void MostrarDisponibilidad()
    {
        Console.WriteLine("\nDISPONIBILIDAD (Libre/Ocupado):");
        Console.Write("Día/Hora".PadRight(12));
        foreach (var h in horas) Console.Write(h.PadRight(10));
        Console.WriteLine();

        for (int i = 0; i < dias.Length; i++)
        {
            Console.Write(dias[i].PadRight(12));
            for (int j = 0; j < horas.Length; j++)
            {
                Console.Write((disponibilidad[i, j] ? "Libre" : "Ocupado").PadRight(10));
            }
            Console.WriteLine();
        }
    }

    public void BuscarPorCedula(string cedula)
    {
        Console.WriteLine($"\nBÚSQUEDA POR CÉDULA: {cedula}");
        for (int i = 0; i < contador; i++)
        {
            if (pacientes[i].Cedula == cedula)
            {
                Console.WriteLine($"{"Nombre",-22}| {"Cédula",-10}| {"Turno",-17}| {"Especialidad",-18}| Observación");
                Console.WriteLine(new string('-', 85));
                pacientes[i].Mostrar();
                return;
            }
        }
        Console.WriteLine("No se encontró un paciente con esa cédula.");
    }

    private bool ExisteCedula(string cedula)
    {
        for (int i = 0; i < contador; i++)
            if (pacientes[i].Cedula == cedula) return true;
        return false;
    }

    public void EliminarCita(string cedula)
{
    for (int i = 0; i < contador; i++)
    {
        if (pacientes[i].Cedula == cedula)
        {
            // Liberar el turno en la matriz de disponibilidad
            int d = Array.IndexOf(dias, pacientes[i].TurnoAsignado.Dia);
            int h = Array.IndexOf(horas, pacientes[i].TurnoAsignado.Hora);

            if (d != -1 && h != -1)
                disponibilidad[d, h] = true;

            // Reordenar el arreglo (eliminar paciente)
            for (int j = i; j < contador - 1; j++)
                pacientes[j] = pacientes[j + 1];

            pacientes[contador - 1] = null!;
            contador--;

            Console.WriteLine("Cita eliminada correctamente.");
            return;
        }
    }

    Console.WriteLine("No se encontró una cita con esa cédula.");
}

}
