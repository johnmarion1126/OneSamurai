using Godot;
using System;

public class Player : AnimatedSprite
{
  [Signal]
  public delegate void Attack();

  public override void _Process(float delta)
  {
    if (Input.IsActionJustPressed("attack"))
    {
      this.Animation = "Attacking";
      EmitSignal(nameof(Attack));
    }
  }

  public void resetPosition()
  {
    this.Animation = "Standing";
    this.FlipH = false;
  }

  public void attack()
  {
    this.Animation = "Attacking";
    this.FlipH = true;
  }

  public void faint()
  {
    this.Animation = "Fainting";
    this.FlipH = true;
  }

}
