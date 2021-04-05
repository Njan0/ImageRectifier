using MathTools;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace ImageRectifier
{
    public class Polygon : DrawBoxObject
    {
        private readonly Pen edgePen;
        private readonly Brush verticesBrush;
        private Size verticesSize;
        private PointF[] _vertices;
        public ReadOnlyCollection<PointF> vertices
        {
            get
            {
                return Array.AsReadOnly(_vertices);
            }
        }

        public Polygon(Pen edgePen, Brush verticesBrush, int verticesRadius,  params PointF[] vertices)
        {
            this.edgePen = edgePen;
            this.verticesBrush = verticesBrush;
            this.verticesSize = new Size(2 * verticesRadius, 2 * verticesRadius);
            this._vertices = vertices;
        }

        public void ShiftVertex(int index, PointF shift)
        {
            _vertices[index] = MT.AddPoint(_vertices[index], shift);
            Invaldiate();
        }
        public void ShiftVertexClamp(int index, PointF shift, RectangleF bounds)
        {
            _vertices[index] = MT.ClampPoint(MT.AddPoint(_vertices[index], shift), bounds);
            Invaldiate();
        }

        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawPolygon(edgePen, _vertices);

            if (verticesBrush != null)
            {
                foreach (PointF vertex in vertices)
                    e.Graphics.FillEllipse(verticesBrush, MT.CenterRectangle(vertex, verticesSize));
            }
        }
        public override void Scale(float widthScale, float heightScale)
        {
            for (int i = 0; i < _vertices.Length; i++)
                _vertices[i] = MT.ScalePoint(_vertices[i], widthScale, heightScale);

            Invaldiate();
        }
    }
}
