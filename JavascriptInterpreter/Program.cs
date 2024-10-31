// See https://aka.ms/new-console-template for more information
using JavascriptInterpreter;

Console.WriteLine("Hello, World!");

string testeA =
    """"
        var a = 1.28;
        var b = 2.40;
    
        if(a == null || b == null)
        {
            return null;
        }

        var c = Math.Sin("123e4567-e89b-12d3-a456-9AC7CBDCEE52");

        return a + b - c;
    """";



Lexer.Lex(testeA);
