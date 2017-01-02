using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitNumericMarker
{
    class Calculator
    {
        public float FirstOperator { get; set; }
        public float SecondOperator { get; set; }
        public MathOperation Operation { get; set; }



        public Calculator(MathOperation operation)
        {
            this.FirstOperator = 0;
            this.SecondOperator = 0;
            this.Operation = operation;
        }

        public Calculator(float firstOperator, float secondOperator, MathOperation operation)
        {
            this.FirstOperator = firstOperator;
            this.SecondOperator = secondOperator;
            this.Operation = operation;
        }

        public float performOperation()
        {
            return Operation.operate(FirstOperator, SecondOperator);
        }

        public void resetOperators()
        {
            this.FirstOperator = 0.0f;
            this.SecondOperator = 0.0f;
        }


    }
}
