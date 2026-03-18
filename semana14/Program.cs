using System;

namespace ArbolBinarioBusquedaApp
{
    // Clase Nodo
    public class Nodo
    {
        public int Valor;
        public Nodo Izquierdo;
        public Nodo Derecho;

        public Nodo(int valor)
        {
            Valor = valor;
            Izquierdo = null;
            Derecho = null;
        }
    }

    // Clase Árbol Binario de Búsqueda
    public class ArbolBinarioBusqueda
    {
        private Nodo raiz;

        public ArbolBinarioBusqueda()
        {
            raiz = null;
        }

        // Insertar
        public void Insertar(int valor)
        {
            raiz = InsertarRecursivo(raiz, valor);
        }

        private Nodo InsertarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return new Nodo(valor);

            if (valor < nodo.Valor)
                nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
            else
                Console.WriteLine("El valor ya existe en el árbol.");

            return nodo;
        }

        // Buscar
        public bool Buscar(int valor)
        {
            return BuscarRecursivo(raiz, valor);
        }

        private bool BuscarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
                return false;

            if (valor == nodo.Valor)
                return true;

            if (valor < nodo.Valor)
                return BuscarRecursivo(nodo.Izquierdo, valor);
            else
                return BuscarRecursivo(nodo.Derecho, valor);
        }

        // Eliminar
        public void Eliminar(int valor)
        {
            raiz = EliminarRecursivo(raiz, valor);
        }

        private Nodo EliminarRecursivo(Nodo nodo, int valor)
        {
            if (nodo == null)
            {
                Console.WriteLine("El valor no se encontró en el árbol.");
                return null;
            }

            if (valor < nodo.Valor)
            {
                nodo.Izquierdo = EliminarRecursivo(nodo.Izquierdo, valor);
            }
            else if (valor > nodo.Valor)
            {
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, valor);
            }
            else
            {
                // Caso 1: sin hijos
                if (nodo.Izquierdo == null && nodo.Derecho == null)
                    return null;

                // Caso 2: un solo hijo
                if (nodo.Izquierdo == null)
                    return nodo.Derecho;

                if (nodo.Derecho == null)
                    return nodo.Izquierdo;

                // Caso 3: dos hijos
                Nodo sucesor = ObtenerMinNodo(nodo.Derecho);
                nodo.Valor = sucesor.Valor;
                nodo.Derecho = EliminarRecursivo(nodo.Derecho, sucesor.Valor);
            }

            return nodo;
        }

        // Recorridos
        public void MostrarInorden()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            Console.Write("Inorden: ");
            InordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void InordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                InordenRecursivo(nodo.Izquierdo);
                Console.Write(nodo.Valor + " ");
                InordenRecursivo(nodo.Derecho);
            }
        }

        public void MostrarPreorden()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            Console.Write("Preorden: ");
            PreordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void PreordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                Console.Write(nodo.Valor + " ");
                PreordenRecursivo(nodo.Izquierdo);
                PreordenRecursivo(nodo.Derecho);
            }
        }

        public void MostrarPostorden()
        {
            if (raiz == null)
            {
                Console.WriteLine("El árbol está vacío.");
                return;
            }

            Console.Write("Postorden: ");
            PostordenRecursivo(raiz);
            Console.WriteLine();
        }

        private void PostordenRecursivo(Nodo nodo)
        {
            if (nodo != null)
            {
                PostordenRecursivo(nodo.Izquierdo);
                PostordenRecursivo(nodo.Derecho);
                Console.Write(nodo.Valor + " ");
            }
        }

        // Mínimo
        public int ObtenerMinimo()
        {
            if (raiz == null)
                throw new InvalidOperationException("El árbol está vacío.");

            return ObtenerMinNodo(raiz).Valor;
        }

        private Nodo ObtenerMinNodo(Nodo nodo)
        {
            while (nodo.Izquierdo != null)
                nodo = nodo.Izquierdo;

            return nodo;
        }

        // Máximo
        public int ObtenerMaximo()
        {
            if (raiz == null)
                throw new InvalidOperationException("El árbol está vacío.");

            Nodo actual = raiz;
            while (actual.Derecho != null)
                actual = actual.Derecho;

            return actual.Valor;
        }

        // Altura
        public int ObtenerAltura()
        {
            return ObtenerAlturaRecursiva(raiz);
        }

        private int ObtenerAlturaRecursiva(Nodo nodo)
        {
            if (nodo == null)
                return -1; // si prefieres contar raíz como 1, cambia esto a 0

            int alturaIzquierda = ObtenerAlturaRecursiva(nodo.Izquierdo);
            int alturaDerecha = ObtenerAlturaRecursiva(nodo.Derecho);

            return Math.Max(alturaIzquierda, alturaDerecha) + 1;
        }

        // Limpiar árbol
        public void Limpiar()
        {
            raiz = null;
        }

        public bool EstaVacio()
        {
            return raiz == null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinarioBusqueda arbol = new ArbolBinarioBusqueda();
            int opcion, valor;

            do
            {
                Console.WriteLine("\n====== MENÚ ÁRBOL BINARIO DE BÚSQUEDA ======");
                Console.WriteLine("1. Insertar valor");
                Console.WriteLine("2. Buscar valor");
                Console.WriteLine("3. Eliminar valor");
                Console.WriteLine("4. Mostrar recorrido Preorden");
                Console.WriteLine("5. Mostrar recorrido Inorden");
                Console.WriteLine("6. Mostrar recorrido Postorden");
                Console.WriteLine("7. Mostrar valor mínimo");
                Console.WriteLine("8. Mostrar valor máximo");
                Console.WriteLine("9. Mostrar altura del árbol");
                Console.WriteLine("10. Limpiar árbol");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Entrada inválida.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingrese el valor a insertar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            arbol.Insertar(valor);
                            Console.WriteLine("Valor insertado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                        break;

                    case 2:
                        Console.Write("Ingrese el valor a buscar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            if (arbol.Buscar(valor))
                                Console.WriteLine("El valor sí existe en el árbol.");
                            else
                                Console.WriteLine("El valor no existe en el árbol.");
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingrese el valor a eliminar: ");
                        if (int.TryParse(Console.ReadLine(), out valor))
                        {
                            arbol.Eliminar(valor);
                            Console.WriteLine("Proceso de eliminación finalizado.");
                        }
                        else
                        {
                            Console.WriteLine("Valor inválido.");
                        }
                        break;

                    case 4:
                        arbol.MostrarPreorden();
                        break;

                    case 5:
                        arbol.MostrarInorden();
                        break;

                    case 6:
                        arbol.MostrarPostorden();
                        break;

                    case 7:
                        try
                        {
                            Console.WriteLine("Valor mínimo: " + arbol.ObtenerMinimo());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 8:
                        try
                        {
                            Console.WriteLine("Valor máximo: " + arbol.ObtenerMaximo());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case 9:
                        if (arbol.EstaVacio())
                            Console.WriteLine("El árbol está vacío.");
                        else
                            Console.WriteLine("Altura del árbol: " + arbol.ObtenerAltura());
                        break;

                    case 10:
                        arbol.Limpiar();
                        Console.WriteLine("El árbol ha sido limpiado completamente.");
                        break;

                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            } while (opcion != 0);
        }
    }
}