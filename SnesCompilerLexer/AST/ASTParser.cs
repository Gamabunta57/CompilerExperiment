using SnesCompilerLexer.AST.components.description;
using SnesCompilerLexer.Lex;
using SnesCompilerLexer.Lex.components;
using System.Collections.Generic;

namespace SnesCompilerLexer.AST
{
    public class ASTParser
    {
        Lexer _lexer;
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
            FetchToken();


        }

        private void FetchToken()
        {
            _tokenList.Clear();
            Token token;
            do
            {
                token = _lexer.Next();
                if (token.Type != TokenType.Blank && token.Type != TokenType.Bad)
                    _tokenList.Add(token);
            }
            while (!token.IsEOFToken());
        }
    }
}
