using Godot;
using System;

public class KurosawaEdit : TextureRect
{
  private AnimationPlayer kurosawaPlayer;

  private bool isInTitle = true;

  public override void _Ready()
  {
    kurosawaPlayer = GetNode<AnimationPlayer>("KurosawaEdit");
    this.MarginRight = 0;
  }

  public override void _Process(float delta)
  {
    if (isInTitle && Input.IsActionJustPressed("attack"))
    {
      isInTitle = false;
      kurosawaPlayer.Play("Transition");        
    }
  }
}
