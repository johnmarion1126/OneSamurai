using Godot;
using System;

public class SpriteManager : AnimatedSprite
{
  private AnimatedSprite animatedSprite;

  public SpriteManager()
  {
  }

  public SpriteManager(AnimatedSprite animatedSprite)
  {
    this.animatedSprite = animatedSprite;
  }

  public void setSpriteState(string state)
  {
    animatedSprite.Animation = state;
  }
  
}
