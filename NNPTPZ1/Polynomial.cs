﻿using System.Collections.Generic;

namespace NNPTPZ1
{

    namespace Mathematics
    {
        public class Polynomial
        {
            /// <summary>
            /// Coe
            /// </summary>
            public List<ComplexNumber> ListOfComplexNumbers { get; set; }

            /// <summary>
            /// Constructor
            /// </summary>
            public Polynomial() => ListOfComplexNumbers = new List<ComplexNumber>();

            public void Add(ComplexNumber newComplexNumber) =>
                ListOfComplexNumbers.Add(newComplexNumber);

            /// <summary>
            /// Derives this polynomial and creates new one
            /// </summary>
            /// <returns>Derivated polynomial</returns>
            public Polynomial Derive()
            {
                Polynomial newPolynomial = new Polynomial();
                for (int i = 1; i < ListOfComplexNumbers.Count; i++)
                {
                    newPolynomial.ListOfComplexNumbers.Add(ListOfComplexNumbers[i].Multiply(new ComplexNumber() { RealElement = i }));
                }

                return newPolynomial;
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="pointAsDecimalNumber">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Eval(double pointAsDecimalNumber)
            {
                var evaluationResult = Eval(new ComplexNumber() { RealElement = pointAsDecimalNumber, ImaginaryElement = 0 });
                return evaluationResult;
            }

            /// <summary>
            /// Evaluates polynomial at given point
            /// </summary>
            /// <param name="pointAsComplexNumber">point of evaluation</param>
            /// <returns>y</returns>
            public ComplexNumber Eval(ComplexNumber pointAsComplexNumber)
            {
                int power;
                ComplexNumber evaluatedComplexNumber = ComplexNumber.Zero;
                for (int i = 0; i < ListOfComplexNumbers.Count; i++)
                {
                    ComplexNumber complexNumberFromList = ListOfComplexNumbers[i];
                    ComplexNumber multipliedComplexNumber = pointAsComplexNumber;
                    power = i;

                    if (i > 0)
                    {
                        for (int j = 0; j < power - 1; j++)
                            multipliedComplexNumber = multipliedComplexNumber.Multiply(pointAsComplexNumber);

                        complexNumberFromList = complexNumberFromList.Multiply(multipliedComplexNumber);
                    }

                    evaluatedComplexNumber = evaluatedComplexNumber.Add(complexNumberFromList);
                }

                return evaluatedComplexNumber;
            }

            /// <summary>
            /// ToString
            /// </summary>
            /// <returns>String repr of polynomial</returns>
            public override string ToString()
            {
                string StringVersionOfPolynomial = "";
                
                for (int i = 0; i < ListOfComplexNumbers.Count; i++)
                {
                    StringVersionOfPolynomial += ListOfComplexNumbers[i];
                    if (i > 0)
                    {

                        StringVersionOfPolynomial += new string('x', i);
                        //odstranit cyklus za rovnou přidání daého počtu x
                        //for (int j = 0; j < i; j++)
                        //{
                        //    StringVersionOfPolynomial += "x";
                        //}
                    }
                    if (i + 1 < ListOfComplexNumbers.Count)
                        StringVersionOfPolynomial += " + ";
                }
                return StringVersionOfPolynomial;
            }
        }
    }
}
