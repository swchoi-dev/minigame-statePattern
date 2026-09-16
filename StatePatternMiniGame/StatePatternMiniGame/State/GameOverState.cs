namespace StatePatternMiniGame.State;

public class GameOverState : IGameState
{
    private int selected;
    
    public void Enter(Game game)
    {
    }

    public void Render(Game game)
    {
        Console.WriteLine("========================");
        Console.WriteLine("        GAME OVER       ");
        Console.WriteLine("========================");
        Console.WriteLine("  용사가 쓰러졌다...");
        Console.WriteLine("[1] 다시 도전");
        Console.WriteLine("[2] 타이틀로");
        Console.WriteLine("[3] 종료");
        Console.WriteLine();
    }

    public void HandleInput(Game game)
    {
        selected = ConsoleInput.ReadIntInRange("선택: ", 1, 3);
    }

    public void Update(Game game)
    {
        if (selected == 1) game.ChangeState(new BattleState());
        if (selected == 2) game.ChangeState(new TitleState());
        if (selected == 3) game.IsRunning = false;
    }

    public void Exit(Game game)
    {
        
    }
}