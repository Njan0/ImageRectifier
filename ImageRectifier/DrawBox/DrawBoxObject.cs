using System;
using System.Windows.Forms;

namespace ImageRectifier
{
    public abstract class DrawBoxObject
    {
        private DrawBox parent;

        public abstract void Draw(PaintEventArgs e);
        public abstract void Scale(float widthScale, float heightScale);

        public void RegisterObject(DrawBox db)
        {
            parent = db;
        }
        public void Invaldiate()
        {
            if (parent != null)
                parent.Invalidate();
        }
    }
}
