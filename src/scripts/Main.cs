using Godot;
using System;

public class Main : Node
{
  private Timer countdown;
  private Timer enemyTimer;
  private Label startMessage;
  private Label resultMessage;
  private Label resetMessage;

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
    resetMessage = GetNode<Label>("ResetMessage");

    startMessage.Hide();
    resultMessage.Hide();
    resetMessage.Hide();

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

  public void reset()
  {

  }

  public void onCountdownTimeout()
  {
    isStartTimerRunning = false;
    startMessage.Show();
  }

  public void setEnemyWin()
  {
    resetMessage.Show();
    startMessage.Hide();
    resultMessage.Text = "Enemy Wins";
    resultMessage.Show();

    enemy.faint();
    enemy.FlipH = false;

    player.attack();
    player.FlipH = true;
  }

  public void setPlayerWin()
  {
    resetMessage.Show();
    startMessage.Hide();
    resultMessage.Text = "Player Wins";
    resultMessage.Show();

    enemy.attack();
    enemy.FlipH = false;

    player.faint();
    player.FlipH = true;
  }

  public void onEnemyTimerTimeout()
  {
    setEnemyWin();
  }

  public void onPlayerAttack()
  {
    countdown.Stop();
    enemyTimer.Stop();

    if (isStartTimerRunning) 
    {
      setEnemyWin();
    }
    else 
    {
      setPlayerWin();
    }
  }

}
