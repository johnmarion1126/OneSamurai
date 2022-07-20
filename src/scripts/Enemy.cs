using Godot;
using System;

public class Enemy : AnimatedSprite
{
  private SpriteManager animtedSprite;

  public override void _Ready()
  {
    animtedSprite = new SpriteManager(this);
  }

  public void resetPosition()
  {
    animtedSprite.setSpriteState("Standing");
    this.FlipH = true;
  }

  public void attack()
  {
    animtedSprite.setSpriteState("Attacking");
    this.FlipH = false;
  }

  public void faint()
  {
    animtedSprite.setSpriteState("Fainting");
    this.FlipH = false;
  }
  
}
