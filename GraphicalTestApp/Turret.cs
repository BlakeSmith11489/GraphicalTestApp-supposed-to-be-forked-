using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using RL = Raylib.Raylib;

namespace GraphicalTestApp
{
    class Turret : Actor
    {
        private Sprite _turret;

        public Turret(float x, float y)
        {
            _turret = new Sprite("Sprites/ground_shaker_asset/Weapons/turret_01_mk12.png");


            X = 0;
            Y = 0;
            _turret.X = -5.5f;
            _turret.Y = 0;


            AddChild(_turret);
        }


        public override void Update(float deltaTime)
        {
           if (Input.IsKeyDown(81))
           {
              Rotate(2 * deltaTime);
           }
            

           
           if (Input.IsKeyDown(69))
           {
              Rotate(-2 * deltaTime);
           }

            if (Input.IsKeyPressed(32))
            {
                Shoot();
            }

            base.Update(deltaTime);
        }

        private void Shoot()
        {
            Shell _shell = new Shell(XAbsolute, YAbsolute);

            _shell.Rotate(Parent.Parent.GetRotation() + GetRotation());

            _shell.XAcceleration = (float)Math.Cos(GetRotation() + Parent.Parent.GetRotation() - Math.PI * .5f) * 300;
            _shell.YAcceleration = (float)Math.Sin(GetRotation() + Parent.Parent.GetRotation() - Math.PI * .5f) * 300;

            Parent.Parent.Parent.AddChild(_shell);
        }
    }
}
