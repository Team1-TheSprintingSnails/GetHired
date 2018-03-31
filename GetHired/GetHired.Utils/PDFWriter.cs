using System.IO;
using GetHired.Utils.Contracts;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.Rendering;
using PdfSharp.Pdf;

namespace GetHired.Utils
{
    public class PDFWriter : IFileWriter
    {
        private string path;
        private string fileName;

        public PDFWriter()
        {
            this.path = "./../../../PDF-Exports/";
            this.fileName = "document.pdf";
        }


        /// <summary>
        /// Exports document (invokes all needed methods to create a pdf)
        /// </summary>
        public void WriteFile()
        {
            var doc = this.CreateDocument();
            this.DefineStyles(doc);
            this.FillContent(doc);
            var pdf = this.Render(doc);
            this.Save(pdf);
        }

        /// <summary>
        /// Creates new document
        /// </summary>
        /// <returns></returns>
        private Document CreateDocument()
        {
            var document = new Document();

            return document;
        }

        /// <summary>
        /// Defines document styles
        /// </summary>
        /// <param name="doc"></param>
        private void DefineStyles(Document doc)
        {
            doc.Styles[StyleNames.Normal].Font.Name = "Times New Roman";

            doc.Styles[StyleNames.Header].ParagraphFormat.Alignment = ParagraphAlignment.Right;
            doc.Styles[StyleNames.Header].ParagraphFormat.Font.Bold = true;
        }

        /// <summary>
        /// Fill the document with some content
        /// </summary>
        /// <param name="doc"></param>
        private void FillContent(Document doc)
        {
            var section = doc.AddSection();

            var paragraph = section.Headers.Primary.AddParagraph();

            var img = paragraph.AddImage("./../../Resources/image.jpg");
            img.LockAspectRatio = true;
            img.Height = 100;
            img.RelativeVertical = RelativeVertical.Line;
            img.RelativeHorizontal = RelativeHorizontal.Column;
            img.Top = ShapePosition.Top;
            img.Left = ShapePosition.Left;


            paragraph = section.Elements.AddParagraph("GET HIRED");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 20;

            paragraph = section.Elements.AddParagraph("Team 1 - The Sprinting Snails");
            paragraph.Format.Font.Bold = true;

            section.Elements.AddParagraph();

            paragraph = section.AddParagraph("Team Members");
            paragraph.Format.Font.Underline = Underline.Dash;

            section.Elements.AddParagraph("Irina Hristova");
            section.Elements.AddParagraph("Stilyan Mladenov");
            section.Elements.AddParagraph("Petko Petkov");

            paragraph.Format.Font.Underline = Underline.Dash;

            var table = section.AddTable();
            table.AddColumn();
            table.Borders.Visible = true;


            section.Footers.Primary.AddParagraph().AddDateField();
        }

        /// <summary>
        /// Renders document 
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private PdfDocument Render(Document doc)
        {
            var renderer = new PdfDocumentRenderer {Document = doc};
            renderer.RenderDocument();
            return renderer.PdfDocument;
        }

        /// <summary>
        /// Save the created document local
        /// </summary>
        /// <param name="doc"></param>
        private void Save(PdfDocument doc)
        {
            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }

            doc.Save(this.path + this.fileName);
        }
    }
}