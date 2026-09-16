namespace StatePatternMiniGame.State;

public interface IGameState
{
    public void Enter(Game game);
    public void HandleInput(Game game);
    public void Update(Game game);
    public void Render(Game game);
    public void Exit(Game game);
}