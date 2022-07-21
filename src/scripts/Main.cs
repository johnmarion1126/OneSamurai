using Godot;
using System;

public class Main : Node
{
  private Timer countdown;
  private Timer enemyTimer;
  private Label startMessage;
  private Label resultMessage;
  private Label resetMessage;

  private Samurai samurai1;
  private Samurai samurai2;

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

    samurai1 = GetNode<Samurai>("Samurai1");
    samurai2 = GetNode<Samurai>("Samurai2");

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

    if (Input.IsActionJustPressed("attack"))
    {
      playerAttack();
    }
  }

  public void setTimers()
  {
    float totalTime = (float)GD.RandRange(4.0, 8.0);
    float enemyReactTime = (float)GD.RandRange(0.25, 1);

    countdown.WaitTime = totalTime;
    enemyTimer.WaitTime = totalTime + enemyReactTime;

    countdown.Start();
    enemyTimer.Start();
    isStartTimerRunning = true;
  }

  public void reset()
  {
    resultMessage.Hide();
    resetMessage.Hide();

    samurai1.changeSprite("Standing", false);
    samurai2.changeSprite("Standing", true);

    setTimers();
    isGameFinish = false;
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

    samurai1.changeSprite("Attacking", true);
    samurai2.changeSprite("Fainting", false);
  }

  public void setPlayerWin()
  {
    resetMessage.Show();
    startMessage.Hide();
    resultMessage.Text = "Player Wins";
    resultMessage.Show();

    samurai1.changeSprite("Fainting", true);
    samurai2.changeSprite("Attacking", false);
  }

  public void onEnemyTimerTimeout()
  {
    isGameFinish = true;
    setEnemyWin();
  }

  public void playerAttack()
  {
    if (isGameFinish) return;
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
