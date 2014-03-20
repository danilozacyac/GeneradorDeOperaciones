using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GeneradorDeOperaciones.Printable
{
    public class ImprimeOperaciones
    {
        private iTextSharp.text.Document myDocument;

        List<Operaciones>[] opera;

        public ImprimeOperaciones(List<Operaciones> totalSuma, List<Operaciones> totalResta,
            List<Operaciones> totalMulti, List<Operaciones> totalDivi)
        {
            

            List<Operaciones>[] operaciones = { totalSuma, totalResta, totalMulti, totalDivi };
            opera = operaciones;
        }

        public void Operaciones()
        {
            
            myDocument = new iTextSharp.text.Document(PageSize.A4, 50, 50, 50, 50);
            string documento = Path.GetTempFileName() + ".pdf";

            try
            {
                PdfWriter writer = PdfWriter.GetInstance(myDocument, new FileStream(documento, FileMode.Create));
                HeaderFooter pdfPage = new HeaderFooter();
                writer.PageEvent = pdfPage;
                Paragraph para;

                myDocument.Open();
                myDocument.NewPage();

                para = new Paragraph(" ");
                myDocument.Add(para);

                PdfPTable table = new PdfPTable(4);
                //table.TotalWidth = 400;
                table.WidthPercentage = 100;

                float[] widths = new float[] { 3f, 3f, 3f, 3f };
                table.SetWidths(widths);

                table.SpacingBefore = 20f;
                table.SpacingAfter = 30f;

                PdfPCell cell;

                foreach (List<Operaciones> operacion in opera)
                {
                    foreach (Operaciones oper in operacion)
                    {
                        cell = new PdfPCell(oper.Chunk);
                        cell.Colspan = 0;
                        cell.Border = 0;
                        cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
                        table.AddCell(cell);
                    }
                }

                

                myDocument.Add(table);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            finally
            {
                myDocument.Close();
                System.Diagnostics.Process.Start(documento);
            }
        }
    }
}