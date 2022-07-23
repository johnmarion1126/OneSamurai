using Godot;
using System;

public class Title : ColorRect
{

  public override void _Process(float delta)
  {
    if (Input.IsActionJustPressed("attack"))
    {
      GetTree().ChangeScene("res://src/scenes/Main.tscn");
    }
  }
}
