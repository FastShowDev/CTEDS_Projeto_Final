using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculadora.Models.MatricesModels
{
    public class MatrixCalculator
    {
        public Matrix SumMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.columnsNumber != matrix2.columnsNumber && matrix1.rowsNumber != matrix2.rowsNumber)
            {
                throw new ArgumentException("As matrizes devem ter o mesmo número de linhas e colunas");
            }

            Matrix result = new Matrix(matrix1.rowsNumber, matrix2.columnsNumber);
            for (int i = 0; i < matrix1.rowsNumber; i++)
            {
                for (int j = 0; j < matrix1.columnsNumber; j++)
                {
                    result.values[i, j] = matrix1.values[i, j] + matrix2.values[i, j];
                }
            }
            return result;
        }


        public Matrix MultiplyMatrices(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.columnsNumber != matrix2.rowsNumber)
            {
                throw new ArgumentException("O número de colunas da matriz 1 deve ser igual ao de linhas da matriz 2");
            }

            Matrix result = new Matrix(matrix1.rowsNumber, matrix2.columnsNumber);
            for (int i = 0; i < matrix1.rowsNumber; i++)
            {
                for (int j = 0; j < matrix1.columnsNumber; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < matrix1.columnsNumber; k++)
                    {
                        sum += matrix1.values[i, k] * matrix2.values[k, j];
                    }
                    result.values[i, j] = sum;
                }
            }
            return result;
        }

        public void SwitchRows(QuadraticMatrix matrix, int i, int j)
        {
            double aux;
            for (int k = 0; k < matrix.order; k++)
            {
                aux = matrix.values[i, k];
                matrix.values[i, k] = matrix.values[j, k];
                matrix.values[j, k] = aux;
            }
        }

        public int TriangularizeMatrix(QuadraticMatrix matrix)
        {
            int sinal = 1;
            for (int i = 0; i < matrix.order - 1; i++)
            {
                double max = Math.Abs(matrix.values[i, i]);
                int maxIndex = i;

                for (int m = i + 1; m < matrix.order; m++)
                {
                    if (max < Math.Abs(matrix.values[i, m]))
                    {
                        max = Math.Abs(matrix.values[i, m]);
                        maxIndex = m;
                    }
                }

                if (maxIndex != i)
                {
                    sinal *= -1;
                    SwitchRows(matrix, i, maxIndex);
                }

                if (matrix.values[i, i] == 0)
                {
                    return 0;
                }
                else
                {
                    for (int j = i + 1; j < matrix.order; j++)
                    {
                        double factor = (-1) * matrix.values[j, i] / matrix.values[i, i];
                        matrix.values[j, i] = 0;
                        for (int k = i + 1; k < matrix.order; k++)
                        {
                            matrix.values[j, k] += factor * matrix.values[i, k];
                        }
                    }
                }
            }
            return sinal;
        }

        public double CalculateDeterminant(QuadraticMatrix matrix)
        {
            int sinal = TriangularizeMatrix(matrix);
            if (sinal == 0) return 0;

            double determinant = 1;
            for(int i = 0; i < matrix.order; i++)
            {
                determinant *= matrix.values[i, i];
            }
            return determinant * sinal;
        }
    }
}
