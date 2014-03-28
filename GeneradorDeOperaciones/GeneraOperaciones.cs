using System;
using System.Linq;
using GeneradorDeOperaciones.Printable;
using GeneradorDeOperaciones.Utilities;
using iTextSharp.text;

namespace GeneradorDeOperaciones
{
    public class GeneraOperaciones
    {
        private static String SpaceNumber(int oper)
        {
            return (oper < 100) ? "  " + oper : oper.ToString();
        }

        private static Phrase GetMathPhrase(int operadorA, int operadorB, char operador)
        {
            Phrase phrase = new Phrase();
            if (AppUtilities.currentState)
            {
                Chunk chunk = new Chunk(SpaceNumber(operadorA) + " " + operador +" " + SpaceNumber(operadorB), Fuentes.OperacionLineal);
                phrase.Add(chunk);

                return phrase;
            }
            else
            {
                Chunk chunk1 = new Chunk("   " + SpaceNumber(operadorA), Fuentes.Operacion);
                Chunk chunk2 = new Chunk("\n " + operador + " " + SpaceNumber(operadorB) + "\n\n\n\n", Fuentes.OperacionSumando);
                phrase.Add(chunk1);
                phrase.Add(chunk2);

                return phrase;
            }
        }

        private static Phrase GetMathPhrase(String operacion)
        {
            Phrase phrase = new Phrase();
            
                Chunk chunk1 = new Chunk(operacion, Fuentes.Operacion);
                Chunk chunk2 = new Chunk("\n  ", Fuentes.OperacionSumando);
                
                phrase.Add(chunk1);
                phrase.Add(chunk2);
                phrase.Add(chunk2);
                phrase.Add(chunk2);
                phrase.Add(chunk2);
                phrase.Add(chunk2);

                return phrase;
            
        }


        public static Operaciones GetSuma(int maxValue)
        {
            Operaciones operacion = new Operaciones();

            int operadorA = AppUtilities.random.Next(maxValue);
            int operadorB = AppUtilities.random.Next(maxValue);

            int result = operadorA + operadorB;

            String operacionStr = (AppUtilities.currentState) ? 
                                        SpaceNumber(operadorA) + " + " + SpaceNumber(operadorB) :
                                        "    " + SpaceNumber(operadorA) + "\n + " + SpaceNumber(operadorB);


            operacion.Chunk = GetMathPhrase(operadorA, operadorB, '+');
            operacion.Operacion = operacionStr;
            operacion.ResultadoCorrecto = result;


            return operacion;
        }

        public static Operaciones GetResta(int maxValue)
        {
            Operaciones operacion = new Operaciones();

            int operadorA = AppUtilities.random.Next(maxValue);
            int operadorB = AppUtilities.random.Next(maxValue);

            while (operadorB > operadorA)
                operadorB = AppUtilities.random.Next(999);

            int result = operadorA - operadorB;
            String operacionStr = (AppUtilities.currentState) ?
                                        SpaceNumber(operadorA) + " - " + SpaceNumber(operadorB) :
                                        "    " + SpaceNumber(operadorA) + "\n - " + SpaceNumber(operadorB);

            operacion.Chunk = GetMathPhrase(operadorA, operadorB, '-');
            operacion.Operacion = operacionStr;
            operacion.ResultadoCorrecto = result;


            return operacion;
        }

        public static Operaciones GetMultiplicacion(int maxValue)
        {

            Operaciones operacion = new Operaciones();

            int operadorA = AppUtilities.random.Next(2, maxValue);
            int operadorB = AppUtilities.random.Next(2, LevelMaxValues.MultiplicadorValue);

            int result = operadorA * operadorB;
            String operacionStr = (AppUtilities.currentState) ?
                                        SpaceNumber(operadorA) + " x " + SpaceNumber(operadorB) :
                                        "    " + SpaceNumber(operadorA) + "\n x " + SpaceNumber(operadorB);

            operacion.Chunk = GetMathPhrase(operadorA, operadorB, 'x');
            operacion.Operacion = operacionStr;
            operacion.ResultadoCorrecto = result;


            return operacion;
        }

        public static Operaciones GetDivision(int maxValue)
        {
            Operaciones operacion = new Operaciones();

            int dividendo = AppUtilities.random.Next(2, maxValue);
            int divisor = AppUtilities.random.Next(2, ((LevelMaxValues.MultiplicadorValue == 1000 ) ? LevelMaxValues.MultiplicadorValue / 10 : LevelMaxValues.MultiplicadorValue )) ;

            while (dividendo < divisor)
            {
                dividendo = AppUtilities.random.Next(2, maxValue);
            }

            operacion.Chunk = GetMathPhrase(divisor + " | " + dividendo);
            operacion.Operacion = divisor + " | " + dividendo;


            return operacion;
        }
    }
}
