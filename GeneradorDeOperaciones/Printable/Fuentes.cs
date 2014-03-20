using System;
using System.Linq;
using iTextSharp.text;

namespace GeneradorDeOperaciones.Printable
{
    public class Fuentes
    {

        public static Font Hyperlink
        {
            get
            {
                BaseColor blue = new BaseColor(0, 0, 255);
                Font font = FontFactory.GetFont("Arial", 12, Font.UNDERLINE, blue);
                return font;
            }
        }

        public static Font Operacion
        {
            get
            {
                BaseColor black = new BaseColor(0, 0, 0);
                Font font = FontFactory.GetFont("Arial", 18, Font.NORMAL, black);
                return font;
            }
        }

        public static Font OperacionSumando
        {
            get
            {
                BaseColor black = new BaseColor(0, 0, 0);
                Font font = FontFactory.GetFont("Arial", 18, Font.UNDERLINE, black);
                return font;
            }
        }

        public static Font OperacionLineal
        {
            get
            {
                BaseColor black = new BaseColor(0, 0, 0);
                Font font = FontFactory.GetFont("Arial", 15, Font.NORMAL, black);
                return font;
            }
        }

        public static Font NomExpdUnder
        {
            get
            {
                BaseColor black = new BaseColor(0, 0, 0);
                Font font = FontFactory.GetFont("Arial", 12, Font.UNDERLINE, black);
                return font;
            }
        }

        public static Font EncabezadoColumna
        {
            get
            {
                BaseColor black = new BaseColor(0, 0, 0);
                Font font = FontFactory.GetFont("Arial", 12, Font.BOLD, black);
                return font;
            }
        }

        public static Font ContenidoCelda
        {
            get
            {
                BaseColor black = new BaseColor(0, 0, 0);
                Font font = FontFactory.GetFont("Arial", 10, Font.NORMAL, black);
                return font;
            }
        }

        /// <summary>
        /// Fuentes encabezado y Pie de Pagina
        /// </summary>

        public static Font Footer
        {
            get
            {
                BaseColor grey = new BaseColor(128, 128, 128);
                Font font = FontFactory.GetFont("Arial", 9, Font.NORMAL, grey);
                return font;
            }
        }

        public static Font Header
        {
            get
            {
                BaseColor grey = new BaseColor(255, 0, 0);
                Font font = FontFactory.GetFont("Arial", 16, Font.NORMAL, grey);
                return font;
            }
        }
    }
}
