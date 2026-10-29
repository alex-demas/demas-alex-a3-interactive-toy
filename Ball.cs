using System;
using System.Numerics;
using System.Diagnostics;

namespace MohawkGame2D
{
    internal class Ball
    {
        // CONFIG
        public float RADIUS = 20f;
        public float DEFAULT_GRAVITY = 5f;
        // PUBLIC VARIABLES
        public static float gravity = 0f;
        public static float speed = 0f;
        public static int directionX = 0; // 1 for right, -1 for left
        public static int directionY = 0; // 1 for down, -1 for up
        public Vector2 position = new Vector2(Window.Size.X / 2f, Window.Size.Y - 20f);
        public static Vector2 velocity = new Vector2(0f, 0f);
        public static Stopwatch watch;
        // LOCAL VARIABLES
        int bounces = 0;


        Color ballColor = Color.Red;

        void DrawBall()
        {
            Draw.LineColor = Color.Black;
            Draw.LineSize = 3;
            Draw.FillColor = ballColor;
            Draw.Circle(position, RADIUS);
        }

        //public void Setup()
        //{

        //}

        public void Update()
        {
            float dt = Time.DeltaTime;
            //velocity.Y += GRAVITY * dt;

            if (watch != null)
            {
                velocity.Y += gravity * watch.ElapsedMilliseconds/100000;
            }

            position.X += velocity.X * speed * dt;
            position.Y += velocity.Y * speed * dt;

            DrawBall();
        }

    }
}
