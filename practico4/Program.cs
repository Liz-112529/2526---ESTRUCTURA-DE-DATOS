using System;
using System.Collections.Generic;

namespace BST_Con_Menu
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var arbol = new ArbolBST();

            while (true)
            {
                Console.WriteLine("\n=== ÁRBOL BINARIO DE BÚSQUEDA (BST) ===");
                Console.WriteLine("1) Insertar");
                Console.WriteLine("2) Eliminar");
                Console.WriteLine("3) Buscar");
                Console.WriteLine("4) Recorrido PREORDEN");
                Console.WriteLine("5) Recorrido INORDEN (ordenado)");
                Console.WriteLine("6) Recorrido POSTORDEN");
                Console.WriteLine("7) Mínimo / Máximo");
                Console.WriteLine("8) Altura");
                Console.WriteLine("9) Limpiar árbol");
                Console.WriteLine("10) Exportar árbol a PNG"); // 🔧 movido arriba
                Console.WriteLine("0) Salir");

                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                Console.WriteLine();

                switch (opcion)
                {
                    case "1": // Insertar
                        if (LeerEntero("Ingrese el valor a insertar: ", out int vIns))
                        {
                            arbol.Insertar(vIns);
                            Console.WriteLine($"Insertado: {vIns}");
                        }
                        break;

                    case "2": // Eliminar
                        if (LeerEntero("Ingrese el valor a eliminar: ", out int vDel))
                        {
                            bool existia = arbol.Buscar(vDel);
                            arbol.Eliminar(vDel);
                            Console.WriteLine(existia ? $"Eliminado: {vDel}" : "⚠ No existe ese valor en el árbol.");
                        }
                        break;

                    case "3": // Buscar
                        if (LeerEntero("Ingrese el valor a buscar: ", out int vBus))
                        {
                            Console.WriteLine(arbol.Buscar(vBus)
                                ? $"✔ {vBus} SÍ está en el árbol."
                                : $"✖ {vBus} NO está en el árbol.");
                        }
                        break;

                    case "4": // Preorden
                        ImprimirLista("Preorden", arbol.Preorden());
                        break;

                    case "5": // Inorden
                        ImprimirLista("Inorden", arbol.Inorden());
                        break;

                    case "6": // Postorden
                        ImprimirLista("Postorden", arbol.Postorden());
                        break;

                    case "7": // Min/Max
                        var min = arbol.Min();
                        var max = arbol.Max();
                        Console.WriteLine(arbol.Vacio
                            ? "El árbol está vacío."
                            : $"Mínimo: {min}, Máximo: {max}");
                        break;

                    case "8": // Altura
                        Console.WriteLine(arbol.Vacio
                            ? "El árbol está vacío."
                            : $"Altura del árbol: {arbol.Altura()}");
                        break;

                    case "9": // Limpiar
                        arbol.Limpiar();
                        Console.WriteLine("Árbol limpiado.");
                        break;

                    case "10": // Exportar
                        if (arbol.Vacio)
                        {
                            Console.WriteLine("El árbol está vacío. No se puede exportar.");
                        }
                        else
                        {
                            string ruta = "arbol.png";
                            ArbolExporter.ExportarPNG(arbol, ruta);
                        }
                        break;

                    case "0":
                        Console.WriteLine("¡Hasta la próxima att. L I Z!");
                        return;

                    default:
                        Console.WriteLine("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        // Helpers de E/S
        static bool LeerEntero(string prompt, out int valor)
        {
            Console.Write(prompt);
            string s = Console.ReadLine();

            if (!int.TryParse(s, out valor))
            {
                Console.WriteLine("Entrada inválida. Debe ser un número entero.");
                return false;
            }
            return true;
        }

        static void ImprimirLista(string titulo, List<int> datos)
        {
            if (datos == null || datos.Count == 0)
            {
                Console.WriteLine($"[{titulo}] Árbol vacío.");
                return;
            }

            Console.WriteLine($"[{titulo}] {string.Join(" - ", datos)}");
        }
    }
}