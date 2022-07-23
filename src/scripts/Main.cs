using Godot;
using System;

public class Main : Node
{
  private Timer countdown;
  private Timer enemyTimer;
  private Label startMessage;
  private Label resultMessage;
  private Label resetMessage;

  private Node2D titleNode;
  private AnimationPlayer animPlayer;

  private AudioStreamPlayer2D titleMusic;
  private AudioStreamPlayer2D singleHit;
  private AudioStreamPlayer2D doubleHit;

  private Samurai samurai1;
  private Samurai samurai2;

  private bool isStartTimerRunning = true;
  private bool isGameRunning = false;
  private bool isInTitle = true;

  public override void _Ready()
  {
    GD.Randomize();        

    startMessage = GetNode<Label>("StartMessage");
    resultMessage = GetNode<Label>("ResultMessage");
    resetMessage = GetNode<Label>("ResetMessage");

    titleNode = GetNode<Node2D>("TitleNode");
    animPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

    titleMusic = GetNode<AudioStreamPlayer2D>("TitleMusic");
    singleHit = GetNode<AudioStreamPlayer2D>("SingleHit");
    doubleHit = GetNode<AudioStreamPlayer2D>("DoubleHit");

    startMessage.Hide();
    resultMessage.Hide();
    resetMessage.Hide();

    samurai1 = GetNode<Samurai>("Samurai1");
    samurai2 = GetNode<Samurai>("Samurai2");

    countdown = GetNode<Timer>("Countdown");
    enemyTimer = GetNode<Timer>("EnemyTimer");

    animPlayer.Play("FadeToNormal");
    animPlayer.Play("FadeMusicIn");
  }

  public override void _Process(float delta)
  {
    if (isGameRunning && Input.IsActionJustPressed("attack"))
    {
      playerAttack();
    }

    if (!isGameRunning && Input.IsActionJustPressed("reset"))
    {
      reset();
    }

    if (isInTitle && Input.IsActionJustPressed("attack"))
    {
      isInTitle = false;
      isGameRunning = true;
      titleNode.Hide();
      titleMusic.Stop();
      singleHit.Play();
      setTimers();
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
    isGameRunning = true;
  }

  public void onCountdownTimeout()
  {
    isStartTimerRunning = false;
    startMessage.Show();
    doubleHit.Play();
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
    isGameRunning = false;
    setEnemyWin();
  }

  public void playerAttack()
  {
    if (!isGameRunning) return;
    isGameRunning = false;
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
