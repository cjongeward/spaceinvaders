using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class Rect
    {
        private Azul.Line pLine;
        private float lineWidth;
        private Azul.Color color;
        private Vector2 bottomLeft, topRight;
        private Vector2 size;

        public Rect(Azul.Color _color)
        {
            lineWidth = 1.0f;
            color = _color;
            pLine = new Azul.Line(lineWidth, color, 0.0f, 0.0f, 0.0f, 0.0f);
            bottomLeft = new Vector2(0.0f, 0.0f);
            topRight = new Vector2(0.0f, 0.0f);
            size = new Vector2(0.0f, 0.0f);
        }

        public void setBounds(float x1, float y1, float w, float h)
        {
            size.x = w;
            size.y = h;
            bottomLeft.x = x1;
            bottomLeft.y = y1;
            topRight.x = x1 + w;
            topRight.y = y1 + h;
        }
        public void setSize(float w, float h)
        {
            size.x = w;
            size.y = h;
            topRight.x = bottomLeft.x + size.x;
            topRight.y = bottomLeft.y + size.y;
        }
        public void setSize(Vector2 _vec)
        {
            this.setSize(_vec.x, _vec.y);
        }
        public Vector2 getSize()
        {
            return size;
        }
        public void setPos(float x, float y)
        {
            bottomLeft.x = x;
            bottomLeft.y = y;
            topRight.x = x + size.x;
            topRight.y = y + size.y;
        }
        public void setPos(Vector2 _vec)
        {
            this.setPos(_vec.x, _vec.y);
        }
        public Vector2 getPos()
        {
            return bottomLeft;
        }
        public void Draw()
        {
            pLine.Draw(bottomLeft.x, bottomLeft.y, topRight.x, bottomLeft.y);
            pLine.Draw(topRight.x, bottomLeft.y, topRight.x, topRight.y);
            pLine.Draw(topRight.x, topRight.y, bottomLeft.x, topRight.y);
            pLine.Draw(bottomLeft.x, topRight.y, bottomLeft.x, bottomLeft.y);
        }
        public bool intersects(Rect _other)
        {
            bool isect = false;
            if (topRight.x > _other.bottomLeft.x &&
                bottomLeft.x < _other.topRight.x &&
                topRight.y > _other.bottomLeft.y &&
                bottomLeft.y < _other.topRight.y)
            {
                isect = true;
            }
            return isect;
        }
        public void union(Rect _rect)
        {
            this.bottomLeft.x = this.bottomLeft.x < _rect.bottomLeft.x ? this.bottomLeft.x : _rect.bottomLeft.x;
            this.bottomLeft.y = this.bottomLeft.y < _rect.bottomLeft.y ? this.bottomLeft.y : _rect.bottomLeft.y;
            this.topRight.x = this.topRight.x < _rect.topRight.x ? _rect.topRight.x : this.topRight.x;
            this.topRight.y = this.topRight.y < _rect.topRight.y ? _rect.topRight.y : this.topRight.y;
            this.size.x = this.topRight.x - this.bottomLeft.x;
            this.size.y = this.topRight.y - this.bottomLeft.y;
        }
    }
}
