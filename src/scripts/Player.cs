using Godot;
using System;

public class Player : AnimatedSprite
{
  [Signal]
  public delegate void PlayerAttack();

  private SpriteManager animtedSprite;
  public bool isTimerRunning = true;

  public override void _Ready()
  {
    animtedSprite = new SpriteManager(this);
  }

  public override void _Process(float delta)
  {
    if (Input.IsActionPressed("attack"))
    {
      animtedSprite.setSpriteState("Attacking");
      EmitSignal(nameof(PlayerAttack));
    }
  }

}
