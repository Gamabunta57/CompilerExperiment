using SnesCompilerLexer.AST.builder;
using SnesCompilerLexer.Lex.builder;
using SnesCompilerLexer.Lex.components;
using System;

namespace SnesCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            var lexer = StandardLexer.Build();
            var astParser = ASTParserBuilder.Build(lexer);

            while (true)
            {
                Console.Write("SnesC> ");
                string line = Console.ReadLine();

                if (line == "exit") break;

                lexer.SetStringToLex(line);               
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
