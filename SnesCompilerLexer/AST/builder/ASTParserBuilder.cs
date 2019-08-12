
using SnesCompilerLexer.AST.components.description;
using SnesCompilerLexer.Lex;
using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.builder
{
    public static class ASTParserBuilder
    {   
        public static ASTParser Build(Lexer lexer)
        {
            var astParser = new ASTParser(lexer);

            var numberDescription = new LiteralExpressionDescription(TokenType.Number, 0);

            astParser.AddExpression(numberDescription);

            astParser.AddExpression(new UnaryExpressionDescription(TokenType.Minus, 5));

            astParser.AddExpression(new BinaryExpressionDescription(numberDescription, TokenType.Plus, numberDescription,1));
            astParser.AddExpression(new BinaryExpressionDescription(numberDescription, TokenType.Minus, numberDescription, 1));

            astParser.AddExpression(new BinaryExpressionDescription(numberDescription, TokenType.Star, numberDescription, 2));
            astParser.AddExpression(new BinaryExpressionDescription(numberDescription, TokenType.Slash, numberDescription, 2));

            astParser.AddExpression(new BlockExpressionDescription(TokenType.OpenParenthesis, TokenType.CloseParenthesis, 4));

            astParser.AddExpression(new LiteralExpressionDescription(TokenType.EOF, -1));

            return astParser;
        }
    }
}
