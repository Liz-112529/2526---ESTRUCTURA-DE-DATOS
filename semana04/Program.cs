using System;

class Program
{
    static void Main(string[] args)
    {
        AgendaTurnos agenda = new AgendaTurnos(5);

        Turno t1 = new Turno("Lunes", "07:00", "Ginecología", "Control");
        Turno t2 = new Turno("Martes", "13:00", "Medicina General", "Primera vez");
        Turno t3 = new Turno("Viernes", "09:00", "Psicología", "Control");

        Paciente p1 = new Paciente("Magdalena Cantos", "0929087651", t1);
        Paciente p2 = new Paciente("Carlos López", "0951256789", t2);
        Paciente p3 = new Paciente("Nathaly Méndez", "0951213005", t3);

        agenda.AgregarTurno(p1);
        agenda.AgregarTurno(p2);
        agenda.AgregarTurno(p3);

        agenda.MostrarTurnos();

        Console.ReadKey();
    }
}
