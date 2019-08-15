using System.Text;

namespace SnesCompilerLexer.Lex.components
{
    public abstract class MultipleCharTokenDescription : TokenDescription
    {
        public MultipleCharTokenDescription(TokenType type) : base(type) { }
        public override Token ParseToken(Lexer lexer)
        {
            var sBuilder = new StringBuilder();
            sBuilder.Append(lexer.CurrentChar);

            while (Match(lexer.NextChar()))
                sBuilder.Append(lexer.CurrentChar);

            return new Token(Type, sBuilder.ToString());
        }
    }
}
