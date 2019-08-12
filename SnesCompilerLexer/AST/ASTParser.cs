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

        public ASTParser(Lexer lexer)
        {
            _lexer = lexer;
            _tokenList = new List<Token>();
            _expressionList = new List<ExpressionDescription>();
        }
        public void AddExpression(ExpressionDescription binaryExpression) => _expressionList.Add(binaryExpression);

        public void Parse(string line)
        {
            _lexer.SetStringToLex(line);
            _tokenList.Clear();
            _currentTokenIndex = 0;

            FetchToken();
            ParseText();
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

        private void ParseText()
        {
            for (_currentTokenIndex = 0; _currentTokenIndex < _tokenList.Count;)
            {
                var e = ParseExpression();
                if(e != null)
                    LastExpression = e;
            }
        }

        private Expression ParseExpression()
        {
            var expressionDescription = GetMatchingExpressionDescription(_tokenList[_currentTokenIndex]);
            if (expressionDescription is LiteralExpressionDescription led)
                return ParseLiteralExpression(led);
            else if (expressionDescription is UnaryExpressionDescription ued)
                return ParseUnaryExpression(ued);
            else if (expressionDescription is BinaryExpressionDescription bied)
                return ParseBinaryExpression(bied);
            else
                throw new Exception("Unvalid expression");
        }

        private ExpressionDescription GetMatchingExpressionDescription(Token token)
        {
            foreach (var expressionDescription in _expressionList)
                if (expressionDescription.CanStartWith(token.Type))
                    return expressionDescription;
                

            throw new Exception("Bad expression encountered");
        }

        private Expression ParseLiteralExpression(LiteralExpressionDescription led)
        {
            var token = _tokenList[_currentTokenIndex++];

            return led.TokenType == TokenType.EOF ? null : new LiteralExpression(token);
        }

        private Expression ParseBinaryExpression(BinaryExpressionDescription bied)
        {
            var token = _tokenList[_currentTokenIndex++];
            var lhs = LastExpression;
            var e = new BinaryExpression()
            {
                Left = lhs,
                Operand = token
            };

            LastExpression = e;
            e.Right = ParseExpression();
            return e;
        }

        private Expression ParseUnaryExpression(UnaryExpressionDescription ued)
        {
            var e = new UnaryExpression()
            {
                Operand = _tokenList[_currentTokenIndex++]
            };

            e.Expression = ParseExpression();
            return e;
        }
    }
}
