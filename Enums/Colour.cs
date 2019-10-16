using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Poolgramming
{
    public enum Colour
    {
        None,
        Yellow,
        Red,
    }

    static class ColourExtensions
    {
        public static Colour OppositeColour(this Colour colour)
        {
            switch (colour)
            {
                case Colour.Yellow:
                    return Colour.Red;
                case Colour.Red:
                    return Colour.Yellow;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }
    }
}
