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
                // Limpia la pantalla para mostrar nuevamente el menú
                Console.Clear();
                Console.WriteLine("===== MENÚ PRINCIPAL =====");
                Console.WriteLine("1. Verificar paréntesis balanceados");
                Console.WriteLine("2. Resolver Torres de Hanoi");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");

                // Intenta convertir la entrada del usuario a entero
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0; // Si falla la conversión, se asigna una opción inválida
                }

                // Estructura de control para ejecutar la opción seleccionada
                switch (opcion)
                {
                    case 1:
                        EjecutarParentesisBalanceados(); // Llama al ejercicio 1
                        break;
                    case 2:
                        EjecutarTorresHanoi(); // Llama al ejercicio 2
                        break;
                    case 3:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

                // Pausa antes de volver al menú, excepto cuando se elige salir
                if (opcion != 3)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 3); // El menú se repite hasta que el usuario elija salir
        }

        // ================== EJERCICIO 1 ==================

        /// <summary>
        /// Solicita al usuario una expresión matemática
        /// y muestra si está balanceada o no.
        /// </summary>
        static void EjecutarParentesisBalanceados()
        {
            Console.Clear();
            Console.WriteLine("=== Verificación de paréntesis balanceados ===");
            Console.Write("Ingrese una expresión matemática: ");
            string expresion = Console.ReadLine();

            // Llama al método que valida el balanceo
            if (EstaBalanceada(expresion))
                Console.WriteLine("Resultado: Fórmula balanceada.");
            else
                Console.WriteLine("Resultado: Fórmula NO balanceada.");
        }

        /// <summary>
        /// Determina si los paréntesis (), llaves {} y corchetes []
        /// de una expresión están correctamente balanceados.
        /// Utiliza una pila para almacenar símbolos de apertura.
        /// </summary>
        /// <param name="expresion">Cadena que contiene la expresión matemática</param>
        /// <returns>true si está balanceada, false en caso contrario</returns>
        static bool EstaBalanceada(string expresion)
        {
            Stack<char> pila = new Stack<char>(); // Pila para símbolos de apertura

            foreach (char c in expresion)
            {
                // Si es un símbolo de apertura, se apila
                if (c == '(' || c == '{' || c == '[')
                {
                    pila.Push(c);
                }
                // Si es un símbolo de cierre
                else if (c == ')' || c == '}' || c == ']')
                {
                    // Si la pila está vacía, no hay con qué cerrar
                    if (pila.Count == 0)
                        return false;

                    // Se extrae el último símbolo de apertura
                    char tope = pila.Pop();

                    // Se verifica si coinciden apertura y cierre
                    if (!Coinciden(tope, c))
                        return false;
                }
            }

            // Si la pila queda vacía al final, la expresión está balanceada
            return pila.Count == 0;
        }

        /// <summary>
        /// Comprueba si existe un símbolo de apertura.
        /// coincide apropiadamente con uno de cierre.
        /// </summary>
        /// <param name="apertura">Símbolo de apertura</param>
        /// <param name="cierre">Símbolo de cierre</param>
        /// <returns>true si coinciden, false si no</returns>
        static bool Coinciden(char apertura, char cierre)
        {
            if (apertura == '(' && cierre == ')') return true;
            if (apertura == '{' && cierre == '}') return true;
            if (apertura == '[' && cierre == ']') return true;
            return false;
        }

        // ================== EJERCICIO 2 ==================

        /// <summary>
        /// Pide la cantidad de discos y resuelve.
        /// el asunto de las Torres de Hanoi mediante pilas.
        /// Presenta el estado inicial, los movimientos y el estado final.
        /// </summary>
        static void EjecutarTorresHanoi()
        {
            Console.Clear();
            Console.WriteLine("=== Torres de Hanoi usando pilas ===");
            Console.Write("Ingrese el número de discos: ");

            int n;
            // Validación de entrada
            if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Número de discos inválido.");
                return;
            }

            // Declaración de las tres torres como pilas
            Stack<int> torreA = new Stack<int>();
            Stack<int> torreB = new Stack<int>();
            Stack<int> torreC = new Stack<int>();

            // Inicializa la torre A con los discos (mayor abajo)
            for (int i = n; i >= 1; i--)
                torreA.Push(i);

            Console.WriteLine("\nEstado inicial:");
            MostrarTorres(torreA, torreB, torreC);

            // Llamada al método recursivo que resuelve Hanoi
            ResolverHanoi(n, torreA, torreC, torreB, 'A', 'C', 'B');

            Console.WriteLine("\nEstado final:");
            MostrarTorres(torreA, torreB, torreC);
        }

        /// <summary>
        /// Método recursivo que resuelve el problema
        /// de las Torres de Hanoi.
        /// </summary>
        /// <param name="n">Número de discos a mover</param>
        /// <param name="origen">Torre de origen</param>
        /// <param name="destino">Torre de destino</param>
        /// <param name="auxiliar">Torre auxiliar</param>
        /// <param name="nombreOrigen">Nombre de la torre de origen</param>
        /// <param name="nombreDestino">Nombre de la torre de destino</param>
        /// <param name="nombreAuxiliar">Nombre de la torre auxiliar</param>
        static void ResolverHanoi(int n, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar,
                                  char nombreOrigen, char nombreDestino, char nombreAuxiliar)
        {
            // Caso base: mover un solo disco
            if (n == 1)
            {
                MoverDisco(origen, destino, nombreOrigen, nombreDestino);
                return;
            }

            // Mueve n-1 discos al auxiliar
            ResolverHanoi(n - 1, origen, auxiliar, destino,
                          nombreOrigen, nombreAuxiliar, nombreDestino);

            // Mueve el disco más grande al destino
            MoverDisco(origen, destino, nombreOrigen, nombreDestino);

            // Mueve los n-1 discos desde auxiliar al destino
            ResolverHanoi(n - 1, auxiliar, destino, origen,
                          nombreAuxiliar, nombreDestino, nombreOrigen);
        }

        /// <summary>
        /// Traslada un disco desde la torre de origen
        /// a la torre de destino y genera el movimiento.
        /// </summary>
        static void MoverDisco(Stack<int> origen, Stack<int> destino,
                               char nombreOrigen, char nombreDestino)
        {
            int disco = origen.Pop(); // Extrae el disco superior
            destino.Push(disco);      // Inserta el disco en la torre destino
            Console.WriteLine($"Mover disco {disco} de {nombreOrigen} a {nombreDestino}");
        }

        /// <summary>
        /// Muestra el contenido actual de las tres torres.
        /// </summary>
        static void MostrarTorres(Stack<int> A, Stack<int> B, Stack<int> C)
        {
            Console.WriteLine("Torre A: " + string.Join(", ", A));
            Console.WriteLine("Torre B: " + string.Join(", ", B));
            Console.WriteLine("Torre C: " + string.Join(", ", C));
            Console.WriteLine("--------------------------------");
        }
    }
}
