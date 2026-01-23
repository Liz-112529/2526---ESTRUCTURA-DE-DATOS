using System;
using System.Collections.Generic;

namespace NavegadorWeb
{
    // Clase que representa el navegador
    public class Browser
    {
        private Stack<string> historial;

        // Constructor
        public Browser()
        {
            historial = new Stack<string>();
        }

        // Visitar una nueva página (Push)
        public void VisitarPagina(string url)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            historial.Push(url);
            Console.WriteLine("Página visitada: " + url);
            Console.ResetColor();
        }

        // Botón Retroceder (Pop)
        public void Retroceder()
        {
            if (historial.Count > 1)
            {
                string paginaActual = historial.Pop();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Retrocediendo desde: " + paginaActual);
                Console.WriteLine("Página actual: " + historial.Peek());
                Console.ResetColor();
            }
            else if (historial.Count == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Está en la primera página. No puede retroceder más.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay páginas en el historial.");
                Console.ResetColor();
            }
        }

        // Consultar página actual (Peek)
        public void PaginaActual()
        {
            if (historial.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Página actual: " + historial.Peek());
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No hay páginas en el historial.");
                Console.ResetColor();
            }
        }

        // Reportería: visualizar todo el historial
        public void MostrarHistorial()
        {
            if (historial.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n--- Historial de navegación ---");
                Console.ResetColor();

                foreach (string pagina in historial)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("- " + pagina);
                }
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El historial está vacío.");
                Console.ResetColor();
            }
        }
    }

    // Clase principal con menú interactivo
    class Program
    {
        static void Main(string[] args)
        {
            Browser navegador = new Browser();
            int opcion;
            string url;

            do
            {
                Console.Clear();

                // Título
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("===== NAVEGADOR WEB =====");
                Console.ResetColor();

                // Menú
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1. Visitar nueva página");
                Console.WriteLine("2. Botón Retroceder");
                Console.WriteLine("3. Ver página actual");
                Console.WriteLine("4. Mostrar historial");
                Console.WriteLine("5. Salir");
                Console.ResetColor();

                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Ingrese la URL: ");
                        Console.ResetColor();

                        url = Console.ReadLine();
                        navegador.VisitarPagina(url);
                        break;

                    case 2:
                        navegador.Retroceder();
                        break;

                    case 3:
                        navegador.PaginaActual();
                        break;

                    case 4:
                        navegador.MostrarHistorial();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Trabajo culminado por Liz Peña...");
                        Console.ResetColor();
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opción inválida.");
                        Console.ResetColor();
                        break;
                }

                Console.WriteLine("\nPresione una tecla para continuar...");
                Console.ReadKey();

            } while (opcion != 5);
        }
    }
}
