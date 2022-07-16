using Godot;
using System;

public class Enemy : AnimatedSprite
{
  private SpriteManager animtedSprite;

  public override void _Ready()
  {
    animtedSprite = new SpriteManager(this);
  }

  public void attack()
  {
    animtedSprite.setSpriteState("Attacking");
    GD.Print("Enemy attacks");
  }
  
}
