
class LimpaString
{
    static void Main()
    {
        string palavra = "CRÉDITO A VISTA - % . ,";
        Console.WriteLine(Limpa(palavra));
    }

    static string Limpa(string palavra)
    {
        string limpa = "";
        string caracteresProibidos = ".É,%-";
        foreach (char caracter in palavra)
        {
            if (caracteresProibidos.Contains(caracter))
            {
                if (caracter == 'É')
                {
                    limpa += "E";
                }
                else
                {
                    limpa += "";
                }
            }
            else
            {
                limpa += caracter;
            }
        }

        return limpa;
    }
}