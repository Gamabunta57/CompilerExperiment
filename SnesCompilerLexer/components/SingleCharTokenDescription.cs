
namespace SnesCompilerLexer.components
{
    public class SingleCharTokenDescription : TokenDescription
    {
        readonly char Char;
        public SingleCharTokenDescription(TokenType type, char c) : base(type) => Char = c;
        public override bool Match(char c) => c == Char;
    }
}
