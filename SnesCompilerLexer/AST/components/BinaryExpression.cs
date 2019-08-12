using SnesCompilerLexer.Lex.components;

namespace SnesCompilerLexer.AST.components
{
    class BinaryExpression : Expression
    {

        public Expression Left { get; set; }
        public Token Operand { get; set; }
        public Expression Right { get; set; }

        public override object Value => $"{Left} {Operand.Value} {Right}";
        public override string ToString() => $"({Value})";
    }
}
