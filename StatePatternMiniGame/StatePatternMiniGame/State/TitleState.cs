namespace StatePatternMiniGame.State;

public class TitleState : IGameState
{
    private int selected;
    
    public void Enter(Game game)
    {
        Console.WriteLine("========================");
        Console.WriteLine("      Slime Hunter      ");
        Console.WriteLine("========================");
        Console.WriteLine("[1] 시작");
        Console.WriteLine("[2] 종료");
        Console.WriteLine();
    }

    public void HandleInput(Game game)
    {
        selected = ConsoleInput.ReadIntInRange("선택: ", 1, 2);
    }

    public void Update(Game game)
    {
    }

    public void Render(Game game)
    {
        
    }

    public void Exit(Game game)
    {
        if (selected == 1) game.ChangeState(new BattleState());
        if (selected == 2) game.IsRunning = false;
    }
}