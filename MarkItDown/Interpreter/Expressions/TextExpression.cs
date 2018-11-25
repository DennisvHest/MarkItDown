using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarkItDown.Interpreter.Expressions
{
    public class TextExpression : MarkdownExpression
    {
        private readonly string _text;

        public TextExpression(string text)
        {
            _text = text;
        }

        public override string Interpret(MarkdownContext context)
        {
            return Regex.Replace(_text, @"(\n|\r)", "<br />");
        }
    }
}
