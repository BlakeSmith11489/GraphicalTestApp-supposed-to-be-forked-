using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Shell : Entity
    {
        private Sprite shell = new Sprite("Sprites/PNG/Bullets/bulletBeigeSilver");

        private AABB Hitbox;

        public Shell(float x, float y) : base(x, y)
        {
            X = x;
            Y = y;
            AABB hitbox = new AABB(shell.Width, shell.Height);

            Hitbox = hitbox;

            AddChild(hitbox);
            AddChild(shell);
        }
    }
}
