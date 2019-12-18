using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Chasis : Entity
    {
        private Sprite _tank;
        private AABB _tankBox;
        private Turret _turret;


        public Chasis(float x, float y, string path) : base(x, y)
        {
            _tank = new Sprite(path);
            _tankBox = new AABB(40, 40);
            _turret = new Turret(0, 0);

            AddChild(_tank);
            AddChild(_tankBox);
            AddChild(_turret);
        }

        public Chasis() : this(640, 360, "Sprites/ground_shaker_asset/Bodies/body_tracks.png")
        {

        }

        public Chasis(string path) : this(640, 360, path)
        {

        }

        public Chasis(float x, float y) : this(x, y, "Sprites/ground_shaker_asset/Bodies/body_tracks.png")
        {

        }

        public AABB GetAABB
        {
            get
            {
                return _tankBox;
            }
        }


        public void Moveforward()
        {

            if (Input.IsKeyDown(87))
            {
                YVelocity = 150;
            }
            else if (Input.IsKeyDown(83))
            {
                YVelocity = -80;
            }
            else
            {
                YVelocity = 0;
            }
        }

        public override void Update(float deltaTime)
        {
            _tankBox.DetectCollision(Program.box);
            Moveforward();
            base.Update(deltaTime);
        }
    }
}
