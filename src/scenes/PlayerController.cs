using Godot;
using System;

public class PlayerController : AnimatedSprite
{
    [Export]
    private SpriteManager animtedSprite;
    public override void _Ready()
    {
        animtedSprite = new SpriteManager(this);
    }

  public override void _Process(float delta)
  {
    if (Input.IsActionPressed("attack"))
    {
        animtedSprite.setSpriteState("Attacking");
    }
  }

}
