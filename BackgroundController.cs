using System;
using System.Numerics;

namespace MohawkGame2D
{
    internal class BackgroundController
    {
        // CLASSES
        private Ball ball;

        // VARIABLES
        float height = 500f;
        float width = 1300f;
        Color colorLight = new Color(22, 174, 241);
        Color colorMid = new Color(0, 152, 219);
        Color colorDark = new Color(0, 109, 176);
        Color grassColor = new Color(23, 239, 63);

        public void Setup(Ball existingBall)
        {
            ball = existingBall;
        }

        public void Update()
        {
            Vector2 ballPosition = ball.position;

            Draw.LineSize = 0;
            // Darkest shape
            Draw.FillColor = colorDark;
            Draw.Ellipse(
                (ballPosition.X * 0.9f) + (Window.Size.X / 2),
                (ballPosition.Y * 0.9f) + (Window.Size.Y * 0.5f),
                width,
                height
                );
            // Middle shape
            Draw.FillColor = colorMid;
            Draw.Ellipse(
                (ballPosition.X * 0.3f) + (Window.Size.X / 2),
                (ballPosition.Y * 0.3f) + (Window.Size.Y),
                width,
                height
                );
            // Lightest shape
            Draw.FillColor = colorLight;
            Draw.Ellipse(
                (ballPosition.X * 0.3f) + (Window.Size.X / 2),
                (ballPosition.Y * 0.3f) + (Window.Size.Y * 2),
                width,
                height
                );
            // Grass shape
            Draw.FillColor = colorLight;
            Draw.Rectangle(
                0,
                (ballPosition.Y * -0.3f) + (Window.Size.Y - 10),
                Window.Width,
                10
                );

        }
        // Get the direction the ball should move in the X direction based on its position
       

    }
}
