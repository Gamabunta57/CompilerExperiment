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

        public bool HasNextChar() => _currentIndex < _stringToLex.Length;
        public char NextChar() => ++_currentIndex < _stringToLex.Length ? _stringToLex[_currentIndex] : EOF;
        public char CurrentChar => _currentIndex < _stringToLex.Length ? _stringToLex[_currentIndex] : EOF;

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
            return tokenDescription.ParseToken(this);
        }

        TokenDescription GetTokenDescriptionFromChar(char c)
        {
            foreach (var tokenDescription in _availableToken)
                if (tokenDescription.Match(c))
                    return tokenDescription;

            throw new Exception($"Unexpected token found : '{c}'");
        }

    }
}
