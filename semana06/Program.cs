using System;

class Nodo
{
    public int dato;
    public Nodo siguiente;

    public Nodo(int dato)
    {
        this.dato = dato;
        this.siguiente = null;
    }
}

class ListaEnlazada
{
    public Nodo cabeza;

    // Método para agregar un nodo al final de la lista
    public void Agregar(int dato)
    {
        Nodo nuevoNodo = new Nodo(dato);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo temp = cabeza;
            while (temp.siguiente != null)
            {
                temp = temp.siguiente;
            }
            temp.siguiente = nuevoNodo;
        }
    }

    // Método para imprimir la lista
    public void Imprimir()
    {
        Nodo temp = cabeza;
        while (temp != null)
        {
            Console.Write(temp.dato + " ");
            temp = temp.siguiente;
        }
        Console.WriteLine();
    }

    // Método para invertir la lista
    public void Invertir()
    {
        Nodo anterior = null;
        Nodo actual = cabeza;
        Nodo siguiente = null;

        while (actual != null)
        {
            siguiente = actual.siguiente;
            actual.siguiente = anterior;
            anterior = actual;
            actual = siguiente;
        }
        cabeza = anterior;
    }

    // Método para eliminar nodos fuera de un rango
    public void EliminarFueraDeRango(int min, int max)
    {
        Nodo temp = cabeza;
        Nodo anterior = null;

        while (temp != null)
        {
            if (temp.dato < min || temp.dato > max)
            {
                if (anterior == null) // Si es el primer nodo
                {
                    cabeza = temp.siguiente;
                }
                else
                {
                    anterior.siguiente = temp.siguiente;
                }
            }
            else
            {
                anterior = temp;
            }
            temp = temp.siguiente;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();
        Random random = new Random();
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("Menu Principal - Pr0gramación C#");
            Console.WriteLine("1. Ejercicio 1: Invertir la lista enlazada");
            Console.WriteLine("2. Ejercicio 2: Eliminar nodos fuera de un rango");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Ejercicio 1: Invertir la lista enlazada
                    Console.WriteLine("\nEjercicio 1: Invertir la lista enlazada");
                    lista = new ListaEnlazada();
                    // Crear lista con 5 números aleatorios
                    for (int i = 0; i < 5; i++)
                    {
                        lista.Agregar(random.Next(1, 100));
                    }

                    Console.WriteLine("Lista original:");
                    lista.Imprimir();

                    // Invertir la lista
                    lista.Invertir();
                    Console.WriteLine("Lista invertida:");
                    lista.Imprimir();

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 2:
                    // Ejercicio 2: Eliminar nodos fuera de un rango
                    Console.WriteLine("\nEjercicio 2: Eliminar nodos fuera de un rango");
                    lista = new ListaEnlazada();
                    // Crear lista con 50 números aleatorios
                    for (int i = 0; i < 50; i++)
                    {
                        lista.Agregar(random.Next(1, 1000));
                    }

                    Console.WriteLine("Lista original:");
                    lista.Imprimir();

                    // Solicitar rango al usuario
                    Console.WriteLine("Ingrese el valor mínimo:");
                    int min = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el valor máximo:");
                    int max = int.Parse(Console.ReadLine());

                    // Eliminar nodos fuera de rango
                    lista.EliminarFueraDeRango(min, max);
                    Console.WriteLine($"Lista después de eliminar nodos fuera de rango ({min}-{max}):");
                    lista.Imprimir();

                    Console.WriteLine("Presione cualquier tecla para continuar...");
                    Console.ReadKey();
                    break;

                case 3:
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        } while (opcion != 3);
    }
}
