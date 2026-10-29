using System;
using System.Numerics;

namespace MohawkGame2D
{
    internal class BallCalculator
    {
        // CLASSES
        private Ball ball;
        // VARAIBLES
        int grassHeight = 20;

        public void Setup(Ball existingBall)
        {
            ball = existingBall;
        }

        public void Update()
        {
            SetDirectionX();
            SetDirectionY();
        }
        // Get the direction the ball should move in the X direction based on its position
        public void SetDirectionX()
        {
            if (ball.position.X <= ball.RADIUS) // If the ball hits the left wall
            {
                Ball.directionX = 1;
                Ball.velocity.X = Math.Abs(Ball.velocity.X);
                Console.WriteLine("Out of left");
            }
            else if (ball.position.X >= Window.Size.X - ball.RADIUS)
            {
                Ball.directionX = -1;
                Ball.velocity.X = -Math.Abs(Ball.velocity.X);
                Console.WriteLine("Out of right");
            }
        }
        // Get the direction the ball should move in the Y direction based on its position
        public void SetDirectionY()
        {
            if (ball.position.Y <= ball.RADIUS) // If the ball hits the top wall]
            {
                Ball.directionY = 1;
                Console.WriteLine("Out of top");
                Ball.velocity.Y = Math.Abs(Ball.velocity.Y);
            }
            else if (ball.position.Y >= Window.Size.Y - ball.RADIUS - grassHeight)
            {
                Ball.directionY = -1;
                Console.WriteLine("Out of bottom");
                Ball.velocity.Y = -Math.Abs(Ball.velocity.Y);
            }
        }

    }
}
