namespace BuilderPattern
{
    // Concrete Builder A
    public class PdfPresentationBuilder : IPresentationBuilder
    {
        private PdfDocument document = new PdfDocument();

        public void AddSlide(Slide slide)
        {
            document.AddPage(slide.Text);
        }

        public PdfDocument GetPdfDocument()
        {
            return document;
        }
    }
}
