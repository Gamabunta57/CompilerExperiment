using SnesCompilerLexer.builder;
using SnesCompilerLexer.components;
using System;

namespace SnesCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("SnesC> ");
                string line = Console.ReadLine();

                if (line == "exit")
                    break;

                Console.WriteLine(line);
                var lexer = StandardLexer.Build(line);
                Token t;
                do
                {
                    t = lexer.Next();
                    Console.Write(t);
                } while (!t.IsEOFToken());

                Console.WriteLine();
            }

        }
    }
}
