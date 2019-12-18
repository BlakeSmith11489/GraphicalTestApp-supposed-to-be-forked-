using System;

namespace GraphicalTestApp
{
    class Entity : Actor
    {
        private Vector3 _velocity = new Vector3();
        private Vector3 _acceleration = new Vector3();

        public float XVelocity
        {
            get { return _velocity.x; }
            set { _velocity.x = value; }
        }
        public float XAcceleration
        {
            get { return _acceleration.x; }
            set { _acceleration.x = value; }
        }
        public float YVelocity
        {
            get { return _velocity.y; }
            set { _velocity.y = value; }
        }
        public float YAcceleration
        {
            get { return _acceleration.y; }
            set { _acceleration.y = value; }
        }

        public Entity(float x, float y) : base()
        {
            X = x;
            Y = y;
        }

        public override void Update(float deltaTime)
        {
            _velocity = _velocity + _acceleration * deltaTime;
            X = X + XVelocity * deltaTime;
            Y = Y + YVelocity * deltaTime;
            base.Update(deltaTime);
        }
    }
}
