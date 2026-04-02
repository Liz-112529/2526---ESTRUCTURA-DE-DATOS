using System;
using System.Collections.Generic;

// Árbol Binario de Búsqueda
class ArbolBST
{
    private Nodo raiz;

    // ✅ PROPIEDAD PÚBLICA (reemplaza el hack de reflexión)
    public Nodo Raiz => raiz;

    public bool Vacio => raiz == null;

    // Insertar (ignora duplicados)
    public void Insertar(int valor)
    {
        raiz = InsertarRec(raiz, valor);
    }

    private Nodo InsertarRec(Nodo actual, int valor)
    {
        if (actual == null)
            return new Nodo(valor);

        if (valor < actual.Valor)
            actual.Izq = InsertarRec(actual.Izq, valor);
        else if (valor > actual.Valor)
            actual.Der = InsertarRec(actual.Der, valor);

        return actual;
    }

    // Buscar
    public bool Buscar(int valor)
    {
        return BuscarRec(raiz, valor);
    }

    private bool BuscarRec(Nodo actual, int valor)
    {
        if (actual == null) return false;

        if (valor == actual.Valor)
            return true;

        return valor < actual.Valor
            ? BuscarRec(actual.Izq, valor)
            : BuscarRec(actual.Der, valor);
    }

    // Eliminar
    public void Eliminar(int valor)
    {
        raiz = EliminarRec(raiz, valor);
    }

    private Nodo EliminarRec(Nodo actual, int valor)
    {
        if (actual == null) return null;

        if (valor < actual.Valor)
        {
            actual.Izq = EliminarRec(actual.Izq, valor);
        }
        else if (valor > actual.Valor)
        {
            actual.Der = EliminarRec(actual.Der, valor);
        }
        else
        {
            // Caso 1: Sin hijos
            if (actual.Izq == null && actual.Der == null)
                return null;

            // Caso 2: Un hijo
            if (actual.Izq == null)
                return actual.Der;

            if (actual.Der == null)
                return actual.Izq;

            // Caso 3: Dos hijos
            Nodo sucesor = Minimo(actual.Der);
            actual.Valor = sucesor.Valor;
            actual.Der = EliminarRec(actual.Der, sucesor.Valor);
        }

        return actual;
    }

    private Nodo Minimo(Nodo actual)
    {
        while (actual.Izq != null)
            actual = actual.Izq;

        return actual;
    }

    // Recorridos
    public List<int> Preorden()
    {
        var resultado = new List<int>();
        PreordenRec(raiz, resultado);
        return resultado;
    }

    private void PreordenRec(Nodo n, List<int> r)
    {
        if (n == null) return;

        r.Add(n.Valor);
        PreordenRec(n.Izq, r);
        PreordenRec(n.Der, r);
    }

    public List<int> Inorden()
    {
        var resultado = new List<int>();
        InordenRec(raiz, resultado);
        return resultado;
    }

    private void InordenRec(Nodo n, List<int> r)
    {
        if (n == null) return;

        InordenRec(n.Izq, r);
        r.Add(n.Valor);
        InordenRec(n.Der, r);
    }

    public List<int> Postorden()
    {
        var resultado = new List<int>();
        PostordenRec(raiz, resultado);
        return resultado;
    }

    private void PostordenRec(Nodo n, List<int> r)
    {
        if (n == null) return;

        PostordenRec(n.Izq, r);
        PostordenRec(n.Der, r);
        r.Add(n.Valor);
    }

    // Utilidades
    public void Limpiar()
    {
        raiz = null;
    }

    public int? Min()
    {
        return raiz == null ? null : Minimo(raiz).Valor;
    }

    public int? Max()
    {
        if (raiz == null) return null;

        Nodo actual = raiz;
        while (actual.Der != null)
            actual = actual.Der;

        return actual.Valor;
    }

    public int Altura()
    {
        return AlturaRec(raiz);
    }

    private int AlturaRec(Nodo n)
    {
        if (n == null) return -1;
        return 1 + Math.Max(AlturaRec(n.Izq), AlturaRec(n.Der));
    }
}