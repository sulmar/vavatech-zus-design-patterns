using System.Collections.Generic;

namespace FactoryMethodTemplate.Razor
{
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
