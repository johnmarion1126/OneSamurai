using Godot;
using System;

public class PlayerController : AnimatedSprite
{
    [Export]
    private SpriteManager animtedSprite;
    public override void _Ready()
    {
        animtedSprite = new SpriteManager(this);
        animtedSprite.setSpriteState("Fainting");
    }

}
