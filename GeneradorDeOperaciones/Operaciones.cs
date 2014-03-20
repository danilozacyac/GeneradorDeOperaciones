using System;
using System.Linq;
using iTextSharp.text;

namespace GeneradorDeOperaciones
{
    public class Operaciones
    {
        private String operacion;

        public String Operacion
        {
            get { return this.operacion; }
            set { this.operacion = value; }
        }

        private Phrase chunk;
        public Phrase Chunk
        {
            get { return this.chunk; }
            set { this.chunk = value; }
        }

        private int resultadoCorrecto;
        public int ResultadoCorrecto
        {
            get { return this.resultadoCorrecto; }
            set { this.resultadoCorrecto = value; }
        }

        private int resultadoUsuario;
        public int ResultadoUsuario
        {
            get { return this.resultadoUsuario; }
            set { this.resultadoUsuario = value; }
        }
    }
}
