
namespace SnesCompilerLexer.Lex.components
{
    public class SingleCharTokenDescription : TokenDescription
    {
        readonly char Char;
        public SingleCharTokenDescription(TokenType type, char c) : base(type) => Char = c;
        public override bool Match(char c) => c == Char;
        public override Token ParseToken(Lexer lexer)
        {
            lexer.NextChar();
            return new Token(Type, Char.ToString());
        }
    }
}
