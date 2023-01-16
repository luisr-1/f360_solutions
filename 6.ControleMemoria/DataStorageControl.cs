class DataStorageControl
{
    static void Main()
    {
        FileStream fileStream = null;
        StreamReader streamReader = null;
        string path = @"/home/luisr/RiderProjects/ControleMemoria/ControleMemoria/usuarios.txt";

        try
        {
            fileStream = new FileStream(path, FileMode.Open);
            streamReader = new StreamReader(fileStream);
            string text = streamReader.ReadToEnd();

            int linhas = NumeroLinhas(text);
            string[] users = new string[linhas];
            string[] storage = new string[linhas];

            AddTextUsers(users, text);
            AddTextStorage(storage, text);
            
            GeraRelatorio(users, storage, linhas);
        }
        catch (IOException e)
        {
            Console.WriteLine("Um erro aconteceu!\n" + e.Message);
        }
        finally
        {
            if (streamReader != null || fileStream != null)
            {
                streamReader.Close();
                fileStream.Close();
            }
        }
    }
    
    static string ByteToMb(string memory)
    {
        decimal convert = Convert.ToDecimal(memory) / 1000000;
        return convert.ToString("N2") + " MB";
    }

    static double TotalOcupado(string[] storage)
    {
        double total = 0;
        foreach (string memory in storage)
        {
            total += Convert.ToDouble(memory);
        }
        return total;
    }
    
    static string Percentual(int i, string[] storage)
    {
        double percentual = Convert.ToDouble(storage[i]) / TotalOcupado(storage) * 100;
        return percentual.ToString("N2") + " %";
    }
    static double EspacoMedio(double totalUtilizado, int usuarios)
    {
        return totalUtilizado / usuarios;
    }

    static void AddTextUsers(string[] users, string text)
    {
        int x = 0;
        foreach(char caracter in text)
        {
            string numeros = "0 1 2 3 4 5 6 7 8 9";
            
            if (caracter != ' ' && caracter != '\n' && !numeros.Contains(caracter))
            {
                    users[x] += caracter;
            }
            
            if (caracter == '\n')
            {
                x++;
            }
        } 
    }
    
    static void AddTextStorage(string[] storage, string text)
    {
        int x = 0;
        
        foreach (char caracter in text)
        {
            char[] numeros = {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};
            foreach (char numero in numeros)
            {
                if (caracter == numero && caracter != ' ' && caracter != '\n')
                {
                    storage[x] += caracter;
                }
            }
            
            if (caracter == '\n')
            {
                x++;
            }
        }
    }

    static void GeraRelatorio(string[] users, string[] storage, int linhas)
    {
        string fileName = "/home/luisr/RiderProjects/ControleMemoria/ControleMemoria/relatorio.txt";

        try
        {
            File.Create(fileName).Dispose();
            using (StreamWriter streamWriter = File.AppendText(fileName))
            {
                streamWriter.WriteLine("ACME Inc.\tUso de espaço em disco pelos usuários");
                streamWriter.WriteLine("____________________________________________________________________");
                streamWriter.WriteLine("Nr.\tUsuário\t\tEspaço utilizado\t% do uso");

                for (int i = 0; i < linhas; i++)
                {
                    streamWriter.WriteLine($"{(i + 1)}".PadRight(8) + $"{users[i]}".PadRight(16) + 
                                           $"{ByteToMb(storage[i])}".PadRight(24) + 
                                           $"{Percentual(i, storage)}".PadRight(28)); 
                                        
                    if (i + 1 == linhas)
                    {
                        streamWriter.WriteLine("\n");
                    }
                }
                
                streamWriter.WriteLine("Espaço total ocupado: " + 
                                       ByteToMb(Convert.ToString(TotalOcupado(storage))));
                streamWriter.WriteLine("Espaço médio ocupado: " + 
                                       ByteToMb(Convert.ToString(EspacoMedio(TotalOcupado(storage), 
                                           linhas))));
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Ocorreu um erro\n" + e.Message);
        }
    }

    static int NumeroLinhas(string text)
    {
        int linhas = 1;
        foreach (char letra in text)
        {
            if (letra == '\n')
            {
                linhas++;
            }
        }

        return linhas;
    }
}