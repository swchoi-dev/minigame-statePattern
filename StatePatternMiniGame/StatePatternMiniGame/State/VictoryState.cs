namespace StatePatternMiniGame.State;

public class VictoryState : IGameState
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
        Console.WriteLine("  슬라임을 물리쳤다!");
        Console.WriteLine($"  남은 HP: {game.Player.Hp}");
        Console.WriteLine("[1] 다시 싸우기");
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
    }

    public void Exit(Game game)
    {
        if (selected == 1) game.ChangeState(new BattleState());
        if (selected == 2) game.ChangeState(new TitleState());
        if (selected == 3) game.IsRunning = false;
    }
}