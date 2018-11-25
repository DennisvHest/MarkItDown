using System.Linq;

namespace MarkItDown.Interpreter.Expressions
{
    public class HeaderExpression : CompoundExpression
    {
        private readonly int _size;

        public HeaderExpression(string expression)
        {
            _size = expression.Length;
        }

        public override bool TokenClosesExpression(string token)
        {
            return token.Contains('\n');
        }

        public override string Interpret(MarkdownContext context)
        {
            return $"<h{_size}>{base.Interpret(context)}</h{_size}>";
        }
    }
}
