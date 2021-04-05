using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTools
{
    public struct Vector3
    {
        public static Vector3 zero;
        public static Vector3 one;

        static Vector3()
        {
            zero = new Vector3(0, 0, 0);
            one = new Vector3(1, 1, 1);
        }

        public float x;
        public float y;
        public float z;

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override bool Equals(object obj)
        {
            return this == ((Vector3)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int result = x.GetHashCode();
                result = (result * 397) ^ y.GetHashCode();
                result = (result * 397) ^ z.GetHashCode();
                return result;
            }
        }

        public float GetDimension(int i)
        {
            switch (i)
            {
                case 0:
                    return x;

                case 1:
                    return y;

                case 2:
                    return z;
            }

            throw new IndexOutOfRangeException();
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.x, -v.y, -v.z);
        }
        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return v1.x == v2.x && v1.y == v2.y && v1.z == v2.z;
        }
        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return v1.x != v2.x || v1.y != v2.y || v1.z != v2.z;
        }
    }
}
