using Godot;
using System;

public class Main : Node
{
  private Timer countdown;
  private Timer enemyTimer;
  private Label startMessage;
  private Label resultMessage;
  private Player player;
  private Enemy enemy;

  private float totalTime;
  private bool isStartTimerRunning = true;

  public override void _Ready()
  {
    GD.Print("START");
    GD.Randomize();        

    startMessage = GetNode<Label>("StartMessage");
    resultMessage = GetNode<Label>("ResultMessage");

    startMessage.Hide();

    player = GetNode<Player>("Player");
    enemy = GetNode<Enemy>("Enemy");

    countdown = GetNode<Timer>("Countdown");
    enemyTimer = GetNode<Timer>("EnemyTimer");

    totalTime = (float)GD.RandRange(5.0, 10.0);
    countdown.WaitTime = totalTime;
    enemyTimer.WaitTime = totalTime + 3.0f;

    countdown.Start();
    enemyTimer.Start();
  }

  public void onCountdownTimeout()
  {
    GD.Print("DONE");
    isStartTimerRunning = false;
    startMessage.Show();
  }

  public void onEnemyTimerTimeout()
  {
    enemy.attack();
  }

  public void onPlayerAttack()
  {
    if (isStartTimerRunning) 
    {
      GD.Print("Player loses");
    }
    else 
    {
      GD.Print("Player wins");
    }
  }

}
