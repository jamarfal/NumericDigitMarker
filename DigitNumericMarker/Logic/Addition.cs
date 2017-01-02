using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitNumericMarker
{
    class Addition : MathOperation
    {

        #region MathOperation implementation
        public float operate(float firstArgument, float secondArgument)
        {
            return firstArgument + secondArgument;
        }
        #endregion
    }
}
