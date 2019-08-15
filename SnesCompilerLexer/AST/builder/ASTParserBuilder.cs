
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

            astParser.AddExpression(new BlockExpressionDescription(TokenType.OpenParenthesis, TokenType.CloseParenthesis, 4));
            astParser.AddExpression(new BinaryExpressionDescription(TokenType.Star, 2));
            astParser.AddExpression(new BinaryExpressionDescription(TokenType.Plus, 1));
            astParser.AddExpression(numberDescription);
            astParser.AddExpression(new LiteralExpressionDescription(TokenType.EOF, -1));

            return astParser;
        }
    }
}
