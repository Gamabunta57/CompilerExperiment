﻿using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components.description
{
    class LiteralExpressionDescription : ExpressionDescription
    {
        public LiteralExpressionDescription(TokenType tokenType, int precedence) : base(precedence) => TokenType = tokenType;

        public TokenType TokenType { get; }

        public override bool CanStartWith(TokenType tokenType) => tokenType == TokenType;
        public override bool CanEndWith(TokenType tokenType) => true;
    }
}
