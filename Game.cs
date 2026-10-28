// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;
using System.Reflection.Metadata;

// The namespace your code is in.
namespace MohawkGame2D
{
    ///     Your game code goes inside this class!
    public class Game
    {
        // CLASSES
        Ball ball = new Ball();
        BallController ballController = new BallController();
        BallCalculator ballCalculator = new BallCalculator();
        BackgroundController backgroundController = new BackgroundController();

        // CONFIG
        Color BACKGROUND_COLOR = new Color(0, 87, 154);
        float GRAVITY = 800f;
        // VARIABLES
        float ballX = 0f;
        float ballY = 0f;
        float speed = 150f;
        Vector2 velocity = new Vector2(0f, 0f);
        Vector2 position = new Vector2(0f, 0f);
        
        ///     Setup runs once before the game loop begins.
  

        public void Setup()
        {
            // SETUP WINDOW
            Window.SetSize(400, 400);
            Window.ClearBackground(BACKGROUND_COLOR);

            ballCalculator.Setup(ball);
            ballController.Setup(ball);
            backgroundController.Setup(ball);
        }

        ///     Update runs every frame.
        public void Update()
        {
            // Clear last instances drawn
            Window.ClearBackground(BACKGROUND_COLOR);

            // Updates
            backgroundController.Update();
            ballController.Update();
            ball.Update();
            ballCalculator.Update();
        }
    }

}
