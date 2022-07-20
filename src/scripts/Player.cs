using Godot;
using System;

public class Player : AnimatedSprite
{
  [Signal]
  public delegate void Attack();

  private SpriteManager animtedSprite;

  public override void _Ready()
  {
    animtedSprite = new SpriteManager(this);
  }

  public override void _Process(float delta)
  {
    if (Input.IsActionJustPressed("attack"))
    {
      animtedSprite.setSpriteState("Attacking");
      EmitSignal(nameof(Attack));
    }
  }

  public void resetPosition()
  {
    animtedSprite.setSpriteState("Standing");
    this.FlipH = false;
  }
  
  public void attack()
  {
    animtedSprite.setSpriteState("Attacking");
    this.FlipH = true;
  }

  public void faint()
  {
    animtedSprite.setSpriteState("Fainting");
    this.FlipH = true;
  }

}
