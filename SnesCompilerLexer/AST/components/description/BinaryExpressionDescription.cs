using System.Collections.Generic;
using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components.description
{
    class BinaryExpressionDescription : ExpressionDescription
    {
        public BinaryExpressionDescription(TokenType operand, int precedence) : base(precedence)
        {
            Operand = operand;
        }

        public TokenType Operand { get; }
        public override bool IsPrimaryExpression => false;

        public override bool CanStartWith(TokenType tokenType) => Operand == tokenType;
    }
}
