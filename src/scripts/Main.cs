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

  private bool isStartTimerRunning = true;
  private bool isGameFinish = false;

  public override void _Ready()
  {
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

    setTimers();
  }

  public override void _Process(float delta)
  {
    if (isGameFinish && Input.IsActionJustPressed("reset"))
    {
      reset();
    }
  }

  public void setTimers()
  {
    float totalTime = (float)GD.RandRange(4.0, 8.0);
    float enemyReactTime = (float)GD.RandRange(0.5, 2.0);

    countdown.WaitTime = totalTime;
    enemyTimer.WaitTime = totalTime + enemyReactTime;

    countdown.Start();
    enemyTimer.Start();
  }

  public void reset()
  {
    resultMessage.Hide();
    resetMessage.Hide();

    player.resetPosition();
    enemy.resetPosition();

    setTimers();
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
    player.attack();
  }

  public void setPlayerWin()
  {
    resetMessage.Show();
    startMessage.Hide();
    resultMessage.Text = "Player Wins";
    resultMessage.Show();

    enemy.attack();
    player.faint();
  }

  public void onEnemyTimerTimeout()
  {
    isGameFinish = true;
    setEnemyWin();
  }

  public void onPlayerAttack()
  {
    isGameFinish = true;
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
