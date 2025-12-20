using System;

public class Paciente
{
    public string Nombre { get; set; }
    public string Cedula { get; set; }
    public Turno TurnoAsignado { get; set; }

    public Paciente(string nombre, string cedula, Turno turno)
    {
        Nombre = nombre;
        Cedula = cedula;
        TurnoAsignado = turno;
    }

    public void Mostrar()
    {
        Console.WriteLine($"{Nombre,-22}| {Cedula,-10}| {TurnoAsignado.Dia,-10} {TurnoAsignado.Hora,-6}| {TurnoAsignado.Especialidad,-18}| {TurnoAsignado.Observacion}");
    }
}
