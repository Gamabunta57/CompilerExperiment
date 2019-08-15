using SnesCompilerLexer.AST.components;
using SnesCompilerLexer.AST.components.description;
using SnesCompilerLexer.Lex;
using SnesCompilerLexer.Lex.components;
using System;
using System.Collections.Generic;

namespace SnesCompilerLexer.AST
{
    public class ASTParser
    {
        int _currentTokenIndex;

        public Expression LastExpression { get; private set; }
        
        readonly Lexer _lexer;
        readonly IList<Token> _tokenList;
        readonly IList<ExpressionDescription> _expressionList;

        public Token CurrentToken => _tokenList[_currentTokenIndex];

        public ASTParser(Lexer lexer)
        {
            _lexer = lexer;
            _tokenList = new List<Token>();
            _expressionList = new List<ExpressionDescription>();
        }
        public void AddExpression(ExpressionDescription binaryExpression) => _expressionList.Add(binaryExpression);

        public Expression Parse(string line)
        {
            _lexer.SetStringToLex(line);
            _tokenList.Clear();
            _currentTokenIndex = 0;

            FetchToken();
            return ParseText();
        }

        private void FetchToken()
        {
            Token token;
            do
            {
                token = _lexer.Next();
                if (token.Type != TokenType.Blank && token.Type != TokenType.Bad)
                    _tokenList.Add(token);
            }
            while (!token.IsEOFToken());
        }

        private Expression ParseText()
        {
            return ParseExpression();
        }

        private Expression ParseExpression()
        {

            var e = ParsePrimaryExpression();
            return ParseBinaryExpression(e);
        }

        private Expression ParsePrimaryExpression()
        {
            switch (_tokenList[_currentTokenIndex].Type)
            {
                case TokenType.OpenParenthesis:
                    {
                        _currentTokenIndex++;
                        var e = ParseExpression();
                        if (_tokenList[_currentTokenIndex].Type != TokenType.CloseParenthesis)
                            throw new Exception($"Attended ')', received {_tokenList[_currentTokenIndex].Value}");

                        return e;
                    }

                case TokenType.Number:
                    {
                        return new LiteralExpression(_tokenList[_currentTokenIndex++]);
                    }
                default:
                    throw new Exception("Attended primary expression");
            }
        }

        private Expression ParseBinaryExpression(Expression priorExpression)
        {
            var op = _tokenList[_currentTokenIndex];
            switch (op.Type)
            {
                case TokenType.Plus:
                case TokenType.Star:
                    {
                        _currentTokenIndex++;
                        var right = ParseExpression();
                        return null == right
                ? priorExpression
                : new BinaryExpression
                {
                    Left = priorExpression,
                    Operand = op,
                    Right = right
                };
                    }

            }
            return priorExpression;
        }
    }
}
