using SnesCompilerLexer.components;

namespace SnesCompilerLexer.builder
{
    public static class StandardLexer
    {

        public static Lexer Build(string stringToLex)
        {
            var lexer = new Lexer(stringToLex);

            lexer.AddTokenDefinition(new SingleCharTokenDescription(TokenType.EOF,'\0'));
            lexer.AddTokenDefinition(new SingleCharTokenDescription(TokenType.Plus, '+'));
            lexer.AddTokenDefinition(new SingleCharTokenDescription(TokenType.Minus, '-'));
            lexer.AddTokenDefinition(new SingleCharTokenDescription(TokenType.Star, '*'));
            lexer.AddTokenDefinition(new SingleCharTokenDescription(TokenType.Slash, '/'));
            lexer.AddTokenDefinition(new SingleCharTokenDescription(TokenType.OpenParenthesis, '('));
            lexer.AddTokenDefinition(new SingleCharTokenDescription(TokenType.CloseParenthesis, ')'));
            lexer.AddTokenDefinition(new CharRangeTokenDescription(TokenType.Number, '0','9'));
            lexer.AddTokenDefinition(new CharRangeSetTokenDescription(TokenType.Identifier, new char[] { 'A', 'Z', 'a', 'z' }));
            lexer.AddTokenDefinition(new CharSetTokenDescription(TokenType.Blank, new char[] { (char)0x9, (char)0xa, (char)0xd, (char)0x20 }));

            return lexer;
        }
    }
}
