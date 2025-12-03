Console.WriteLine("ESTRUCTURA DE DATOS - UEA");
Console.WriteLine();

// Crear un rectángulo con base 5 y altura 10.5
Rectangulo rectangulo = new Rectangulo(5, 10.5);

// Encabezado de tabla
Console.WriteLine("Rectangulo       | Valor");
Console.WriteLine("-----------------|-----------");

// Valores del rectángulo
Console.WriteLine("Base             | " + rectangulo.Base);
Console.WriteLine("Altura           | " + rectangulo.Altura);
Console.WriteLine("Área             | " + rectangulo.CalcularArea());
Console.WriteLine("Perímetro        | " + rectangulo.CalcularPerimetro());

Console.WriteLine();

// Crear un circulo con radio 5
Circulo circulo = new Circulo(5);

// Encabezado de tabla
Console.WriteLine("Circulo          | Valor");
Console.WriteLine("-----------------|-----------");

// Valores del circulo
Console.WriteLine("Radio             | " + circulo.Radio);
Console.WriteLine("Área              | " + circulo.CalcularArea());
Console.WriteLine("Perímetro         | " + circulo.CalcularPerimetro());

Console.WriteLine();