using System;
using System.Collections.Generic;
using System.Text;

namespace SnesCompilerLexer.components
{
    public class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public bool IsEOFToken() => Type == TokenType.EOF;
        public override string ToString() => "<Token '" + Type + "'>";
    }
}
