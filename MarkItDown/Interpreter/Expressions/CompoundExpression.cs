using System.Collections.Generic;
using System.Linq;

namespace MarkItDown.Interpreter.Expressions
{
    public class CompoundExpression : MarkdownExpression
    {
        private readonly List<MarkdownExpression> ChildExpressions;

        public CompoundExpression()
        {
            ChildExpressions = new List<MarkdownExpression>();
        }

        public void AddExpression(MarkdownExpression expression)
        {
            ChildExpressions.Add(expression);
        }

        public virtual bool TokenClosesExpression(string token)
        {
            return false;
        }

        public override string Interpret(MarkdownContext context)
        {
            return string.Concat(ChildExpressions.Select(e => e.Interpret(context)));
        }
    }
}
