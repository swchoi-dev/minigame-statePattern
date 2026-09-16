using StatePatternMiniGame.State;

namespace StatePatternMiniGame;

class StatePatternMiniGame
{
    public static void Main()
    {
        Game game = new Game(new TitleState());
        while (game.IsRunning)
        {
            Console.Clear();
            game.Render();
            game.HandleInput();
            game.Update();
        }
    }
}