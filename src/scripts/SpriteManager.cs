using Godot;
using System;

public class SpriteManager : AnimatedSprite
{
    public void setStandingSprite()
    {
        this.Animation = "Standing";
    }
    public void setAttackingSprite()
    {
        this.Animation = "Attacking";
    }
    public void setFaintingSprite()
    {
        this.Animation = "Fainting";
    }
}
