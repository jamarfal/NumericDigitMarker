using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DigitNumericMarker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        #region Properties
        const String ZERO = "0";
        Calculator calculator;
        float result, firstOperator, secondOperator;
        bool isNewNumber = true, isNewOperation = true, pressedOperaton = false;
        #endregion

  

        public MainPage()
        {
            this.InitializeComponent();
            textDisplay.Text = "0";
            initCalculator();
        }

        private void initCalculator()
        {
            calculator = new Calculator(new Addition());
        }

        private void OnTanNumberButton(object sender, TappedRoutedEventArgs e)
        {
            Button tappedButton = sender as Button;

            string currentDisplayText = getTextInDisplay();

            textDisplay.Text = currentDisplayText + tappedButton.Content;
        }

      

        private void OnTappedButton(object sender, TappedRoutedEventArgs e)
        {

            Button tappedButton = sender as Button;

            switch (tappedButton.Name)
            {
                case "btnZero":
                    showZeroInDisplay();
                    break;
                case "btnOne":
                case "btnTwo":
                case "btnThree":
                case "btnFour":
                case "btnFive":
                case "btnSix":
                case "btnSeven":
                case "btnEight":
                case "btnNine":
                    string numberStr = tappedButton.Content.ToString();
                    showNumberInDisplay(numberStr);
                    break;
                case "btnClear":
                    clearButtonAction();
                    break;
                case "btnAddition":
                    calculateActionButton();
                    calculator.Operation = new Addition();
                    break;
                case "btnSubstraction":
                    calculateActionButton();
                    calculator.Operation = new Subtraction();
                    break;
                case "btnDivide":
                    calculateActionButton();
                    calculator.Operation = new Divide();
                    break;
                case "btnMultiply":
                    calculateActionButton();
                    calculator.Operation = new Multiply();
                    break;
                case "btnEqual":
                    equalButtonAction();
                    break;

            }
        }

        private void equalButtonAction()
        {
            if (isNewOperation)
            {
                initOperationValues();
            }
            else
            {
                calculate();
                textDisplay.Text = removeZeros(result.ToString());
            }
            isNewNumber = true;
            isNewOperation = true;
            result = 0;
        }

        private void calculateActionButton()
        {
            if (!pressedOperaton)
            {
               
                if (isNewOperation)
                {
                    initOperationValues();
                    isNewOperation = false;
                    isNewNumber = true;
                }
                else
                {
                    calculate();
                    textDisplay.Text = removeZeros(result.ToString());
                    isNewNumber = true;
                }
            }
            pressedOperaton = true;
        }

        private String removeZeros(String number)
        {
            int lastDigit = number.Length - 1;

            while (number[lastDigit] == '0')
            {
                number = number.Substring(0, lastDigit);
                lastDigit = number.Length - 1;
            }

            if (number[lastDigit] == '.')
            {
                number = number.Substring(0, lastDigit);
            }
            return number;
        }

        private void initOperationValues()
        {
            float.TryParse(getTextInDisplay(), out firstOperator);
        
            result = firstOperator;
        }

        private void calculate()
        {
            float.TryParse(getTextInDisplay(), out secondOperator);     
            calculator.FirstOperator = result;
            calculator.SecondOperator = secondOperator;
            result = calculator.performOperation();
        }

        private void clearButtonAction()
        {
            textDisplay.Text = ZERO;
            result = 0.0f;
            calculator.resetOperators();
            isNewNumber = true;
            isNewOperation = true;
            pressedOperaton = false;
        }

        private void showNumberInDisplay(string numberStr)
        {
            if (isNewNumber)
            {
                textDisplay.Text = numberStr;
                isNewNumber = false;
                pressedOperaton = false;
            }
            else
            {
                textDisplay.Text = getTextInDisplay() + numberStr;
            }
        }

        private void showZeroInDisplay()
        {
            if (isNewNumber)
            {
                textDisplay.Text = ZERO;
                isNewNumber = true;
                pressedOperaton = false;
            }
            else
            {
                textDisplay.Text = getTextInDisplay() + ZERO;
                isNewNumber = false;
                pressedOperaton = false;
            }
        }

        private string getTextInDisplay()
        {
            return textDisplay.Text;
        }
    }
}
