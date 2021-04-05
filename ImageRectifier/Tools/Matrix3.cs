using System;

namespace MathTools
{
    public struct Matrix3
    {
        private readonly float[,] a;

        public Matrix3(float a11, float a12, float a13, float a21, float a22, float a23, float a31, float a32, float a33)
        {
            a = new float[,] { { a11, a12, a13 },
                             { a21, a22, a23 },
                             { a31, a32, a33 }
                           };
        }
        public Matrix3(Vector3 column1, Vector3 column2, Vector3 column3)
        {
            a = new float[,] { { column1.x, column2.x, column3.x },
                             { column1.y, column2.y, column3.y },
                             { column1.z, column2.z, column3.z }
                           };
        }
        public Matrix3(float[,] a)
        {
            if (a.GetLength(0) == 3 && a.GetLength(1) == 3)
            {
                this.a = a;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        
        public Matrix3 ReplaceColumn(int index, Vector3 newColumn)
        {
            float[,] result = new float[3,3];
            for (int x = 0; x < 3; x++)
            {
                if (x == index)
                {
                    for (int y = 0; y < 3; y++)
                        result[y, x] = newColumn.GetDimension(y);
                }
                else
                {
                    for (int y = 0; y < 3; y++)
                        result[y, x] = a[y, x];
                }
            }

            return new Matrix3(result);
        }
        public Matrix3 ScaleColumn(int index, float scale)
        {
            float[,] result = new float[3, 3];
            for (int x = 0; x < 3; x++)
            {
                if (x == index)
                {
                    for (int y = 0; y < 3; y++)
                        result[y, x] = a[y, x] * scale;
                }
                else
                {
                    for (int y = 0; y < 3; y++)
                        result[y, x] = a[y, x];
                }
            }

            return new Matrix3(result);
        }

        public Vector3 Solve(Vector3 b)
        {
            float determinant = Determinant();
            if (determinant == 0)
                throw new Exception("Not solveable");
            
            return new Vector3(this.ReplaceColumn(0, b).Determinant() / determinant,
                               this.ReplaceColumn(1, b).Determinant() / determinant,
                               this.ReplaceColumn(2, b).Determinant() / determinant);
        }
        public float Determinant()
        {
            return a[0, 0] * a[1, 1] * a[2, 2]
                 + a[0, 1] * a[1, 2] * a[2, 0]
                 + a[0, 2] * a[1, 0] * a[2, 1]
                 - a[0, 2] * a[1, 1] * a[2, 0]
                 - a[0, 1] * a[1, 0] * a[2, 2]
                 - a[0, 0] * a[1, 2] * a[2, 1];
        }
        public Matrix3 Adjugate()
        {
            return new Matrix3(a[1, 1] * a[2, 2] - a[1, 2] * a[2, 1], a[0, 2] * a[2, 1] - a[0, 1] * a[2, 2], a[0, 1] * a[1, 2] - a[0, 2] * a[1, 1],
                               a[1, 2] * a[2, 0] - a[1, 0] * a[2, 2], a[0, 0] * a[2, 2] - a[0, 2] * a[2, 0], a[0, 2] * a[1, 0] - a[0, 0] * a[1, 2],
                               a[1, 0] * a[2, 1] - a[1, 1] * a[2, 0], a[0, 1] * a[2, 0] - a[0, 0] * a[2, 1], a[0, 0] * a[1, 1] - a[0, 1] * a[1, 0]);
        }
        public Matrix3 Inverse()
        {
            float determinant = Determinant();
            if (determinant == 0)
                throw new Exception("Not invertible.");

            return Adjugate() / Determinant();
        }

        public static Matrix3 operator *(Matrix3 matrix, float scale)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    matrix.a[y, x] *= scale;
                }
            }

            return matrix;
        }
        public static Vector3 operator *(Matrix3 matrix, Vector3 vector)
        {
            return new Vector3(matrix.a[0, 0] * vector.x + matrix.a[0, 1] * vector.y + matrix.a[0, 2] * vector.z,
                               matrix.a[1, 0] * vector.x + matrix.a[1, 1] * vector.y + matrix.a[1, 2] * vector.z,
                               matrix.a[2, 0] * vector.x + matrix.a[2, 1] * vector.y + matrix.a[2, 2] * vector.z);
        }
        public static Matrix3 operator *(Matrix3 matrix1, Matrix3 matrix2)
        {
            return new Matrix3(matrix1.a[0, 0] * matrix2.a[0, 0] + matrix1.a[0, 1] * matrix2.a[1, 0] + matrix1.a[0, 2] * matrix2.a[2, 0],
                               matrix1.a[0, 0] * matrix2.a[0, 1] + matrix1.a[0, 1] * matrix2.a[1, 1] + matrix1.a[0, 2] * matrix2.a[2, 1],
                               matrix1.a[0, 0] * matrix2.a[0, 2] + matrix1.a[0, 1] * matrix2.a[1, 2] + matrix1.a[0, 2] * matrix2.a[2, 2],
                               matrix1.a[1, 0] * matrix2.a[0, 0] + matrix1.a[1, 1] * matrix2.a[1, 0] + matrix1.a[1, 2] * matrix2.a[2, 0],
                               matrix1.a[1, 0] * matrix2.a[0, 1] + matrix1.a[1, 1] * matrix2.a[1, 1] + matrix1.a[1, 2] * matrix2.a[2, 1],
                               matrix1.a[1, 0] * matrix2.a[0, 2] + matrix1.a[1, 1] * matrix2.a[1, 2] + matrix1.a[1, 2] * matrix2.a[2, 2],
                               matrix1.a[2, 0] * matrix2.a[0, 0] + matrix1.a[2, 1] * matrix2.a[1, 0] + matrix1.a[2, 2] * matrix2.a[2, 0],
                               matrix1.a[2, 0] * matrix2.a[0, 1] + matrix1.a[2, 1] * matrix2.a[1, 1] + matrix1.a[2, 2] * matrix2.a[2, 1],
                               matrix1.a[2, 0] * matrix2.a[0, 2] + matrix1.a[2, 1] * matrix2.a[1, 2] + matrix1.a[2, 2] * matrix2.a[2, 2]);
        }
        public static Matrix3 operator /(Matrix3 matrix, float scale)
        {
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    matrix.a[y, x] /= scale;
                }
            }

            return matrix;
        }
    }
}
