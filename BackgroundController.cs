using System;
using System.Numerics;

namespace MohawkGame2D
{
    internal class BackgroundController
    {
        // CLASSES
        private Ball ball;

        // VARIABLES
        float height = 600f;
        float width = 1500f;
        Color colorLight = new Color(22, 174, 241);
        Color colorMid = new Color(0, 152, 219);
        Color colorDark = new Color(0, 109, 176);
        Color grassColor = new Color(0, 154, 41);
        int grassHeight = 20;
        // TRAIL VARIABLES
        int trailSegments = 15;
        Vector2[] trail = new Vector2[15];


        // DRAW THE TRAIL BEHIND THE BALL
        void DrawTrail()
        {

            // Shift all positions one index forward
            for (int i = trailSegments - 1; i > 0; i--)
            {
                trail[i] = trail[i - 1];
            }
            // Store the newest position
            trail[0] = ball.position;

            // Draw the trail segments
            for (int i = 0; i < trailSegments; i++)
            {
                Draw.LineSize = 0;
                Draw.SetFillColor(Color.White);
                Draw.Circle(
                    trail[i].X,
                    trail[i].Y,
                    ball.RADIUS - i
                    );
            }
        }

        // SETUP
        public void Setup(Ball existingBall)
        {
            ball = existingBall;
        }

        // UPDATE
        public void Update()
        {
            //
            Vector2 ballPosition = ball.position;

            Draw.LineSize = 0;
            // Darkest shape
            Draw.FillColor = colorDark;
            Draw.Ellipse(
                (Window.Size.X / 2),
                 (ballPosition.Y * -1f) + (Window.Size.Y * 1f),
                width,
                height
                );
            // Middle shape
            Draw.FillColor = colorMid;
            Draw.Ellipse(
                (Window.Size.X / 2),
                (ballPosition.Y * -1.5f) + (Window.Size.Y * 1.5f),
                width,
                height
                );
            // Lightest shape
            Draw.FillColor = colorLight;
            Draw.Ellipse(
                (Window.Size.X / 2),
                (ballPosition.Y * -2.2f) + (Window.Size.Y * 2.2f),
                width,
                height
                );
            // Grass shape
            Draw.LineColor = Color.Black;
            Draw.LineSize = 3;
            Draw.FillColor = grassColor;
            Draw.Rectangle(
                -5,
                (Window.Size.Y + grassHeight*2) - ((ball.position.Y - 150) * 0.3f),
                Window.Width + 10, // Offset the values so the black outline only shows on the top of the rectangle
                grassHeight * 2
             );

            // Draw trail
            DrawTrail();

        }       

    }
}
