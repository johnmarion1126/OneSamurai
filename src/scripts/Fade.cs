using Godot;
using System;

public class Fade : ColorRect
{
    private AnimationPlayer fadePlayer;

    public override void _Ready()
    {
        fadePlayer = GetNode<AnimationPlayer>("FadePlayer");
        fadePlayer.Play("FadeIn");        
    }
}
