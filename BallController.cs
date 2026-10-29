using System;
using System.Diagnostics;
using System.IO;
using System.Numerics;

namespace MohawkGame2D
{
    internal class BallController
    {
        // CLASSES
        private Ball ball;
        // CONFIG
        float minLength = 0f;
        float maxLength = 200f;
        float speedMultiplier = 2f;
        // VARAIBLES
        bool dragging = false;
        float dragDistance = 0;

        public void Setup(Ball existingBall)
        {
            ball = existingBall;
        }

        // Get a color gradient to represent the power being applied
        Color GetColor(float length)
        {
            if (length == null)
                return Color.Black;

            float value = Math.Clamp((length - minLength) / (maxLength - minLength), 0f, 1f);
            float red = Math.Clamp(2f * value, 0f, 1f);
            float green = Math.Clamp(2f * (1f - value), 0f, 1f);
            return new ColorF(green, red, 0f);
        }

        public void Update()
        {
            // When the player starts dragging
            if (Input.IsMouseButtonDown(MouseButton.Left))
            {
                // Reset velocity to zero if dragging
                Ball.velocity = Vector2.Zero;
                Ball.speed = 0;
                // Return if already dragging
                dragging = true;

                // Get positions for velocity indicator
                Vector2 mousePosition = Input.GetMousePosition();

                Vector2 difference = mousePosition - ball.position;
                float length = difference.Length();
                difference = Vector2.Normalize(difference);
                Vector2 perpendicular1 = new Vector2(-difference.Y, difference.X);
                Vector2 perpendicular2 = new Vector2(difference.Y, -difference.X);

                // Get points on circle's edge
                Vector2 point1 = ball.position + perpendicular1 * ball.RADIUS;
                Vector2 point2 = ball.position + perpendicular2 * ball.RADIUS;

                dragDistance = Math.Clamp(length, minLength, maxLength);

                // Draw triangle
                Draw.LineColor = Color.Black;
                Draw.LineSize = 3;
                Draw.FillColor = GetColor(length);
                Draw.Triangle(point1, point2, mousePosition);

            }
            else if (Input.IsMouseButtonReleased(MouseButton.Left))
            {
                // Launcht the ball when released
                dragging = false;
                Vector2 mousePosition = Input.GetMousePosition();

                // Direction velocity
                Vector2 velocity = ball.position - mousePosition;

                // Direction
                Ball.directionX = velocity.X > ball.position.X ? -1 : 1;
                Ball.directionY = velocity.Y > ball.position.Y ? -1 : 1;

                // Apply values
                Ball.gravity = ball.DEFAULT_GRAVITY;
                Ball.speed = dragDistance * speedMultiplier;
                Ball.velocity = velocity / dragDistance;

                Ball.watch = Stopwatch.StartNew();
            }
        }
        // Get the direction the ball should move in the X direction based on its position

    }
}
