using System;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace GeneradorDeOperaciones.Printable
{
    public class HeaderFooter : iTextSharp.text.pdf.PdfPageEventHelper
    {

        //override the OnStartPage event handler to add our header
        public override void OnStartPage(PdfWriter writer, Document doc)
        {
            ////I use a PdfPtable with 2 columns to position my footer where I want it
            //PdfPTable headerTbl = new PdfPTable(2);

            ////set the width of the table to be the same as the document
            //headerTbl.TotalWidth = doc.PageSize.Width;

            ////Center the table on the page
            //headerTbl.HorizontalAlignment = Element.ALIGN_CENTER;

            ////Create a paragraph that contains the footer text
            //Paragraph para = new Paragraph("Comisión de Venecia", Fuentes.Venecia);

            ////create a cell instance to hold the text
            //PdfPCell cell = new PdfPCell(para);

            ////set cell border to 0
            //cell.Border = 0;

            ////add some padding to bring away from the edge
            //cell.PaddingLeft = 10;

            ////add cell to table
            //headerTbl.AddCell(cell);

            ////create new instance of Paragraph for 3rd cell text
            //para = new Paragraph("CoIDH", Fuentes.CIDH);

            ////create new instance of cell to hold the text
            //cell = new PdfPCell(para);

            ////align the text to the right of the cell
            //cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            ////set border to 0
            //cell.Border = 0;

            //// add some padding to take away from the edge of the page
            //cell.PaddingRight = 10;

            ////add the cell to the table
            //headerTbl.AddCell(cell);

            ////write the rows out to the PDF output stream.
            //headerTbl.WriteSelectedRows(0, -1, 0, (doc.PageSize.Height - 10), writer.DirectContent);
        }

        //override the OnPageEnd event handler to add our footer
        public override void OnEndPage(PdfWriter writer, Document doc)
        {
            //I use a PdfPtable with 2 columns to position my footer where I want it
            PdfPTable footerTbl = new PdfPTable(2);

            //set the width of the table to be the same as the document
            footerTbl.TotalWidth = doc.PageSize.Width;

            //Center the table on the page
            footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;

            //Create a paragraph that contains the footer text
            Paragraph para;// = new Paragraph("", Fuentes.footer);
            DateTime time = DateTime.Now;              // Use current time
            string format = "dd/MM/yyyy";    // Use this format
            para = new Paragraph(time.ToString(format), Fuentes.Footer);

            //add a carriage return
            para.Add(Environment.NewLine);
            para.Add("");

            Anchor anchor = new Anchor("La web de Danilo", Fuentes.Hyperlink);
            anchor.Reference = "http://www.lawebdedanilo.net";

            //create a cell instance to hold the text
            PdfPCell cell = new PdfPCell(anchor);

            //set cell border to 0
            cell.Border = 0;

            //add some padding to bring away from the edge
            cell.PaddingLeft = 10;

            //add cell to table
            footerTbl.AddCell(cell);


            //Creo el contenido de la 2da celda
            int pageN = writer.PageNumber;
            //DateTime time = DateTime.Now;              // Use current time
            //string format = "dd/MM/yyyy";    // Use this format
            //para = new Paragraph(time.ToString(format), Fuentes.footer);

            //para.Add(Environment.NewLine);
            para = new Paragraph(pageN.ToString(), Fuentes.Footer);

            //create new instance of cell to hold the text
            cell = new PdfPCell(para);

            //align the text to the right of the cell
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //set border to 0
            cell.Border = 0;

            // add some padding to take away from the edge of the page
            cell.PaddingRight = 10;

            //add the cell to the table
            footerTbl.AddCell(cell);

            //write the rows out to the PDF output stream.
            footerTbl.WriteSelectedRows(0, -1, 0, (doc.BottomMargin + 10), writer.DirectContent);
        }


    }
}
