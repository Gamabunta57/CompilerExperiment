
namespace SnesCompilerLexer.Lex.components
{
    public abstract class TokenDescription
    {
        public TokenType Type { get; }
        public TokenDescription(TokenType type) => Type = type;
        public abstract bool Match(char c);
    }
}
