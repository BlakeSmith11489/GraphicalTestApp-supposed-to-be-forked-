using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Chasis2 : Entity
    {
        private float _lastX;
        private float _lastY;
        private Chasis _chasis;
        public Chasis2(float x, float y) : base(x, y)
        {
            _chasis = new Chasis(0, 0);
            AddChild(_chasis);
        }

        public override void Update(float deltaTime)
        {
            _chasis.Y = 0;

            _lastX = X;
            _lastY = Y;

            RotateRight(deltaTime);
            RotateLeft(deltaTime);

            base.Update(deltaTime);

            X = _chasis.XAbsolute;
            Y = _chasis.YAbsolute;

            if (_chasis.GetAABB.DetectCollision(Program.box) == true)
            {
                X = _lastX;
                Y = _lastY;
            }

        }

        public void RotateRight(float deltaTime)
        {
            if (Input.IsKeyDown(68))
            {
                Rotate(2 * deltaTime);
            }
        }

        public void RotateLeft(float deltaTime)
        {
            if (Input.IsKeyDown(65))
            {
                Rotate(-2 * deltaTime);
            }
        }
    }
}
