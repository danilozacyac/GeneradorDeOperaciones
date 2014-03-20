using System;
using System.Linq;

namespace GeneradorDeOperaciones.Utilities
{
    public class AppUtilities
    {
        public static Random random;
        public static bool currentState = false;
        /// <summary>
        /// Returns a random Boolean value.
        /// </summary>
        public static bool GetRandomBoolean()
        {
            return new Random().Next(100) % 2 == 0;
        }
    }
}
