class Program
{
    static void Main()
    {
        int[] numbers = new[] {6, 4, 7, 2};
        Tuple<double, double> resTuple = MediaMediana(numbers);
        Console.WriteLine("A media é " + resTuple.Item1 + ". A moda é " + resTuple.Item2 + ".");
    }

    public static Tuple<double, double> MediaMediana(int[] arrayNumbers)
    {
        double media, mediana;
        
        try
        {
            media = (double) arrayNumbers.Sum() / arrayNumbers.Length;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        try
        {
            arrayNumbers.Order();
            var meio = (arrayNumbers.Length / 2) - 1;
            mediana = arrayNumbers.Length % 2 == 0 ? 
                (double) (arrayNumbers[meio] + arrayNumbers[meio + 1]) / 2 : arrayNumbers[meio];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return new Tuple<double, double>(media, mediana);
    }
    
}