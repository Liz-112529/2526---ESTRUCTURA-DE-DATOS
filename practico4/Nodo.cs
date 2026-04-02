class Nodo
{
    public int Valor { get; set; }
    public Nodo Izq { get; set; }
    public Nodo Der { get; set; }

    public Nodo(int valor)
    {
        Valor = valor;
        Izq = null;
        Der = null;
    }
}