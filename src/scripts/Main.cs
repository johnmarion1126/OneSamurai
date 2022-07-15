using Godot;
using System;

public class Main : Node
{
    private Timer countdown;
    private Timer enemyTimer;

    private Player player;
    private Enemy enemy;

    public override void _Ready()
    {
        GD.Print("START");
        GD.Randomize();        

        player = GetNode<Player>("Player");
        enemy = GetNode<Enemy>("Enemy");

        countdown = GetNode<Timer>("Countdown");
        enemyTimer = GetNode<Timer>("EnemyTimer");

        countdown.WaitTime = 10.0f;
        enemyTimer.WaitTime = 15.0f;

        countdown.Start();
        enemyTimer.Start();
    }

    public void onCountdownTimeout()
    {
        GD.Print("DONE");
        player.isTimerRunning = false;
    }

    public void onEnemyTimerTimeout()
    {
        enemy.attack();
    }
}
