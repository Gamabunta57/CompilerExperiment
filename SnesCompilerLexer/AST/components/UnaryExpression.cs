using SnesCompilerLexer.Lex.components;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnesCompilerLexer.AST.components
{
    class UnaryExpression : Expression
    {
        public Token Operand { get; set; }
        public Expression Expression { get; set; }

        public override object Value => $"{Operand.Value}{Expression}";
        public override string ToString() => $"({Value})";
    }
}
