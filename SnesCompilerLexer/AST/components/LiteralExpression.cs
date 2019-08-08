using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components
{
    class LiteralExpression : Expression
    {
        public LiteralExpression(TokenType tokenType)
        {
            TokenType = tokenType;
        }

        public TokenType TokenType { get; }
    }
}
