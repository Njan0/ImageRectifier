using System;
using System.Drawing;

namespace MathTools
{
    public static class MT
    {
        public static int LengthSquared(Point vector)
        {
            return vector.X * vector.X + vector.Y * vector.Y;
        }
        public static int LengthSquared(Point point1, Point point2)
        {
            return LengthSquared(SubtractPoint(point1, point2));
        }
        public static Point AddPoint(Point point1, Point point2)
        {
            return new Point(point1.X + point2.X, point1.Y + point2.Y);
        }
        public static Point SubtractPoint(Point point1, Point point2)
        {
            return new Point(point1.X - point2.X, point1.Y - point2.Y);
        }

        public static float LengthSquared(PointF vector)
        {
            return vector.X * vector.X + vector.Y * vector.Y;
        }
        public static float LengthSquared(PointF point1, PointF point2)
        {
            return LengthSquared(SubtractPoint(point1, point2));
        }
        public static PointF AddPoint(PointF point1, PointF point2)
        {
            return new PointF(point1.X + point2.X, point1.Y + point2.Y);
        }
        public static PointF SubtractPoint(PointF point1, PointF point2)
        {
            return new PointF(point1.X - point2.X, point1.Y - point2.Y);
        }

        public static PointF ScalePoint(PointF point, float scaleX, float scaleY)
        {
            return new PointF(point.X * scaleX, point.Y * scaleY);
        }
        public static Point ClampPoint(Point point, Rectangle bounds)
        {
            if (point.X < bounds.Left)
                point.X = bounds.Left;
            else if (point.X > bounds.Right)
                point.X = bounds.Right;

            if (point.Y < bounds.Top)
                point.Y = bounds.Top;
            else if (point.Y > bounds.Bottom)
                point.Y = bounds.Bottom;

            return point;
        }
        public static PointF ClampPoint(PointF point, RectangleF bounds)
        {
            if (point.X < bounds.Left)
                point.X = bounds.Left;
            else if (point.X > bounds.Right)
                point.X = bounds.Right;

            if (point.Y < bounds.Top)
                point.Y = bounds.Top;
            else if (point.Y > bounds.Bottom)
                point.Y = bounds.Bottom;

            return point;
        }

        public static RectangleF CenterRectangle(PointF center, SizeF size)
        {
            return new RectangleF(new PointF(center.X - size.Width / 2, center.Y - size.Height / 2), size);
        }

        public static Matrix3 GetPerspectiveMatrix(int width, int height, Vector3[] rectangle)
        {
            Vector3 u1 = new Vector3(0, 0, 1);
            Vector3 u2 = new Vector3(width - 1, 0, 1);
            Vector3 u3 = new Vector3(width - 1, height - 1, 1);
            // Vector3 u4 = new Vector3(0, height - 1, 1);

            // Matrix3 m1 = new Matrix3(u1, u2, u3);
            // Vector3 scale1 = m1.Solve(u4);
            // m1 = m1.ScaleColumn(0, scale1.x).ScaleColumn(1, scale1.y).ScaleColumn(2, scale1.z);
            Matrix3 m1 = new Matrix3(u1, -u2, u3);

            Matrix3 m2 = new Matrix3(rectangle[0], rectangle[1], rectangle[2]);
            Vector3 scale2 = m2.Solve(rectangle[3]);
            m2 = m2.ScaleColumn(0, scale2.x).ScaleColumn(1, scale2.y).ScaleColumn(2, scale2.z);

            return m2 * m1.Adjugate();
        }

        public static float[] GetPremultiplied(Bitmap image, int posX, int posY)
        {
            if (posX < 0 || posX >= image.Width || posY < 0 || posY >= image.Height)
                return new float[4];

            Color result = image.GetPixel(posX, posY);
            float scale = (result.A / 255f);
            return new float[] { result.A, result.R * scale, result.G * scale, result.B * scale };
        }

        public static Color ColorFromPremultiplied(float a, float r, float g, float b)
        {
            if (a == 0)
                return Color.Transparent;

            float scale = 255f / a;
            return Color.FromArgb((int)a, (int)(r * scale), (int)(g * scale), (int)(b * scale));
        }

        public static Color BilinearInterpolation(Bitmap image, float posX, float posY)
        {
            int roundedX = (int)Math.Floor(posX);
            int roundedY = (int)Math.Floor(posY);

            float restX = posX - roundedX;
            float restY = posY - roundedY;
            float restInvX = 1 - restX;
            float restInvY = 1 - restY;

            // get 4 nearest pixels
            float[] colorTL = GetPremultiplied(image, roundedX, roundedY);
            float[] colorTR = GetPremultiplied(image, roundedX + 1, roundedY);
            float[] colorBL = GetPremultiplied(image, roundedX, roundedY + 1);
            float[] colorBR = GetPremultiplied(image, roundedX + 1, roundedY + 1);

            // interpolate
            float[] result = new float[4];
            for (int i = 0; i < 4; ++i)
            {
                result[i] = (colorTL[i] * restInvX + colorTR[i] * restX) * restInvY + (colorBL[i] * restInvX + colorBR[i] * restX) * restY;
            }
            
            return ColorFromPremultiplied(result[0], result[1], result[2], result[3]);
        }
    }
}
