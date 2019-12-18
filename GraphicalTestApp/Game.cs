using System;
using Raylib;
using RL = Raylib.Raylib;

namespace GraphicalTestApp
{
    class Game
    {
        private Actor _root = null;
        private Actor _next = null;
        private Timer _gameTimer = new Timer();

        public Game(int width, int height, string title)
        {
            RL.InitWindow(width, height, title);
            RL.SetTargetFPS(0);
        }

        public void Run()
        {
            while (!RL.WindowShouldClose())
            {
                if (_root != _next)
                {
                    _root = _next;
                }

                if (!_root.Started)
                {
                    _root.Start();
                }

                _root.Update(_gameTimer.GetDeltaTime());

                RL.BeginDrawing();
                RL.ClearBackground(Color.PURPLE);
                _root.Draw();
                RL.EndDrawing();
            }

            RL.CloseWindow();
        }

        public Actor Root
        {
            get { return _root; }
            set
            {
                _next = value;
                if (_root == null) _root = value;
            }
        }
    }
}
