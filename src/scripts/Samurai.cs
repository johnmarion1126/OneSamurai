using Godot;
using System;

public class Samurai : AnimatedSprite
{
    public void changeSprite(string spriteAnim, bool isFlipped)
    {
        this.Animation = spriteAnim;
        this.FlipH = isFlipped;
    }
}
