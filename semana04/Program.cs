using System;

class Program
{
    static void Main()
    {
        AgendaTurnos agenda = new AgendaTurnos(20);

        int opcion;
        do
        {
            Console.WriteLine("\n===== MENÚ AGENDA DE TURNOS =====");
            Console.WriteLine("1. Ingresar paciente (Agendar turno)");
            Console.WriteLine("2. Listar pacientes");
            Console.WriteLine("3. Ver disponibilidad (Libre/Ocupado)");
            Console.WriteLine("4. Buscar paciente por cédula");
            Console.WriteLine("5. Eliminar cita");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine() ?? "";

                    Console.Write("Cédula: ");
                    string cedula = Console.ReadLine() ?? "";

                    Console.Write("Día (Lunes/Martes/Miercoles/Jueves/Viernes): ");
                    string dia = Console.ReadLine() ?? "";

                    Console.Write("Hora (07:00/09:00/11:00/13:00/15:00): ");
                    string hora = Console.ReadLine() ?? "";

                    Console.Write("Especialidad: ");
                    string esp = Console.ReadLine() ?? "";

                    Console.Write("Observación: ");
                    string obs = Console.ReadLine() ?? "";

                    agenda.AgregarTurno(nombre.Trim(), cedula.Trim(), dia.Trim(), hora.Trim(), esp.Trim(), obs.Trim());
                    break;

                case 2:
                    agenda.ListarPacientes();
                    break;

                case 3:
                    agenda.MostrarDisponibilidad();
                    break;

                case 4:
                    Console.Write("Ingrese cédula a buscar: ");
                    string buscarCedula = Console.ReadLine() ?? "";
                    agenda.BuscarPorCedula(buscarCedula.Trim());
                    break;

                case 5:
                   Console.Write("Ingrese la cédula del paciente a eliminar: ");
                   string cedulaEliminar = Console.ReadLine() ?? "";
                   agenda.EliminarCita(cedulaEliminar.Trim());
                   break;

                case 0:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (opcion != 0);
    }
}
