using System;
using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{

    public class Document
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class PrintService
    {
        IPrinter printer;

        public void Print(Document document)
        {
           
        }
    }

    public interface IPrinter
    {
        void Print(Document document);
    }

    public class PrintToPrinter : IPrinter
    {
        public void Print(Document document)
        {
            Console.WriteLine("Print on printer...");
        }
    }

    public class PrintToPdf : IPrinter
    {
        public void Print(Document document)
        {
            Console.WriteLine("Print to pdf...");
        }
    }

    public class Controller
    {
        public string Render(string viewName, IDictionary<string, object> context)
        {
            var engine = CreateViewEngine(); // Problem
            var html = engine.Render(viewName, context);

            return html;
        }

        // Metoda fabrykująca
        protected virtual IViewEngine CreateViewEngine()
        {
            return new RazorViewEngine();
        }
    }

    public class HugoController : Controller
    {
        protected override IViewEngine CreateViewEngine()
        {
            return new HugoViewEngine();
        }
    }
}
