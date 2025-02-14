using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace VisitorPattern
{

    // Abstract Visitor
    public interface IVisitor
    {
        void Visit(Label control);
        void Visit(TextBox control);
        void Visit(CheckBox control);
        void Visit(Button control);
        string GetOutput();
    }

    // Concrete Visitor A
    public class HtmlVisitor : IVisitor
    {
        private StringBuilder builder = new StringBuilder();

        public string GetOutput()
        {
            return builder.ToString();
        }

        public void Visit(Label control)
        {
            builder.AppendLine($"<span>{control.Caption}</span>");
        }

        public void Visit(TextBox control)
        {
            builder.AppendLine($"<span>{control.Caption}</span><input type='text' value='{control.Value}'></input>");
        }

        public void Visit(CheckBox control)
        {
            builder.AppendLine($"<span>{control.Caption}</span><input type='checkbox' value='{control.Value}'></input>");
        }

        public void Visit(Button control)
        {
            builder.AppendLine($"<button><img src='{control.ImageSource}'/>{control.Caption}</button>");
        }
    }

    public class Form : Control
    {
        public ICollection<Control> Body { get; set; }

        public override void Accept(IVisitor visitor)
        {
            foreach (var control in Body)
            {
                control.Accept(visitor);
            }
        }

        //public string GetHtml() 
        //{

            
        //    string html = "<html>";

        //    html += $"<title>{Caption}</title>";

        //    html += "<body>";

           

        //    html += "</body>";
        //    html += "</html>";

        //    return html;
        //}
    }

}
