// See https://aka.ms/new-console-template for more information
using System;

public class Arranger
{
    static void Main()
    {
        string path = System.Reflection.Assembly.GetEntryAssembly().Location;
        //Las vocales siempre deben ser las últimas 5 letras. Si se agregan más consonantes debe de ser al inicio o en medio.
        string[] letras = new string[21] { "p", "t", "k", "l", "m", "s", "r", "rr", "h", "w", "ñ", "h", "x", "g", "y", "n", "a", "e", "i", "o", "u" };

        Console.WriteLine("Introduzca el número mínimo de letras que se usarán por palabra");
        int minLength = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduzca el número máximo de letras que se usarán por palabra");
        int maxLength = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Introduzca el número mínimo de palabras");
        int WordQuantity = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("");

        //el maxLength + 1 es consecuencia de C#. Si sabes como funciona un random, sabes el porqué.
        for (int i = 0; i < WordQuantity; i++) Generate(letras, minLength, maxLength + 1);

        Console.WriteLine("\nPROGRAMA FINALIZADO");
        Console.Read();
    }

    static public void Generate(string[] letras, int minL, int maxL)
    {
        Random rand = new Random();
        string thisWord = "";
        int wordLength = rand.Next(minL, maxL);
        //min y max representan el valor mínimo o valor máximo de donde se tomaran las letras posibles. Su valor es asignado acorde al resultado de consonantReduction
        int min;
        int max;
        int consonantReduction = 2; //Este valor controlará las posibilidades de que la siguiente letra sea consonante
        int consonantRange = letras.Length - 5; //Diferenciador entre las vocales y las consonantes
        string thisChar;

        for (int i = 0; i < wordLength; i++)
        {
            int a = rand.Next(0, consonantReduction);
            if (a <= 1) //se evalúa si la letra será vocal o consonante. Siendo el primer caso una consonante
            {
                min = 0;
                max = consonantRange;
                consonantReduction += 2; //con esto se reducen las posibilidades de que salgan varias consonantes seguidas
            }
            else //Si es vocal
            {
                min = consonantRange;
                max = letras.Length;
                consonantReduction = 2; //con esto se reinicia el contador para que vuelva a ser más probable que haya consonantes
            }
            int arrayLetter = rand.Next(min, max);
            thisChar = letras[arrayLetter];
            thisWord = thisWord + thisChar;
        }
        //funny thing que te hace encontrar palabras que conozcas, destcándolas con el >>>>>>
        switch (thisWord)
        {
            case "arremangala":
                thisWord = ">>>>>> " + thisWord;
                break;
        }
        Console.WriteLine(thisWord);
    }
}