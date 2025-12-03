public class Circulo : Figura
{
    // atributo
    public double Radio { get; set; }

    // constructor
    public Circulo(double radio)
    {
        this.Radio = radio;
    }

    // método para calcular el área
    public override double CalcularArea()
    {
        return Math.Round(Math.PI * this.Radio * this.Radio, 2);
    }

    // método para calcular el perímetro (circunferencia)
    public override double CalcularPerimetro()
    {
        return Math.Round(2 * Math.PI * this.Radio, 2);
    }
}
