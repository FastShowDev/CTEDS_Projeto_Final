using System;
using System.Windows.Controls;

namespace Calculadora.Models.MatricesModels
{
    public class Matrix
    {
        public int rowsNumber { get; set; }
        public int columnsNumber { get; set; }

        public double[,] values { get; set; }

        public Matrix(int rowsNumber, int columnsNumber)
        {
            this.rowsNumber = rowsNumber;
            this.columnsNumber = columnsNumber;

            values = new double[rowsNumber, columnsNumber];
        }

        public Matrix(int rowsNumber, int columnsNumber, double standardValue)
        {
            this.rowsNumber = rowsNumber;
            this.columnsNumber = columnsNumber;

            values = new double[rowsNumber, columnsNumber];

            FillMatrix(standardValue);
        }

        public void FillMatrix(double value)
        {
            for(int i = 0; i < rowsNumber;i++)
            {
                for(int j = 0; j < columnsNumber; j++)
                {
                    values[i, j] = value;
                }
            }
        }

        public override String ToString()
        {
            string text = string.Empty;
            for (int i = 0; i < rowsNumber; i++)
            {
                for (int j = 0; j < columnsNumber; j++)
                {
                    text += values[i, j].ToString() + " ";
                }
                text += "\n";
            }
            return text;
        }

    }
}
