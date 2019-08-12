using SnesCompilerLexer.Lex.components;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnesCompilerLexer.AST.components.description
{
    class UnaryExpressionDescription : ExpressionDescription
    {
        public UnaryExpressionDescription(TokenType tokenType, int precedence) : base(precedence) => TokenType = tokenType;

        public TokenType TokenType { get; }
        public ExpressionDescription ExpressionDescription { get; }

        public override bool CanStartWith(TokenType tokenType) => tokenType == TokenType;
        public override bool CanEndWith(TokenType tokenType) => ExpressionDescription.CanEndWith(tokenType);
    }
}
