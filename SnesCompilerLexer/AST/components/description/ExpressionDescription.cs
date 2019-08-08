
using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components.description
{
    public abstract class ExpressionDescription
    {
        protected ExpressionDescription(int precedence) => Precedence = precedence;
        public int Precedence { get; }

        public abstract bool CanStartWith(TokenType tokenType);
        public abstract bool CanEndWith(TokenType tokenType);
    }
}
