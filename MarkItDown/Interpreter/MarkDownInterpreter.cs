using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MarkItDown.Interpreter.Expressions;

namespace MarkItDown.Interpreter
{
    public class MarkdownInterpreter
    {
        private readonly Dictionary<string, Func<string, MarkdownExpression>> _expressions = new Dictionary<string, Func<string, MarkdownExpression>>
            {
                {"#", expression => new HeaderExpression(expression)},
                {"##", expression => new HeaderExpression(expression)},
                {"###", expression => new HeaderExpression(expression)},
                {"####", expression => new HeaderExpression(expression)},
                {"#####", expression => new HeaderExpression(expression)},
                {"######", expression => new HeaderExpression(expression)}
            };

        public string Interpret(string text)
        {
            IEnumerable<string> tokens = Regex.Split(text, @"(\n|\r|\s)");

            Console.WriteLine(tokens.Aggregate((current, next) => current + "," + next));

            MarkdownContext context = new MarkdownContext();

            foreach (string token in tokens)
            {
                // Check if the token closes the current compound expression. If so, remove the compound expression from the stack.
                if (context.CompoundExpressions.Peek().TokenClosesExpression(token))
                {
                    context.CompoundExpressions.Pop();
                    continue;
                }

                // Retreive the expression belonging to the token
                MarkdownExpression expression;

                string tokenWithoutWhitespace = Regex.Replace(token, @"(\n|\r|\s)+", "");

                if (_expressions.ContainsKey(tokenWithoutWhitespace))
                {
                    expression = _expressions[tokenWithoutWhitespace](tokenWithoutWhitespace);
                }
                else
                {
                    // Token is not a Markdown expression, so it is just text
                    expression = new TextExpression(token);
                }

                context.CompoundExpressions.Peek().AddExpression(expression);

                if (expression is CompoundExpression compoundExpression)
                    context.CompoundExpressions.Push(compoundExpression);
            }

            return context.CompoundExpressions.Peek().Interpret(context);
        }
    }
}
