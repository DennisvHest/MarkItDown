using System.Collections.Generic;
using MarkItDown.Interpreter.Expressions;

namespace MarkItDown.Interpreter
{
    public class MarkdownContext
    {
        public Stack<CompoundExpression> CompoundExpressions { get; }

        public MarkdownContext()
        {
            CompoundExpressions = new Stack<CompoundExpression>();
            CompoundExpressions.Push(new CompoundExpression());
        }
    }
}
