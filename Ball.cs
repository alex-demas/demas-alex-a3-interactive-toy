using System;
using System.Numerics;
using System.Reflection.Metadata;

namespace MohawkGame2D
{
    internal class Ball
    {
        // CONFIG
        float RADIUS = 20f;
        float GRAVITY = 800f;
        // BALL VARIABLES
        float speed = 0f;
        float ballX = Window.Size.X / 2f;
        float ballY = Window.Size.Y - 20; // last number is radius
        int directionX = 1; // 1 for right, -1 for left
        int directionY = -1; // 1 for down, -1 for up
        Vector2 position = new Vector2(Window.Size.X / 2f, Window.Size.Y - 20f);
        Vector2 velocity = new Vector2(0f, 0f);
        Color ballColor = Color.Red;

        void DrawBall()
        {
            Draw.FillColor = ballColor;
            Draw.Circle(position, RADIUS);
        }

        public void Setup()
        {
            speed = 150f;
            velocity = new Vector2(5f, 5f);
        }

        public void Update()
        {

            if (Input.IsKeyboardKeyDown(KeyboardKey.Space))
            {
                Console.WriteLine("B1");
                float dt = Time.DeltaTime;
                velocity.Y = -400f;
                velocity.Y += GRAVITY * dt;
                position.X += velocity.X * speed * dt;
                position.Y += velocity.Y * dt;
            }

            DrawBall();

        }

    }
}
