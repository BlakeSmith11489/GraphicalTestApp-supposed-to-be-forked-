using System;
using Raylib;
using RL = Raylib.Raylib;

namespace GraphicalTestApp
{
    class AABB : Actor
    {
        Raylib.Color _color = Raylib.Color.RED;
        public float Width { get; set; } = 1;
        public float Height { get; set; } = 1;

        //Returns the Y coordinate at the top of the box
        public float Top
        {
            get { return YAbsolute - Height / 2; }
        }

        //Returns the Y coordinate at the bottom of the box
        public float Bottom
        {
            get { return YAbsolute + Height / 2; }
        }

        //Returns the X coordinate of the left side of the box
        public float Left
        {
            get { return XAbsolute - Width / 2; }
        }

        //Returns the X coordinate of the right side of the box
        public float Right
        {
            get { return XAbsolute + Width / 2; }
        }

        //Creates an AABB of the specifed size
        public AABB(float width, float height)
        {
            Width = width;
            Height = height;
        }

        public bool DetectCollision(AABB other)
        {
            //## Implement DetectCollision(AABB) ##//
            if (Left < other.Right && Right > other.Left && Top < other.Bottom && Bottom > other.Top)
            {
                _color = Raylib.Color.BLUE;
                return true;
            }
            _color = Raylib.Color.RED;
            return false;
        }

        public bool DetectCollision(Vector3 point)
        {
            //## Implement DetectCollision(Vector3) ##//
            return false;
        }

        //Draw the bounding box to the screen
        public override void Draw()
        {
            Raylib.Rectangle rec = new Raylib.Rectangle(
                Left, Top, Width, Height);
            Raylib.Raylib.DrawRectangleLinesEx(rec, 2, _color);

            base.Draw();
        }
    }
}
