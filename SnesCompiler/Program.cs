using SnesCompilerLexer.AST;
using SnesCompilerLexer.AST.builder;
using SnesCompilerLexer.Lex;
using SnesCompilerLexer.Lex.builder;
using SnesCompilerLexer.Lex.components;
using System;

namespace SnesCompiler
{
    class Program
    {

        static bool DoDisplayToken = false;
        static bool DoDisplayAST = true;

        static void Main(string[] args)
        {
            var lexer = StandardLexer.Build();
            var astParser = ASTParserBuilder.Build(lexer);

            while (true)
            {
                Console.Write("SnesC> ");
                string line = Console.ReadLine();

                if (line == "exit") break;
                else if (line == "switch token")
                {
                    DoDisplayToken = !DoDisplayToken;
                    continue;
                }else if(line == "switch ast")
                {
                    DoDisplayAST = !DoDisplayAST;
                    continue;
                }

                if (DoDisplayToken)
                    DisplayToken(lexer, line);
                if (DoDisplayAST)
                    DisplayAST(astParser, line); 
              

                Console.WriteLine();
            }
        }

        static void DisplayToken(Lexer lexer, string line)
        {
            lexer.SetStringToLex(line);
            Token t;
            do
            {
                t = lexer.Next();
                Console.Write(t);
            } while (!t.IsEOFToken());
        }

        static void DisplayAST(ASTParser astParser, string line)
        {
            astParser.Parse(line);
            Console.Write(astParser.LastExpression);
        }
    }
}
