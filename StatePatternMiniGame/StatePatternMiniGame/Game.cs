using StatePatternMiniGame.State;

namespace StatePatternMiniGame;

public class Game
{
    IGameState _gameState;
    
    public bool IsRunning { get; set; }

    public Game(IGameState gameState)
    {
        _gameState = gameState;
        IsRunning = true;
    }

    public void Enter() => _gameState.Enter(this);
    public void HandleInput() => _gameState.HandleInput(this);
    public void Update() => _gameState.Update(this);
    public void Render() => _gameState.Render(this);
    public void Exit() => _gameState.Exit(this);
    
    public void ChangeState(IGameState gameState)
    {
        _gameState = gameState;
    }
    
}