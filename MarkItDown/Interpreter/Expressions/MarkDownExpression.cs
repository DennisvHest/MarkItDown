namespace MarkItDown.Interpreter.Expressions
{
    public abstract class MarkdownExpression
    {
        public abstract string Interpret(MarkdownContext context);
    }
}
