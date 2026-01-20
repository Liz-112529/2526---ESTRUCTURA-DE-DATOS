using System;
using System.Collections.Generic;

namespace EjerciciosPilas
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Verificar paréntesis balanceados");
                Console.WriteLine("2. Resolver Torres de Hanoi");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                switch (opcion)
                {
                    case 1:
                        EjecutarParentesisBalanceados();
                        break;
                    case 2:
                        EjecutarTorresHanoi();
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                if (opcion != 3)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 3);
        }

        // ================== OPCIÓN 1 ==================
        static void EjecutarParentesisBalanceados()
        {
            Console.Clear();
            Console.WriteLine("=== Verificación de paréntesis balanceados ===");
            Console.Write("Ingrese una expresión matemática: ");
            string expresion = Console.ReadLine();

            if (EstaBalanceada(expresion))
                Console.WriteLine("Resultado: Fórmula balanceada.");
            else
                Console.WriteLine("Resultado: Fórmula NO balanceada.");
        }

        static bool EstaBalanceada(string expresion)
        {
            Stack<char> pila = new Stack<char>();

            foreach (char c in expresion)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (pila.Count == 0)
                        return false;

                    char tope = pila.Pop();
                    if (!Coinciden(tope, c))
                        return false;
                }
            }

            return pila.Count == 0;
        }

        static bool Coinciden(char apertura, char cierre)
        {
            if (apertura == '(' && cierre == ')') return true;
            if (apertura == '{' && cierre == '}') return true;
            if (apertura == '[' && cierre == ']') return true;
            return false;
        }

        // ================== OPCIÓN 2 ==================
        static void EjecutarTorresHanoi()
        {
            Console.Clear();
            Console.WriteLine("=== Torres de Hanoi usando pilas ===");
            Console.Write("Ingrese el número de discos: ");

            int n;
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Número de discos inválido.");
                return;
            }

            Stack<int> torreA = new Stack<int>();
            Stack<int> torreB = new Stack<int>();
            Stack<int> torreC = new Stack<int>();

            for (int i = n; i >= 1; i--)
                torreA.Push(i);

            Console.WriteLine("\nEstado inicial:");
            MostrarTorres(torreA, torreB, torreC);

            ResolverHanoi(n, torreA, torreC, torreB, 'A', 'C', 'B');

            Console.WriteLine("\nEstado final:");
            MostrarTorres(torreA, torreB, torreC);
        }

        static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                                  char nombreOrigen, char nombreDestino, char nombreAuxiliar)
        {
            if (n == 1)
            {
                MoverDisco(origen, destino, nombreOrigen, nombreDestino);
                return;
            }

            ResolverHanoi(n - 1, origen, auxiliar, destino,
                          nombreOrigen, nombreAuxiliar, nombreDestino);

            MoverDisco(origen, destino, nombreOrigen, nombreDestino);

            ResolverHanoi(n - 1, auxiliar, destino, origen,
                          nombreAuxiliar, nombreDestino, nombreOrigen);
        }

        static void MoverDisco(Stack<int> origen, Stack<int> destino,
                               char nombreOrigen, char nombreDestino)
        {
            int disco = origen.Pop();
            destino.Push(disco);
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
        }

        static void MostrarTorres(Stack<int> A, Stack<int> B, Stack<int> C)
        {
            Console.WriteLine("Torre A: " + string.Join(", ", A));
            Console.WriteLine("Torre B: " + string.Join(", ", B));
            Console.WriteLine("Torre C: " + string.Join(", ", C));
            Console.WriteLine("--------------------------------");
        }
    }
}

