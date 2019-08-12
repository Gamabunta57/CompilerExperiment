using SnesCompilerLexer.Lex.components;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnesCompilerLexer.AST.components
{
    public abstract class Expression
    {
        public abstract object Value { get; }
    }
}
