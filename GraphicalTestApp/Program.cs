using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalTestApp
{
    class Program
    {
        public static AABB box = new AABB(40, 40);
        static void Main(string[] args)
        {
            Game game = new Game(1280, 720, "Tank Game, GraphicalTestApp");

            Actor root = new Actor();
            game.Root = root;

            Chasis2 player = new Chasis2(640, 380);

            box.X = 300;
            box.Y = 200;
            root.AddChild(player);
            root.AddChild(box);

            game.Run();
        }
    }
}

