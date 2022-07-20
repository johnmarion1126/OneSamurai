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
  }

  public void faint()
  {
    animtedSprite.setSpriteState("Fainting");
  }
  
}
