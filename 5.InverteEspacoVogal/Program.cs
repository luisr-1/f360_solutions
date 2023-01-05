class Program
{
    static void Main()
    {
        Console.WriteLine("Digite uma palavra");
        string? word = Console.ReadLine();
        if (word != null) Console.WriteLine(ReverseString(word));
    }

    static string ReverseString(string word)
    {
        string reversed = "";
        char[] vogals = new char[] {'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U'};
        
        for(int x = word.Length - 1; x >= 0; x--)
        {
            if (vogals.Contains(word[x]))
            {
                reversed += word[x] + " ";    
            }
            else
            {
                reversed += word[x];
            }
        }

        return reversed;
    }
}