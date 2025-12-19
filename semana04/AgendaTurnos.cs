using System;

public class AgendaTurnos
{
    private Paciente[] pacientes;
    private int contador;

    public AgendaTurnos(int capacidad)
    {
        pacientes = new Paciente[capacidad];
        contador = 0;
    }

    public void AgregarTurno(Paciente p)
    {
        if (contador < pacientes.Length)
        {
            pacientes[contador++] = p;
            Console.WriteLine("Turno ingresado con éxito.");
        }
        else
        {
            Console.WriteLine("Agenda llena.");
        }
    }

    public void MostrarTurnos()
    {
        Console.WriteLine("\nAGENDA DE TURNOS:");
        Console.WriteLine("Tipo           | Nombre               | CEDULA     | Turno");
        Console.WriteLine("_______________|______________________|____________|____________");

        for (int i = 0; i < contador; i++)
        {
            pacientes[i].Mostrar();
        }
    }
}
