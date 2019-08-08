namespace SnesCompilerLexer.Lex.components
{
    class CharSetTokenDescription : TokenDescription
    {
        readonly char[] CharSet;
        public CharSetTokenDescription(TokenType type, char[] charSet) : base(type) => CharSet = charSet;

        public override bool Match(char c)
        {
            foreach (char Char in CharSet)
                if (Char == c)
                    return true;
            return false;
        }
    }
}
