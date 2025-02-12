namespace BuilderPattern
{
    // Nadzorca
    public class PresentationSupervisor
    {
        private IPresentationBuilder builder;

        public PresentationSupervisor(IPresentationBuilder builder)
        {
            this.builder = builder;
        }

        public void Build(Presentation presentation)
        {
            builder.AddSlide(new Slide("Copyright"));

            foreach (Slide slide in presentation.slides)
            {
                builder.AddSlide(slide);
            }
        }
    }
}
