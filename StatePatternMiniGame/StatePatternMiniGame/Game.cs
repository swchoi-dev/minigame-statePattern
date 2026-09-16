using StatePatternMiniGame.State;
namespace StatePatternMiniGame;

public class Game
{
    IGameState _gameState;
    public bool IsRunning { get; set; }

    private Actor _player;
    private Actor _enemy;
    public Actor Player => _player;
    public Actor Enemy => _enemy;

    public Game(IGameState gameState)
    {
        _gameState = gameState;
        IsRunning = true;
        _player = new Actor("용사", 100, 100, 10, 20);
        _enemy = new Actor("슬라임", 50, 50, 25, 5);
    }

    public void Enter() => _gameState.Enter(this);
    public void HandleInput() => _gameState.HandleInput(this);
    public void Update() => _gameState.Update(this);
    public void Render() => _gameState.Render(this);
    public void Exit() => _gameState.Exit(this);
    
    public void ChangeState(IGameState next)
    {
        _gameState.Exit(this);
        _gameState = next;
        _gameState.Enter(this);
    }

    public void ResetGame()
    {
        _player.Hp = _player.MaxHp;
        _enemy.Hp = _enemy.MaxHp;
    }
    
}