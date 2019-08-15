
using System.Text;

namespace SnesCompilerLexer.Lex.components
{
    class CharRangeSetTokenDescription : MultipleCharTokenDescription
    {
        readonly char[] CharRangeSet;
        public CharRangeSetTokenDescription(TokenType type, char[] charRangeSet) : base(type)
        {
            var length = charRangeSet.Length;
            CharRangeSet = new char[length];
            for (var i = 0; i < length; i += 2)
            {
                CharRangeSet[i] = (char)(charRangeSet[i] - 1);
                CharRangeSet[i + 1] = (char)(charRangeSet[i + 1] + 1);
            }
        }

        public override bool Match(char c)
        {
            for (var i = 0; i < CharRangeSet.Length; i += 2)
                if (CharRangeSet[i] < c && c < CharRangeSet[i + 1])
                    return true;

            return false;
        }
    }
}
