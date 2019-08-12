using System.Collections.Generic;
using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components.description
{
    class BinaryExpressionDescription : ExpressionDescription
    {
        public BinaryExpressionDescription(ExpressionDescription left, TokenType operand, ExpressionDescription right, int precedence) : base(precedence)
        {
            Left = left;
            Operand = operand;
            Right = right;
        }

        public ExpressionDescription Left { get; }
        public TokenType Operand { get; }
        public ExpressionDescription Right { get; }

        public override bool CanStartWith(TokenType tokenType) => Operand == tokenType;
        public override bool CanEndWith(TokenType tokenType) => Right.CanEndWith(tokenType);


    }
}
