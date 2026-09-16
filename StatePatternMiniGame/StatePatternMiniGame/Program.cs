using StatePatternMiniGame.State;

namespace StatePatternMiniGame;

class StatePatternMiniGame
{
    public static void Main()
    {
        Game game = new Game(new TitleState());
        while (game.IsRunning)
        {
            game.Enter();
            
            game.Render();
        
            game.HandleInput();
        
            game.Update();
        
            game.Exit();
        }
    }
}