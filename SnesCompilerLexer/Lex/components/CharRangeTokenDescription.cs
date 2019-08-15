
using System.Text;

namespace SnesCompilerLexer.Lex.components
{
    class CharRangeTokenDescription : MultipleCharTokenDescription
    {
        readonly char From;
        readonly char To;
        public CharRangeTokenDescription(TokenType type, char from, char to) : base(type)
        {
            From = (char)(from - 1);
            To = (char)(to + 1);
        }
        public override bool Match(char c) => From < c && c < To;
    }
}
