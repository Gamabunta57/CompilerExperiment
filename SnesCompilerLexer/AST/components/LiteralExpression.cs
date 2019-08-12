using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components
{
    class LiteralExpression : Expression
    {
        public LiteralExpression(Token token)
        {
            Token = token;
        }

        public Token Token { get; }

        public override object Value => Token.Value;

        public override string ToString() => $"{Value}";
    }
}
