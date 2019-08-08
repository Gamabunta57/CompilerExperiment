using SnesCompilerLexer.Lex.components;
using System;
using System.Collections.Generic;
using System.Text;

namespace SnesCompilerLexer.Lex
{
    public class Lexer
    {
        const char EOF = '\0';

        int _currentIndex;
        string _stringToLex;

        readonly IList<TokenDescription> _availableToken;

        public Lexer()
        {
            _currentIndex = 0;
            _availableToken = new List<TokenDescription>();
        }

        public void SetStringToLex(string stringToLex)
        {
            _stringToLex = stringToLex;
            _currentIndex = 0;
        }

        public void AddTokenDefinition(TokenDescription token) => _availableToken.Add(token);

        public Token Next()
        {
            var tokenDescription = GetTokenDescriptionFromChar(CurrentChar);
            var stringBuilder = new StringBuilder(CurrentChar.ToString());

            while (tokenDescription.Match(NextChar()) && CurrentChar != EOF)
                stringBuilder.Append(CurrentChar);

            return new Token(tokenDescription.Type, stringBuilder.ToString());
        }

        TokenDescription GetTokenDescriptionFromChar(char c)
        {
            foreach (var tokenDescription in _availableToken)
                if (tokenDescription.Match(c))
                    return tokenDescription;

            throw new Exception($"Unexpected token found : '{c}'");
        }

        char NextChar() => ++_currentIndex < _stringToLex.Length ? _stringToLex[_currentIndex] : EOF;
        char CurrentChar => _currentIndex < _stringToLex.Length ? _stringToLex[_currentIndex] : EOF;
    }
}
