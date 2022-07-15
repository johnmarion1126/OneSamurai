using Godot;
using System;

public class Main : Node
{
    private Timer countdown;
    private Timer enemyTimer;

    private Player player;
    private Enemy enemy;
    private float totalTime;

    public override void _Ready()
    {
        GD.Print("START");
        GD.Randomize();        

        player = GetNode<Player>("Player");
        enemy = GetNode<Enemy>("Enemy");

        countdown = GetNode<Timer>("Countdown");
        enemyTimer = GetNode<Timer>("EnemyTimer");

        totalTime = (float)GD.RandRange(5.0, 10.0);
        countdown.WaitTime = totalTime;
        enemyTimer.WaitTime = totalTime + 1.0f;

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
