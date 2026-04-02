using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

#pragma warning disable CA1416

class ArbolExporter
{
    private const int Radio = 20;
    private const int EspacioVertical = 80;

    public static void ExportarPNG(ArbolBST arbol, string ruta)
    {
        if (arbol == null || arbol.Vacio)
        {
            Console.WriteLine("El árbol está vacío.");
            return;
        }

        int ancho = 800;
        int alto = 600;

        using (Bitmap bmp = new Bitmap(ancho, alto))
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.Clear(Color.White);

            Nodo raiz = ObtenerRaiz(arbol);

            if (raiz == null)
            {
                Console.WriteLine("No se pudo obtener la raíz del árbol.");
                return;
            }

            DibujarNodo(g, raiz, ancho / 2, 40, ancho / 4);

            bmp.Save(ruta, ImageFormat.Png);
        }

        Console.WriteLine($"Imagen exportada en: {ruta}");
    }

    private static Nodo ObtenerRaiz(ArbolBST arbol)
    {
        FieldInfo campo = typeof(ArbolBST).GetField(
            "raiz",
            BindingFlags.NonPublic | BindingFlags.Instance
        );

        if (campo == null)
            return null;

        return campo.GetValue(arbol) as Nodo;
    }

    private static void DibujarNodo(Graphics g, Nodo nodo, int x, int y, int offset)
    {
        if (nodo == null) return;

        offset = Math.Max(offset, 20);

        // 🎨 Verde pastel
        Color verdePastel = Color.FromArgb(152, 251, 152);
        using (Brush brush = new SolidBrush(verdePastel))
        {
            g.FillEllipse(brush, x - Radio, y - Radio, Radio * 2, Radio * 2);
        }

        // 🔲 Borde más visible
        using (Pen borde = new Pen(Color.DarkGreen, 2))
        {
            g.DrawEllipse(borde, x - Radio, y - Radio, Radio * 2, Radio * 2);
        }

        // 🔤 Texto ligeramente desplazado (no tan centrado)
        using (Font font = new Font("Arial", 10))
        {
            SizeF size = g.MeasureString(nodo.Valor.ToString(), font);

            g.DrawString(
                nodo.Valor.ToString(),
                font,
                Brushes.Black,
                x - size.Width / 2 + 3,   // ajuste horizontal
                y - size.Height / 2 + 2   // ajuste vertical
            );
        }

        // Nodo izquierdo
        if (nodo.Izq != null)
        {
            int xIzq = x - offset;
            int yIzq = y + EspacioVertical;

            g.DrawLine(Pens.Black, x, y, xIzq, yIzq);
            DibujarNodo(g, nodo.Izq, xIzq, yIzq, offset / 2);
        }

        // Nodo derecho
        if (nodo.Der != null)
        {
            int xDer = x + offset;
            int yDer = y + EspacioVertical;

            g.DrawLine(Pens.Black, x, y, xDer, yDer);
            DibujarNodo(g, nodo.Der, xDer, yDer, offset / 2);
        }
    }
}

#pragma warning restore CA1416