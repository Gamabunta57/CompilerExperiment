
using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components.description
{
    class BlockExpressionDescription : ExpressionDescription
    {
        public BlockExpressionDescription(TokenType start, TokenType end, int precedence) : base(precedence)
        {
            Start = start;
            End = end;
        }

        public TokenType Start { get; }
        public TokenType End { get; }
        public override bool IsPrimaryExpression => true;

        public override bool CanStartWith(TokenType tokenType) => tokenType == Start;
        public bool CanEndWith(TokenType tokenType) => tokenType == End;
    }
}
