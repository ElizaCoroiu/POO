using System;
using System.Collections.Generic;
using System.Text;

namespace POO_Matrix
{
    internal class Matrix
    {
        private int rows, columns;
        private float[,] matrix;
        private static Random rng = new Random();

        private int max = 1;
       
        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new float[this.rows, this.columns];
        }

        public Matrix(int n) : this(n, n)
        {
       
        }

        public void RandomInitMatrix()
        {
            int n = this.rows;
            int m = this.columns;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = Matrix.rng.Next(10);
                }
            }
        }

        public Matrix Multiply(Matrix m2)
        {
            if (this.columns != m2.rows)
            {
                throw new ImpossibleMatrixOperationException();
            }
            int n = this.rows;
            int m = m2.columns;

            Matrix a = new Matrix(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    float suma = 0;
                    for (int k = 0; k < this.columns; k++)
                    {
                        suma += this.matrix[i, k] * m2.matrix[k, j];
                    }
                    a.matrix[i, j] = suma;
                }
            }

            return a;
        }

        internal Matrix GetInverseMatrix(float det)
        {
            int n = this.rows;
            Matrix transpose = this.GetTransposedMatrix();
            Console.WriteLine("Transpusa:");
            Console.WriteLine(transpose);
            
            Matrix adjugate = transpose.GetAdjugateMatrix();
            Console.WriteLine("Matricea adjuncta: ");
            Console.WriteLine(adjugate);
            Matrix inverse_matrix = new Matrix(n, n);
          

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    inverse_matrix.matrix[i, j] = adjugate.matrix[i, j] / det;
                }
            }
            return inverse_matrix;
        }

        public Matrix GetAdjugateMatrix()
        {
            Matrix a = new Matrix(this.rows, this.columns);

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    Matrix b = this.Reduce(this, i, j);
                    a.matrix[i, j] = (int)Math.Pow(-1, (i + j)) * b.GetDeterminant();
                }
            }
            return a; 
        }

        public Matrix Reduce(Matrix old, int lin, int col)
        {
            int n = old.rows;
            int m = old.columns;

            Matrix tmp = new Matrix(n - 1, m - 1);
            for (int i = 0; i < lin; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp.matrix[i, j] = old.matrix[i, j];
                }
            }

            for (int i = 0; i < lin; i++)
            {
                for (int j = col + 1; j < m; j++)
                {
                    tmp.matrix[i, j - 1] = old.matrix[i, j];
                }
            }

            for (int i = lin + 1; i < n; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp.matrix[i - 1, j] = old.matrix[i, j];
                }
            }

            for (int i = lin + 1; i < n; i++)
            {
                for (int j = col + 1; j < m; j++)
                {
                    tmp.matrix[i - 1, j - 1] = old.matrix[i, j];
                }
            }

            return tmp;
        }

        public float GetDeterminant()
        {
            int n = this.rows;
            int m = this.columns;

            if(n != m)
            {
                throw new ImpossibleMatrixOperationException();
            }

            if (n == 2)
            {
                return this.matrix[0, 0] * this.matrix[1, 1] - this.matrix[0, 1] * this.matrix[1, 0];
            }
            if (n == 3)
            {
                return (this.matrix[0, 0] * this.matrix[1, 1] * this.matrix[2, 2] + this.matrix[1, 0] * this.matrix[2, 1] * this.matrix[0, 2] + this.matrix[0, 1] * this.matrix[1, 2] * this.matrix[2, 0]) -
                    (this.matrix[0, 2] * this.matrix[1, 1] * this.matrix[2, 0] + this.matrix[0, 1] * this.matrix[1, 0] * this.matrix[2, 2] + this.matrix[1, 2] * this.matrix[2, 1] * this.matrix[0, 0]);
            }
            float sum = 0;
            for (int i = 0; i < n; i++)
            {
                Matrix aux = new Matrix(n - 1, n - 1);
                int p = 0;
                int q = 0;
                for (int k = 1; k < n; k++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j != i)
                        {
                            aux.matrix[p, q] = this.matrix[k, j];
                            q++;
                        }
                    }
                    q = 0;
                    p++;
                }
                if ((i + 2) % 2 == 0)
                {
                    sum += this.matrix[0, 1] * aux.GetDeterminant();
                }
                else
                {
                    sum -= this.matrix[0, 1] * aux.GetDeterminant();
                }
            }


            return sum;
        }

        public Matrix GetTransposedMatrix()
        {
            Matrix a = new Matrix(this.rows, this.columns);

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    a.matrix[i, j] = this.matrix[j, i];
                }
            }
            return a;
        }

        public Matrix Pow(int n)
        {
            Matrix a = new Matrix(this.rows, this.columns);
            while (n > 0)
            {
                a = this.Multiply(this);
                n--;
            }
            return a;
        }

        public Matrix Subtract(Matrix m2)
        {
            if (this.rows != m2.rows && this.columns != m2.columns)
            {
                throw new ImpossibleMatrixOperationException();
            }

            int n = this.rows;
            int m = this.columns;

            Matrix a = new Matrix(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a.matrix[i, j] = this.matrix[i, j] - m2.matrix[i, j];
                }
            }

            return a;
        }

        public Matrix Add(Matrix m2)
        {
            if (this.rows != m2.rows && this.columns != m2.columns)
            {
                throw new ImpossibleMatrixOperationException();
            }

            int n = this.rows;
            int m = this.columns;

            Matrix a = new Matrix(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a.matrix[i, j] = this.matrix[i, j] + m2.matrix[i, j];
                }
            }

            return a;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string formatString = "{0, ";
       
            formatString += max;
            formatString += "}";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sb.AppendFormat(formatString, matrix[i, j]);
                    sb.Append(" ");
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}


