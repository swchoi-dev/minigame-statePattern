using System.Text;

namespace StatePatternMiniGame.State;

public class BattleState : IGameState
{
    private bool IsPlayerTurn;
    private bool IsActiveDefense;
    
    private string turnInfo;
    private string playerInfo;
    private string enemyInfo;
    private string behaviourInfo = "";

    private int selected;

    public void Enter(Game game)
    {
        IsPlayerTurn = !IsPlayerTurn;
        turnInfo = IsPlayerTurn ? "플레이어" : "적";
        playerInfo = GetInfoString(game.Player);
        enemyInfo = GetInfoString(game.Enemy);
    }

    public void Render(Game game)
    {
        Console.WriteLine("======== BATTLE ========");
        Console.WriteLine($"  상태: {GetType().Name}");
        Console.WriteLine($"  턴: {turnInfo}");
        Console.WriteLine();
        Console.WriteLine(playerInfo);
        Console.WriteLine(enemyInfo);
        if (behaviourInfo.Length > 0)
        {
            Console.WriteLine(behaviourInfo);
        }

        Console.WriteLine();
        if (IsPlayerTurn)
        {
            Console.WriteLine(" [1] 공격");
            Console.WriteLine(" [2] 방어");
            Console.WriteLine(" [3] 회복");
        }

        Console.WriteLine();
    }

    public void HandleInput(Game game)
    {
        if (IsPlayerTurn)
        {
            selected = ConsoleInput.ReadIntInRange("명령: ", 1, 3);
        }
        else
        {
            Console.WriteLine("슬라임이 행동을 준비합니다...");
            ConsoleInput.Pause();
        }
        
        Console.WriteLine();
    }

    public void Update(Game game)
    {
        if (IsPlayerTurn)
        {
            if (selected == 1) Attack(game);
            else if (selected == 2) Defense(game);
            else if (selected == 3) Healing(game);
        }
        else
        {
            EnemyAttack(game);
        }
    }

    public void Exit(Game game)
    {
        if (game.Enemy.Hp <= 0) game.ChangeState(new VictoryState());
        else if (game.Player.Hp <= 0) game.ChangeState(new GameOverState());
    }

    private string GetInfoString(Actor actor)
    {
        // name: 용사
        // hp: HP [########--]
        // hpInr: 80/100
        StringBuilder sb = new StringBuilder();

        int threshold = actor.Hp * 10 / actor.MaxHp;
        string hpBar = "";
        for (int i = 1; i <= 10; i++)
        {
            if (i <= threshold) hpBar += '#';
            else hpBar += '-';
        }

        sb.Append($"  {actor.Name}");
        sb.Append($"  HP [{hpBar}] ");
        sb.Append($"{actor.Hp}/{actor.MaxHp}");

        return sb.ToString();
    }

    private void Attack(Game game)
    {
        game.Enemy.Hp -= game.Player.Damage;
        behaviourInfo = $"용사가 공격! 슬라임에게 {game.Player.Damage} 데미지...!";
    }

    private void Defense(Game game)
    {
        IsActiveDefense = true;
        behaviourInfo = $"용사가 방어! {game.Player.Defense} 만큼 방어한다...!";
    }

    private void Healing(Game game)
    {
        game.Player.Hp += 30;
        behaviourInfo = $"용사가 회복! 30 만큼 회복한다...!";
    }

    private void EnemyAttack(Game game)
    {
        int damage = game.Enemy.Damage;
        if (IsActiveDefense) damage -= game.Player.Defense;
        game.Player.Hp -= damage;
        
        IsActiveDefense = false;
        
        behaviourInfo = $"슬라임이 몸통박치기! {damage} 데미지...!";
    }
}