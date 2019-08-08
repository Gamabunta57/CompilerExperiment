using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components
{
    class BinaryExpression : Expression
    {
        public BinaryExpression(Expression left, TokenType operand, Expression right)
        {
            Left = left;
            Operand = operand;
            Right = right;
        }

        public Expression Left { get; }
        public TokenType Operand { get; }
        public Expression Right { get; }
    }
}
